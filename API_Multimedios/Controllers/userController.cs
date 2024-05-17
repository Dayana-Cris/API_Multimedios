using Microsoft.AspNetCore.Mvc;
using API_Multimedios.Data;
using API_Multimedios.Models;

namespace API_Multimedios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class userController : ControllerBase
    {
        private readonly Contexto contexto;
        public userController(Contexto pContext)
        {
            this.contexto = pContext;
        }

        [HttpGet]
        public List<user> Get()
        {
            var List = this.contexto.user.ToList();

            return List;
        }

        [HttpGet("{idUser}")]
        public IActionResult GetDatos(int idUser)
        {
            try
            {
                var temp = this.contexto.user.Find(idUser);
                if (temp != null)
                {
                    return Ok(temp);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error de capa 8 :)  " + ex);
            }
            return BadRequest("El id ingresado no existe, digite nuevamente");
        }

        [HttpPost("agregarUser")]
        public IActionResult AgregarUser(user nuevoUser)
        {
            try
            {
                var temp = this.contexto.user.Find(nuevoUser.IdUser);

                if (temp != null)
                {
                    return BadRequest("El id del user ya existe dentro de la base de datos");
                }
                else
                {
                    if (!contexto.roles.Any(r => r.IdRol == nuevoUser.IdRol))
                    {
                        return BadRequest("El id del rol especificado no existe en la base de datos.");
                    }
                    nuevoUser.CreatedAt = DateTime.Now;
                    nuevoUser.UpdateAt = DateTime.Now;
                    this.contexto.Add(nuevoUser);
                    this.contexto.SaveChanges();

                    return Ok("User agregado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error de capa 8 :)  " + ex);
            }
          
        }

        [HttpPut("modificar")]
        public IActionResult ModificarUser(user user)
        {
            try
            {
                var temp = this.contexto.user.Find(user.IdUser);

                if (temp == null)
                {
                    return BadRequest("El id del user no existe dentro de la base de datos, por favor ingrese un id que exista");
                }
                if (!contexto.roles.Any(r => r.IdRol == user.IdRol))
                {
                    return BadRequest("El id del rol especificado no existe en la base de datos.");
                }
                user.UpdateAt = DateTime.Now;
                this.contexto.Attach(temp);
                this.contexto.Entry(temp).CurrentValues.SetValues(user);
                this.contexto.Entry(temp).Property("CreatedAt").IsModified = false;
                this.contexto.SaveChanges();
               

                return Ok("User modificado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error detectado  " + ex);
            }
        }

        [HttpDelete("{idUser}")]
        public string eliminarUser(int idUser)
        {
            string mensaje = "No se logró eliminar el registro del usuario";
            var temp = this.contexto.user.Find(idUser);

            try
            {
                if (temp != null)
                {
                    this.contexto.Remove(temp);
                    this.contexto.SaveChanges();

                    mensaje = "El user con id " + temp.IdUser + " se eliminó correctamente!";
                }
            }
            catch (Exception ex)
            {
                return mensaje+"  "+ex;
            }
           
            return mensaje;
        }
    }
}

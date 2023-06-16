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
        public user GetDatos(int idUser)
        {
            var temp = this.contexto.user.Find(idUser);

            return temp;
        }

        [HttpPut("agregarUser")]
        public IActionResult AgregarUser(user nuevoUser)
        {
            try
            {
                if (!contexto.roles.Any(r => r.IdRol == nuevoUser.IdRol))
                {
                    return BadRequest("El id del rol especificado no existe en la base de datos.");
                }
                this.contexto.Add(nuevoUser);
                this.contexto.SaveChanges();

                return Ok("User agregado exitosamente.");
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
                if (!contexto.roles.Any(r => r.IdRol == user.IdRol))
                {
                    return BadRequest("El id del rol especificado no existe en la base de datos.");
                }
                this.contexto.Update(user);
                this.contexto.SaveChanges();
                user.UpdateAt = DateTime.Now;

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

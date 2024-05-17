using Microsoft.AspNetCore.Mvc;
using API_Multimedios.Data;
using API_Multimedios.Models;

namespace API_Multimedios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class rolesController : ControllerBase
    {
        private readonly Contexto contexto;
        public rolesController(Contexto pContext)
        {
            this.contexto = pContext;
        }

        [HttpGet]
        public List<roles> Get()
        {
            var List = this.contexto.roles.ToList();

            return List;
        }

        [HttpGet("{idRol}")]
        public IActionResult GetDatos(int idRol)
        {
            try
            {
                var temp = this.contexto.roles.Find(idRol);
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


        [HttpPost("agregarRol")]
        public IActionResult AgregarRol(roles nuevoRol)
        {
            try
            {
                var temp = this.contexto.roles.Find(nuevoRol.IdRol);

                if (temp != null)
                {
                    return BadRequest("El id del rol ya existe dentro de la base de datos");
                }
                else
                {
                    if (!contexto.menu.Any(m => m.IdMenu == nuevoRol.IdMenu))
                    {
                        return BadRequest("El id del menu especificado no existe en la base de datos.");
                    }
                    nuevoRol.CreatedAt = DateTime.Now;
                    nuevoRol.UpdatedAt = DateTime.Now;
                    this.contexto.Add(nuevoRol);
                    this.contexto.SaveChanges();

                    return Ok("Rol agregado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error de capa 8 :)  " + ex);
            }
            
        }

        [HttpPut("modificar")]
        public IActionResult ModificarRol(roles rol)
        {
            try
            {
                var temp = this.contexto.roles.Find(rol.IdRol);

                if (temp == null)
                {
                    return BadRequest("El id del rol no existe dentro de la base de datos, por favor ingrese un id que exista");
                }
                else
                {
                    if (!contexto.menu.Any(m => m.IdMenu == rol.IdMenu))
                    {
                        return BadRequest("El id del menu especificado no existe en la base de datos.");
                    }
                    rol.UpdatedAt = DateTime.Now;
                    this.contexto.Attach(temp);
                    this.contexto.Entry(temp).CurrentValues.SetValues(rol);
                    this.contexto.Entry(temp).Property("CreatedAt").IsModified = false;
                    this.contexto.SaveChanges();

                    return Ok("Rol modificado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error detectado  " + ex);
            }
        }

        [HttpDelete("{idRol}")]
        public string eliminarRol(int idRol)
        {
            string mensaje = "No se logró eliminar el registro del rol";
            var temp = this.contexto.roles.Find(idRol);

            try
            {
                if (temp != null)
                {
                    this.contexto.Remove(temp);
                    this.contexto.SaveChanges();

                    mensaje = "El rol con id " + temp.IdRol + " se eliminó correctamente!";
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

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
        public roles GetDatos(int idRol)
        {
            var temp = this.contexto.roles.Find(idRol);

            return temp;
        }


        [HttpPut("agregarRol")]
        public IActionResult AgregarRol(roles nuevoRol)
        {
            try
            {
                if (!contexto.menu.Any(m => m.IdMenu == nuevoRol.IdMenu))
                {
                    return BadRequest("El id del menu especificado no existe en la base de datos.");
                }
                this.contexto.Add(nuevoRol);
                this.contexto.SaveChanges();

                return Ok("Rol agregado exitosamente.");
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
                if (!contexto.menu.Any(m => m.IdMenu == rol.IdMenu))
                {
                    return BadRequest("El id del menu especificado no existe en la base de datos.");
                }
                rol.UpdatedAt = DateTime.Now;
                this.contexto.Update(rol);
                this.contexto.SaveChanges();

                return Ok("Rol modificado exitosamente.");
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

            if (temp != null)
            {
                this.contexto.Remove(temp);
                this.contexto.SaveChanges();

                mensaje = "El rol con id: " + temp.IdRol + " se eliminó correctamente!";
            }
            return mensaje;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using API_Multimedios.Data;
using API_Multimedios.Models;

namespace API_Multimedios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class errorController : ControllerBase
    {
        private readonly Contexto contexto;
        public errorController(Contexto pContext)
        {
            this.contexto = pContext;
        }

        [HttpGet]
        public List<error> Get()
        {
            var List = this.contexto.error.ToList();

            return List;
        }

        [HttpGet("{idError}")]
        public error GetDatos(int idError)
        {
            var temp = this.contexto.error.Find(idError);

            return temp;
        }

        [HttpPut("agregarError")]
        public IActionResult AgregarError(error nuevoError)
        {
            try
            {
                if (!contexto.user.Any(u => u.IdUser == nuevoError.idUser))
                {
                    return BadRequest("El id del user especificado no existe en la base de datos.");
                }
                nuevoError.CreatedAt = DateTime.Now;
                this.contexto.Add(nuevoError);
                this.contexto.SaveChanges();

                return Ok("Error agregado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error de capa 8 :)  " + ex);
            }
        }

        [HttpPut("modificar")]
        public IActionResult ModificarError(error error)
        {
            try
            {
                if (!contexto.user.Any(u => u.IdUser == error.idUser))
                {
                    return BadRequest("El id del user especificado no existe en la base de datos.");
                }
                this.contexto.Update(error);
                this.contexto.SaveChanges();

                return Ok("Error modificado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error detectado  " + ex);
            }
        }

        [HttpDelete("{idError}")]
        public string eliminarError(int idError)
        {
            string mensaje = "No se logró eliminar el registro del error";
            var temp = this.contexto.error.Find(idError);

            if (temp != null)
            {
                this.contexto.Remove(temp);
                this.contexto.SaveChanges();

                mensaje = "El error con id: " + temp.IdErrores + " se eliminó correctamente!";
            }
            return mensaje;
        }
    }
}

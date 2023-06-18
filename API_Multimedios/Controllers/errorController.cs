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
        public IActionResult GetDatos(int idError)
        {
            try
            {
                var temp = this.contexto.error.Find(idError);
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

        [HttpPut("agregarError")]
        public IActionResult AgregarError(error nuevoError)
        {
            try
            {
                var temp = this.contexto.error.Find(nuevoError.IdErrores);

                if (temp != null)
                {
                    return BadRequest("El id del error ya existe dentro de la base de datos");
                }
                else
                {
                    if (!contexto.user.Any(u => u.IdUser == nuevoError.IdUser))
                    {
                        return BadRequest("El id del user especificado no existe en la base de datos.");
                    }
                    nuevoError.CreatedAt = DateTime.Now;
                    this.contexto.Add(nuevoError);
                    this.contexto.SaveChanges();

                    return Ok("Error agregado exitosamente.");
                }
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
                var temp = this.contexto.error.Find(error.IdErrores);

                if (temp == null)
                {
                    return BadRequest("El id del error no existe dentro de la base de datos, por favor ingrese un id que exista");
                }
                else
                {
                    if (!contexto.user.Any(u => u.IdUser == error.IdUser))
                    {
                        return BadRequest("El id del user especificado no existe en la base de datos.");
                    }
                    this.contexto.Attach(temp);
                    this.contexto.Entry(temp).CurrentValues.SetValues(error);
                    this.contexto.Entry(temp).Property("CreatedAt").IsModified = false;
                    this.contexto.SaveChanges();

                    return Ok("Error modificado exitosamente.");
                }
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

            try
            {
                if (temp != null)
                {
                    this.contexto.Remove(temp);
                    this.contexto.SaveChanges();

                    mensaje = "El error con id " + temp.IdErrores + " se eliminó correctamente!";
                }
            }
            catch (Exception ex)
            {
                return mensaje +"  "+ex;
            }
           
            return mensaje;
        }
    }
}

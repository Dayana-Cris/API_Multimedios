using Microsoft.AspNetCore.Mvc;
using API_Multimedios.Data;
using API_Multimedios.Models;

namespace API_Multimedios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class controllerController : ControllerBase
    {
        private readonly Contexto contexto;
        public controllerController(Contexto pContext)
        {
            this.contexto = pContext;
        }

        [HttpGet]
        public List<controller> Get()
        {
            var List = this.contexto.controller.ToList();

            return List;
        }

        [HttpGet("{idController}")]
        public IActionResult GetDatos(int idController)
        {
            try
            {
                var temp = this.contexto.controller.Find(idController);
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

        [HttpPost("agregarController")]
        public IActionResult AgregarController(controller nuevoController)
        {
            
            try
            {
                var temp = this.contexto.controller.Find(nuevoController.IdController);

                if (temp != null)
                {
                    return BadRequest("El id del controller ya existe dentro de la base de datos");
                }
                else
                {
                    nuevoController.CreatedAt = DateTime.Now;
                    nuevoController.UpdatedAt = DateTime.Now;
                    this.contexto.Add(nuevoController);
                    this.contexto.SaveChanges();
                   
                    return Ok("Controller agregado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error de capa 8 :)  " + ex);
            }
        }

        [HttpPut("modificar")]
        public IActionResult ModificarController(controller controller)
        {
            try
            {
                var temp = this.contexto.controller.Find(controller.IdController);

                if (temp == null)
                {
                    return BadRequest("El id del controller no existe dentro de la base de datos, por favor ingrese un id que exista");
                }
                else
                {
                    controller.UpdatedAt = DateTime.Now;
                    this.contexto.Attach(temp);
                    this.contexto.Entry(temp).CurrentValues.SetValues(controller);
                    this.contexto.Entry(temp).Property("CreatedAt").IsModified = false;
                    this.contexto.SaveChanges();

                    return Ok("Controller modificado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error detectado  " + ex);
            }
        }

        [HttpDelete("{idController}")]
        public string eliminarController(int idController)
        {
            string mensaje = "No se logró eliminar el registro del controller";
            var temp = this.contexto.controller.Find(idController);

            try
            {
                if (temp != null)
                {
                    this.contexto.Remove(temp);
                    this.contexto.SaveChanges();

                    mensaje = "El controller con id " + temp.IdController + " se eliminó correctamente!";
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

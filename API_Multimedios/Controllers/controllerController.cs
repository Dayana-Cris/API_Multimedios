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
        public controller GetDatos(int idController)
        {
            var temp = this.contexto.controller.Find(idController);

            return temp;
        }

        [HttpPut("agregarController")]
        public void AgregarController(controller nuevoController)
        {
            this.contexto.Add(nuevoController);
            this.contexto.SaveChanges();
        }

        [HttpDelete("{idController}")]
        public string eliminarController(int idController)
        {
            string mensaje = "No se logró eliminar el registro del controller";
            var temp = this.contexto.controller.Find(idController);

            if (temp != null)
            {
                this.contexto.Remove(temp);
                this.contexto.SaveChanges();

                mensaje = "El controller con id: " + temp.IdController + " se eliminó correctamente!";
            }
            return mensaje;
        }
    }
}

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
        public void AgregarError(error nuevoError)
        {
            //List<user> listaUser = new List<user>();
            //listaUser.Add(listaUser);
            //if (!error.ExisteUser(nuevoError.IdErrores, listaError)
            //{
            //    return BadRequest("El ID de rol especificado no existe en la lista de roles.");
            //}
            this.contexto.Add(nuevoError);
            this.contexto.SaveChanges();
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

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
        public void AgregarRol(menu nuevoRol)
        {
            this.contexto.Add(nuevoRol);
            this.contexto.SaveChanges();
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

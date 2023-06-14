using Microsoft.AspNetCore.Mvc;
using API_Multimedios.Data;
using API_Multimedios.Models;

namespace API_Multimedios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class menuController : ControllerBase
    {
        private readonly Contexto contexto;
        public menuController(Contexto pContext)
        {
            this.contexto = pContext;
        }

        [HttpGet]
        public List<menu> Get()
        {
            var List = this.contexto.menu.ToList();

            return List;
        }

        [HttpGet("{idMenu}")]
        public menu GetDatos(int idMenu)
        {
            var temp = this.contexto.menu.Find(idMenu);

            return temp;
        }

        [HttpPut("agregarMenu")]
        public void AgregarMenu(menu nuevoMenu)
        {
            this.contexto.Add(nuevoMenu);
            this.contexto.SaveChanges();
        }

        [HttpDelete("{idMenu}")]
        public string eliminarError(int idMenu)
        {
            string mensaje = "No se logró eliminar el registro del menu";
            var temp = this.contexto.menu.Find(idMenu);

            if (temp != null)
            {
                this.contexto.Remove(temp);
                this.contexto.SaveChanges();

                mensaje = "El menu con id: " + temp.IdMenu + " se eliminó correctamente!";
            }
            return mensaje;
        }
    }
}

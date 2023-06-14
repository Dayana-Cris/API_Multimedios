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
        public void AgregarUser(menu nuevoUser)
        {
            this.contexto.Add(nuevoUser);
            this.contexto.SaveChanges();
        }

        [HttpDelete("{idUser}")]
        public string eliminarUser(int idUser)
        {
            string mensaje = "No se logró eliminar el registro del usuario";
            var temp = this.contexto.user.Find(idUser);

            if (temp != null)
            {
                this.contexto.Remove(temp);
                this.contexto.SaveChanges();

                mensaje = "El user con id: " + temp.IdUser + " se eliminó correctamente!";
            }
            return mensaje;
        }
    }
}

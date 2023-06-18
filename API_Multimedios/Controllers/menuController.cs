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
        public IActionResult GetDatos(int idMenu)
        {
            try
            {
                var temp = this.contexto.menu.Find(idMenu);
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

        [HttpPut("agregarMenu")]
        public IActionResult AgregarMenu(menu nuevoMenu)
        {
            try
            {
                var temp = this.contexto.menu.Find(nuevoMenu.IdMenu);

                if (temp != null)
                {
                    return BadRequest("El id del menu ya existe dentro de la base de datos");
                }
                nuevoMenu.CreatedAt = DateTime.Now;
                nuevoMenu.UpdatedAt = DateTime.Now;
                this.contexto.Add(nuevoMenu);
                this.contexto.SaveChanges();
                return Ok("Menu agregado exitosamente.");
            }
            catch(Exception ex)
            {
                return BadRequest("Error de capa 8 :)  " + ex);
            }
            
        }

        [HttpPut("modificar")]
        public IActionResult ModificarMenu(menu menu)
        {
            try
            {
                var temp = this.contexto.menu.Find(menu.IdMenu);

                if (temp == null)
                {
                    return BadRequest("El id del menu no existe dentro de la base de datos, por favor ingrese un id que exista");
                }
                else
                {
                    menu.UpdatedAt = DateTime.Now;
                    this.contexto.Attach(temp);
                    this.contexto.Entry(temp).CurrentValues.SetValues(menu);
                    this.contexto.Entry(temp).Property("CreatedAt").IsModified = false;
                    this.contexto.SaveChanges();

                    return Ok("Menu modificado exitosamente.");
                }  
            }
            catch (Exception ex)
            {
                return BadRequest("Error detectado  " + ex);
            }
        }

        [HttpDelete("{idMenu}")]
        public string eliminarError(int idMenu)
        {
            string mensaje = "No se logró eliminar el registro del menu";
            var temp = this.contexto.menu.Find(idMenu);
            try
            {
                if (temp != null)
                {
                    this.contexto.Remove(temp);
                    this.contexto.SaveChanges();

                    mensaje = "El menu con id " + temp.IdMenu + " se eliminó correctamente!";
                }
            }
            catch(Exception ex)
            {
                return mensaje + "  " + ex;
            }
            return mensaje;
        }
    }
}

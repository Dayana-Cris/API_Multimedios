using Microsoft.AspNetCore.Mvc;
using API_Multimedios.Data;
using API_Multimedios.Models;

namespace API_Multimedios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class auditoriaController : ControllerBase
    {
        private readonly Contexto contexto;
        public auditoriaController(Contexto pContext)
        {
            this.contexto = pContext;
        }

        [HttpGet]
        public List<auditoria> Get()
        {
            var List = this.contexto.auditoria.ToList();

            return List;
        }

        [HttpGet("{idAuditoria}")]
        public IActionResult GetDatos(int idAuditoria)
        {
            try
            {
                var temp = this.contexto.auditoria.Find(idAuditoria);
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

        [HttpPut("agregarAuditoria")]
        public IActionResult AgregarAuditoria(auditoria nuevaAuditoria)
        {
            try
            {
                var temp = this.contexto.auditoria.Find(nuevaAuditoria.IdAuditoria);

                if (temp != null)
                {
                    return BadRequest("El id de la auditoría ya existe dentro de la base de datos");
                }
                else
                {
                    if (!contexto.user.Any(u => u.IdUser == nuevaAuditoria.IdUser))
                    {
                        return BadRequest("El id del user especificado no existe en la base de datos.");
                    }
                    if (!contexto.menu.Any(m => m.IdMenu == nuevaAuditoria.IdMenu))
                    {
                        return BadRequest("El id del menu especificado no existe en la base de datos.");
                    }
                    nuevaAuditoria.CreateDate = DateTime.Now;
                    this.contexto.Add(nuevaAuditoria);
                    this.contexto.SaveChanges();

                    return Ok("Auditoria agregada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error de capa 8 :)  " + ex);
            }

        }

        [HttpPut("modificar")]
        public IActionResult ModificarAuditoria(auditoria auditoria)
        {
            try
            {
                var temp = this.contexto.auditoria.Find(auditoria.IdAuditoria);

                if (temp == null)
                {
                    return BadRequest("El id de la auditoría no existe dentro de la base de datos, por favor ingrese un id que exista");
                }
                else
                {
                    if (!contexto.user.Any(u => u.IdUser == auditoria.IdUser))
                    {
                        return BadRequest("El id del user especificado no existe en la base de datos.");
                    }
                    if (!contexto.menu.Any(m => m.IdMenu == auditoria.IdMenu))
                    {
                        return BadRequest("El id del menu especificado no existe en la base de datos.");
                    }
                    
                    this.contexto.Attach(temp);                   
                    this.contexto.Entry(temp).CurrentValues.SetValues(auditoria);
                    this.contexto.Entry(temp).Property("CreateDate").IsModified = false;
                    this.contexto.SaveChanges();

                    return Ok("Auditoria modificada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error detectado  " + ex);
            }
        }

        [HttpDelete("{idAuditoria}")]
        public string eliminarAuditoria(int idAuditoria)
        {
            string mensaje = "No se logró eliminar el registro de la auditoria";
            var temp = this.contexto.auditoria.Find(idAuditoria);

            try
            {
                if (temp != null)
                {
                    this.contexto.Remove(temp);
                    this.contexto.SaveChanges();

                    mensaje = "La auditoria con id " + temp.IdAuditoria + " se eliminó correctamente!";
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
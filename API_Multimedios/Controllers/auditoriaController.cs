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
        public auditoria GetDatos(int idAuditoria)
        {
            var temp = this.contexto.auditoria.Find(idAuditoria);

            return temp;
        }

        [HttpPut("agregarAuditoria")]
        public void AgregarAuditoria(auditoria nuevaAuditoria)
        {
            this.contexto.Add(nuevaAuditoria);
            this.contexto.SaveChanges();
        }

        [HttpDelete("{idAuditoria}")]
        public string eliminarAuditoria(int idAuditoria)
        {
            string mensaje = "No se logró eliminar el registro de la auditoria";
            var temp = this.contexto.auditoria.Find(idAuditoria);

            if (temp != null)
            {
                this.contexto.Remove(temp);
                this.contexto.SaveChanges();

                mensaje = "La auditoria con id: " + temp.IdAuditoria + " se eliminó correctamente!";
            }
            return mensaje;
        }
    }
}
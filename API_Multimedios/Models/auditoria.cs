using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Multimedios.Models
{
    public class auditoria
    {
        [Key]
        public int IdAuditoria { get; set; }
        public string Sentencia { get; set; }
        public string Controller { get; set; }

        [ForeignKey("menu")]
        public int IdMenu { get; set; }

        [ForeignKey("user")]
        public int IdUser { get; set; }
        public DateTime CreatedAte { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Multimedios.Models
{
    public class auditoria
    {
        [Key]
        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco :(")]
        public int IdAuditoria { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco :(")]
        public string Sentencia { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string Controller { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        [ForeignKey("menu")]
        public int IdMenu { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        [ForeignKey("user")]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime CreateDate { get; set; }
    }
}

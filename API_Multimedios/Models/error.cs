using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Multimedios.Models
{
    public class error
    {
        [Key]
        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public int IdErrores { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string Sentencia { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string Controller { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        [ForeignKey("user")]
        public int IdUser { get; set; }
    }
}

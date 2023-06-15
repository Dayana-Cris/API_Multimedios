using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Multimedios.Models
{
    public class roles
    {
        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        [Key]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string NameRol { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        [ForeignKey("menu")]
        public int IdMenu { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime UpdatedAt { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public bool Enabled { get; set; }
    }
}

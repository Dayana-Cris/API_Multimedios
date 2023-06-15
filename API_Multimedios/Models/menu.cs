using System.ComponentModel.DataAnnotations;
namespace API_Multimedios.Models
{
    public class menu
    {
        [Key]
        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public int IdMenu { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string NameMenu { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public int IdCatalogoMenu { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime UpdatedAt { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public bool Enabled { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace API_Multimedios.Models
{
    public class controller
    {
        [Key]
        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public int IdController { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string NameControllerView { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime UpdatedAt { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public bool Enabled { get; set; } 


    }
}

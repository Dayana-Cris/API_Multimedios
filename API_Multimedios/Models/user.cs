using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Multimedios.Models
{
    public class user
    {
        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        [Key]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string IdPersonal { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string NameUser { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        [ForeignKey("roles")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public bool Enabled { get; set; }

        [Required(ErrorMessage = "Espacio obligatorio. No dejarlo en blanco")]
        public DateTime UpdateAt { get; set; }
    }
}

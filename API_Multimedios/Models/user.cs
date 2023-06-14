using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Multimedios.Models
{
    public class user
    {
        [Key]
        public int IdUser { get; set; }

        public string IdPersonal { get; set; }

        public string NameUser { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [ForeignKey("roles")]
        public int IdRol { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Enabled { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}

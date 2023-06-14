using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Multimedios.Models
{
    public class roles
    {
        [Key]
        public int IdRol { get; set; }

        public string NameRol { get; set; }

        [ForeignKey("menu")]
        public int IdMenu { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Enabled { get; set; }
    }
}

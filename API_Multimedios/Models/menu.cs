using System.ComponentModel.DataAnnotations;
namespace API_Multimedios.Models
{
    public class menu
    {
        [Key]
        public int IdMenu { get; set; }
        public string NameMenu { get; set; }
        public int IdCatalogoMenu { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Enabled { get; set; }

    }
}

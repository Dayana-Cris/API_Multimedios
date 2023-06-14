using System.ComponentModel.DataAnnotations;

namespace API_Multimedios.Models
{
    public class controller
    {
        [Key]
        public int IdController { get; set; }

        public string NameControllerView { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Enabled { get; set; } 


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Multimedios.Models
{
    public class error
    {
        [Key]
        public int IdErrores { get; set; }

        public string Sentencia { get; set; }

        public string Controller { get; set; }

        public DateTime CreatedAt { get; set; }

        public int idUser { get; set; }

        public bool ExisteUser(int idUser, List<user> listaUsuarios)
        {

            foreach (user user in listaUsuarios)
            {
                if (user.IdUser == idUser)
                {
                    return true; 
                }
            }
            return false;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using API_Multimedios.Models;
namespace API_Multimedios.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        //se crea la propiedad para manejar el contexto de las tablas de base de datos
        public DbSet<auditoria> auditoria { set; get; }
        public DbSet<controller> controller { set; get; }
        public DbSet<menu> menu { set; get; }
        public DbSet<roles> roles { set; get; }
        public DbSet<user> user { set; get; }
        public DbSet<error> error { set; get; }
    }
}

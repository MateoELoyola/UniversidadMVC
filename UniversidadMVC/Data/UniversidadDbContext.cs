using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversidadMVC.Models;
namespace UniversidadMVC.Data
{
    //ACA HABIA QUE AGREGAR ROLE!!!!!!!!!!!!!!!!!!!!!
    public class UniversidadDbContext : IdentityDbContext<Usuario, Role, string>
    {


        public UniversidadDbContext() { }
        public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options) : base(options) { }

      
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Materia> Materias { get; set; }
     
    }

}
    
   


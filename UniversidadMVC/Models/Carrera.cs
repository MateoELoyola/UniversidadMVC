using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadMVC
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }   
        public Carrera() { 
        
      //Hola
        }

    }
}

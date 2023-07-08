using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadMVC
{
    public class Carrera
    {
        [Key]
        //Por alguna razon que no entiendo parece que 
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }   
        public Carrera() { 
            //Codigo Nuevo,probar si funciona.
           // Materias = new List<Materia>();

        }

        //Nunca crea una maldita lista?????????????? Si es asi, estoy trantado de cambiar ALGO QUE NO EXISTE
    /*    public Carrera(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    */
    }
}

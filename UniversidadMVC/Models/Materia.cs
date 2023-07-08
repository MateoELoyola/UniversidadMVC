using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadMVC
{
    
    /*
    public class Materia
    {

        //Por alguna condenada razon, el entity framework no esta creando la id automaticamente 
        //Y APARTE NO ME PERMITE SETEARLA. Pruebo si levantando la base de datos devuelta con este
        //codigo deja de aparecer el error con las listas.
        //Nuevo Codigo
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Id")]
        public virtual Carrera Carrera { get; set; }    

        public virtual List<Inscripcion> Inscriptos { get; set; }  

        public Materia() { 
       
        }    
    }
    */

    //Version ChatGpt

    public class Materia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        /*
        * Cambie esta parte de la entidad, al parecer como estaba antes no existia una
        * relacion entre carrera y materias. Esto lo revisaron con el profesor alguna vez?
        */
        //Parte cambiada debajo
        [ForeignKey("Carrera")]      
        public int CarreraId { get; set; } 

        public virtual Carrera Carrera { get; set; } 

        public virtual List<Inscripcion> Inscriptos { get; set; }

        public Materia() { }
    }



}

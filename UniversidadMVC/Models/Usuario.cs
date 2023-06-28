using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadMVC
{
    public class Usuario:IdentityUser
    {

        public Usuario():base() {
            
        }

        public virtual List<Inscripcion> Inscripciones { get; set; }

    }

   
}

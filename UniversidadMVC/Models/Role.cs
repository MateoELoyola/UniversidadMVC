using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversidadMVC.Models
{

  
    public class Role : IdentityRole
    {
            public Role() : base()
            {

            }
        /*
        public Role(string roleName) : base(roleName)
        {
        }
        */
    }
       
}

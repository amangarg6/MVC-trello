
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTask.Identity
{
    public class ApplicationUser : IdentityUser
    {

     
        [NotMapped]
        public string? Role { get; set; }




    }
}

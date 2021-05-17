using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Database
{
    public class AppUser : IdentityUser
    {

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }



        [Required]
        [DataType(DataType.DateTime)]
        public string BirthDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.ViewModel
{
    public class LoginVeiwModel
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }




        [Required]
        [StringLength(60, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        //[Required]
        //[Display(Name = "Confirm Password")]
        //[Compare("Password")]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }
    }
}

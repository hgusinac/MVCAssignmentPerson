using System.ComponentModel.DataAnnotations;

namespace MVCAssignmentPerson.Models.ViewModel
{
    public class CreateLanguage
    {
        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }

        public CreateLanguage()// 0 constructor
        {

        }
    }
}
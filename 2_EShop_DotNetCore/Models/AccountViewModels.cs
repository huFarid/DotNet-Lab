using System.ComponentModel.DataAnnotations;

namespace Shop_DotNetCore.Models
{

    public class RegisterViewModel
    {
        
        [Required(ErrorMessage ="Please enter the {0}")]
        [MaxLength(300)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter the {0}")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please {0} ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Repeat the password")]
        public string RePassword { get; set; }

    }

}

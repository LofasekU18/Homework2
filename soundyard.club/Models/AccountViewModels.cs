using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace club.soundyard.web.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

    }

    public class RegisterViewModel
    {
        [Display(Name = "Jméno")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Příjmení")]
        [Required]
        [StringLength(50)]
        public string SurName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

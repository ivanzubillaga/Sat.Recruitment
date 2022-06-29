using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Models
{
    public class UserRequest
    {
        [Required(ErrorMessage = "The name is required")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email format error")]
        public string email { get; set; }

        [Required(ErrorMessage = "The address is required")]
        [Display(Name = "Adress")]
        public string address { get; set; }

        [Required(ErrorMessage = "The phone is required")]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Display(Name = "User Type")]
        public string userType { get; set; }

        [Display(Name = "Money")]
        [Range(0, 999999999, ErrorMessage = "Numeric Only")]
        public string money { get; set; }

    }

}

using System.ComponentModel.DataAnnotations;

namespace ConsumeEShoppingAPIApp.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string ?ReTypePassword { get; set; }
        public string Role { get; set; }
    }
}

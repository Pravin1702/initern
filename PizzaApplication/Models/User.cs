using System.ComponentModel.DataAnnotations;

namespace PizzaApplication.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
        public string Role { get; set; }

    }
}

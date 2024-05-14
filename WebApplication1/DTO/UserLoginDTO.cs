using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{


    public class UserLoginDTO
{
        [Required(ErrorMessage = "Please enter your Username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

       
}
}

using System.ComponentModel.DataAnnotations;

namespace API_WEBUI_1.WebUI.DTOs.UserDTOs
{
    public class UserRegisterDTO
    {

        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string UserName{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword{ get; set; }
    }
}

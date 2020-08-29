using System.ComponentModel.DataAnnotations;

namespace TechNinjaz.DigiMenu.Presentation.ModelView
{
    public class UserModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
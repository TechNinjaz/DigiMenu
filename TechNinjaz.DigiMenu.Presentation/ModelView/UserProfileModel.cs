using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechNinjaz.DigiMenu.Presentation.ModelView
{
    public class UserProfileModel : BaseModel
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
    }
}
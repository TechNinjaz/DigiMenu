using System.ComponentModel.DataAnnotations;

namespace TechNinjaz.DigiMenu.Presentation.ModelView
{
    public class MenuCategoryModel : BaseModel
    {
        [Required] public string Name { get; set; }

        public string Description { get; set; }
        public string CategoryImageUrl { get; set; }
    }
}
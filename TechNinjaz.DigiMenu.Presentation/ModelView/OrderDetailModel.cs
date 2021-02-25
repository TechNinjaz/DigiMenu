using System.Collections.Generic;

namespace TechNinjaz.DigiMenu.Presentation.ModelView
{
    public class OrderDetailModel : BaseModel
    {
        public int MenuItemId { get; set; }
        public IReadOnlyList<SelectedOptionModel> SelectedOptions { get; set; }
    }
}
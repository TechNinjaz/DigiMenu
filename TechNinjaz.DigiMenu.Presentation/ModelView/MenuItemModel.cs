namespace TechNinjaz.DigiMenu.Presentation.ModelView
{
    public class MenuItemModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ItemImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int MenuCategoryId { get; set; }
    }
}
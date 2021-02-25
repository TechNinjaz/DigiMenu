using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(MenuItemOption))]
    public class MenuItemOption : BaseEntity
    {
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Price { get; set; }
        public int MenuItemId { get; set; }
    }
}
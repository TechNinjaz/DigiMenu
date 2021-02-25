using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(MenuItem))]
    public class MenuItem : BaseEntity
    {
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        public string ItemImageUrl { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required] [DefaultValue(false)] 
        public bool IsActive { get; set; }
        public int MenuCategoryId { get; set; }
        public virtual IEnumerable<MenuItemOption> MenuItemOptions { get; set; }
    }
}
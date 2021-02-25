using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(MenuCategory))]
    public class MenuCategory : BaseEntity
    {
        [Required] public string Name { get; set; }

        public string Description { get; set; }
        public string CategoryImageUrl { get; set; }
        public virtual IEnumerable<MenuItem> MenuItems { get; set; }
    }
}
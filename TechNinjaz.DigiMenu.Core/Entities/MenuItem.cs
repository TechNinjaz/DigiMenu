using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(MenuItem))]
    public class MenuItem: BaseEntity
    {
        [Required]   
        public string Title { get; set; }
        [Required]   
        public string Description { get; set; }
        [Required]   
        public Decimal Price { get; set; }
        public string ItemImageUrl { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities.OrderEntities
{
    [Table(nameof(OrderStatus))]
    public class OrderStatus : BaseEntity
    {
        [Required]   
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
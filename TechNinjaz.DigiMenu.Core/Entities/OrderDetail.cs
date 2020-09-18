using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(OrderDetail))]
    public class OrderDetail: BaseEntity
    {
        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
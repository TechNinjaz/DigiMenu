using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities.OrderEntities
{
    [Table(nameof(OrderDetail))]
    public class OrderDetail : BaseEntity
    {
        public int MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }
        public virtual IEnumerable<SelectedMenuOption> SelectedOptions { get; set; }
    }
}
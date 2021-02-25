using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNinjaz.DigiMenu.Core.Entities.Identity;

namespace TechNinjaz.DigiMenu.Core.Entities.OrderEntities
{
    [Table(nameof(Order))]
    public class Order : BaseEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderAmount { get; set; }

        [Required]
        [DefaultValue(double.NaN)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")] public decimal GratuityAmount { get; set; }


        public int OrderStatusId { get; set; }

        [ForeignKey("Waiter")] public int? WaiterId { get; set; }

        [ForeignKey("Customer")] public int? CustomerId { get; set; }

        public int? PaymentMethodId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual UserProfile Waiter { get; set; }
        public virtual UserProfile Customer { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual IEnumerable<OrderDetail> OrderedDetails { get; set; }
    }
}
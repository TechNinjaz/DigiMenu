using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(Order))]
    public class Order :BaseEntity
    {
        [Required]   
        public User WaiterId { get; set; }
        public User Customer { get; set; }
        [Required]   
        public OrderStatus Status { get; set; }
        [Required]   
        [DefaultValue(double.NaN)]
        public decimal OrderAmount { get; set; }
        [Required]   
        [DefaultValue(double.NaN)]
        public decimal PaidAmount { get; set; }
        [Required]
        public decimal GratuityAmount => PaidAmount - OrderAmount;
        [Required]   
        public PaymentMethod PaymentMethod { get; set; }
        [Required]
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain.DTO
{
    [Table(nameof(Order))]
    public class Order :IBaseEntity
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]   
        public User WaiterId { get; set; }
        public User Customer { get; set; }
        [Required]   
        public OrderStatus Status { get; set; }
        [Required]   
        [DefaultValue(Double.NaN)]
        public decimal OrderAmount { get; set; }
        [Required]   
        [DefaultValue(Double.NaN)]
        public decimal PaidAmount { get; set; }
        [Required]   
        public decimal GratuityAmount => PaidAmount - OrderAmount;
        [Required]   
        public PaymentMethod PaymentMethod { get; set; }
        [Required]
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
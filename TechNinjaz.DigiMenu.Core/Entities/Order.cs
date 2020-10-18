﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(Order))]
    public class Order :BaseEntity
    {
        public User WaiterId { get; set; }
        public User Customer { get; set; }
        [Required]   
        public OrderStatus Status { get; set; }
        [Required]   
        public decimal OrderAmount { get; set; }
        [Required] 
        [DefaultValue(double.NaN)]
        public decimal PaidAmount { get; set; }
        public decimal GratuityAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
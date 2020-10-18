using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TechNinjaz.DigiMenu.Core.Entities;

namespace TechNinjaz.DigiMenu.Presentation.ModelView
{
    public class OrderModel 
    {
        public UserModel WaiterId { get; set; }
        public UserModel Customer { get; set; }
        [Required]   
        public OrderStatus Status { get; set; }
        [Required]   
        public decimal OrderAmount { get; set; }
        [Required] 
        [DefaultValue(double.NaN)]
        public decimal PaidAmount { get; set; }
        public decimal GratuityAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public IEnumerable<OrderDetailModel> OrderDetails { get; set; }
        
    }
}
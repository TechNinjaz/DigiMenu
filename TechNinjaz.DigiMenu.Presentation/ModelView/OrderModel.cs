using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TechNinjaz.DigiMenu.Presentation.ModelView
{
    public class OrderModel : BaseModel
    {
        public int WaiterId { get; set; }
        public int CustomerId { get; set; }
        [Required]   
        public int OrderStatusId { get; set; }
        [Required]   
        public decimal OrderAmount { get; set; }
        [Required] 
        [DefaultValue(double.NaN)]
        public decimal PaidAmount { get; set; }
        public decimal GratuityAmount { get; set; }
        public int? PaymentMethodId { get; set; }
        public IEnumerable<OrderDetailModel> OrderDetails { get; set; }
        
    }
}
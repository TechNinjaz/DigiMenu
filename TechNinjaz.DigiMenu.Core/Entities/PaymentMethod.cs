using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(PaymentMethod))]
    public class PaymentMethod : BaseEntity
    {
        [Required] public string Name { get; set; }

        public string Description { get; set; }
    }
}
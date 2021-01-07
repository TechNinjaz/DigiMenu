using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(Kitchen))]
    public class Kitchen : BaseEntity
    {
        [Required] public OrderDetail OrderDetail { get; set; }

    }
}

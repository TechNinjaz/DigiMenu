using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(Shift))]
    public class Shift : BaseEntity
    {
        [Required] 
        public TimeSpan ShiftStartTime { get; set; }
        [Required] 
        public TimeSpan ShiftEndTime { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
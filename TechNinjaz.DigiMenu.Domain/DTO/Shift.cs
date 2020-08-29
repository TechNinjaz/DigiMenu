using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain.DTO
{
    [Table(nameof(Shift))]
    public class Shift : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]   
        public TimeSpan ShiftStartTime { get; set; }
        [Required]   
        public TimeSpan ShiftEndTime { get; set; }
        [Required]   
        public string Description { get; set; }
    }
}
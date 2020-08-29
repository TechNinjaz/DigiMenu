using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain.DTO
{
    [Table(nameof(StaffUser))]
    public class StaffUser : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]   
        public User Account { get; set; }
        [Required]   
        public string StaffNumber { get; set; }

    }
}
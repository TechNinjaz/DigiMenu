using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain.DTO
{
    [Table(nameof(SittingTable))]
    public class SittingTable : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string TableArea { get; set; }
        [Required]   
        public string TableNumber { get; set; }
       
    }
}
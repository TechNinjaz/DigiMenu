using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain.DTO
{
    [Table(nameof(Menu))]
    public class Menu : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]   
        public string Description { get; set; }
        [Required]   
        public Byte[] CategoryImage { get; set; }
        [Required]   
        public IEnumerable<MenuItem> MenuItems { get; set; }
        
    }
}
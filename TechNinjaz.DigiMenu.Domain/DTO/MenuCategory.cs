using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain.DTO
{
    [Table(nameof(MenuCategory))]
    public class MenuCategory : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]   
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] CategoryImage { get; set; }
        [Required]
        public IEnumerable<MenuItem> MenuItems { get; set; }
        
    }
}
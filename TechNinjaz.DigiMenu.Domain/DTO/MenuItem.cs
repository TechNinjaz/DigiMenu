using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain.DTO
{
    [Table(nameof(MenuItem))]
    public class MenuItem: IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]   
        public Byte[] FoodImage { get; set; }
        [Required]   
        public string ingredient { get; set; }
        [Required]   
        public Decimal Price { get; set; }
        [Required]   
        public Menu Menu { get; set; }
    }
}
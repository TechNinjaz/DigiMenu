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
        public int Id { get; set; }
   
        public Byte[] FoodImage { get; set; }
        [Required]   
        public string Title { get; set; }
        [Required]   
        public string Description { get; set; }
        [Required]   
        public Decimal Price { get; set; }
    }
}
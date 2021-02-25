using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(SittingTable))]
    public class SittingTable : BaseEntity
    {
        [Required] 
        public string TableArea { get; set; }
        [Required] 
        public string TableNumber { get; set; }
    }
}
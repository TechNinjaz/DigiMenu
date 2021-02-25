using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Core.Entities.OrderEntities
{
    [Table(nameof(SelectedMenuOption))]
    public class SelectedMenuOption : BaseEntity
    {
        public string Description { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public interface ISaborProperties : IItemPizzaProperties
    {
        [Key]
        int SaborId { get; set; }
    }
}
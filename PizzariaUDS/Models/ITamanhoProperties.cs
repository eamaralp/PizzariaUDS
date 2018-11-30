using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public interface ITamanhoProperties : IItemPizzaProperties
    {
        [Key]
        int TamanhoId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Tamanho : ItemPizza, ITamanhoProperties
    {
        [Key]
        public int TamanhoId { get; set; }
    }
}
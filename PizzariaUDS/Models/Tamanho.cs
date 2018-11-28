using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Tamanho : ItemPizza
    {
        [Key]
        public int TamanhoId { get; set; }
    }
}
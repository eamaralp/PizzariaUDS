using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Sabor : ItemPizza, ISaborProperties
    {
        [Key]
        public int SaborId { get; set; }
    }
}
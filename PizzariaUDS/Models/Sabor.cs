using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Sabor
    {
        [Key]
        public int SaborId { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public int? MinutosParaProduzir { get; set; }
    }
}

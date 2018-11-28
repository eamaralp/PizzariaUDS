using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Tamanho
    {
        [Key]
        public int TamanhoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int MinutosParaProduzir { get; set; }
    }
}

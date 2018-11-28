namespace PizzariaUDS.Models
{
    public class Pedido
    {
        public Pizza Pizza { get; set; }
        public decimal Valor { get; set; }
        public int MinutosParaProduzir { get; set; }
    }
}

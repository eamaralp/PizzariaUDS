namespace PizzariaUDS.Models
{
    public class Pedido
    {
        public Pizza Pizza { get; set; }
        public decimal ValorTotal { get; set; }
        public int TempoDePreparo { get; set; }
    }
}
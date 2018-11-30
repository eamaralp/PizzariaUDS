using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Pedido : IPedidoProperties
    {
        [Key]
        public int PedidoId { get; set; }
        public Pizza Pizza { get; set; }
        public decimal ValorTotal { get; set; }
        public int TempoDePreparo { get; set; }
    }
}
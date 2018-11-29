namespace PizzariaUDS.Models
{
    public interface IPedidoProperties
    {
        int PedidoId { get; set; }
        Pizza Pizza { get; set; }
        int TempoDePreparo { get; set; }
        decimal ValorTotal { get; set; }
    }
}
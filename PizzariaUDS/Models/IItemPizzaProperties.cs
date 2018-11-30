namespace PizzariaUDS.Models
{
    public interface IItemPizzaProperties
    {
        string Descricao { get; set; }
        int? MinutosParaProduzir { get; set; }
        decimal? Valor { get; set; }
    }
}
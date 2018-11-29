namespace PizzariaUDS.Models
{
    public class ItemPizza : IItemPizzaProperties
    {
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public int? MinutosParaProduzir { get; set; }
    }
}
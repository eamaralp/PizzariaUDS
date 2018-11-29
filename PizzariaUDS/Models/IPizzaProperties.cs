using System.Collections.Generic;

namespace PizzariaUDS.Models
{
    public interface IPizzaProperties
    {
        IEnumerable<Personalizacao> Personalizacoes { get; set; }
        int PizzaId { get; set; }
        Sabor Sabor { get; set; }
        Tamanho Tamanho { get; set; }
    }
}
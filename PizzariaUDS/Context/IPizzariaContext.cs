using Microsoft.EntityFrameworkCore;
using PizzariaUDS.Models;

namespace PizzariaUDS.Context
{
    public interface IPizzariaContext : IDbContext
    {
        DbSet<Pedido> Pedidos { get; set; }
        DbSet<Personalizacao> Personalizacoes { get; set; }
        DbSet<Pizza> Pizzas { get; set; }
        DbSet<Sabor> Sabores { get; set; }
        DbSet<Tamanho> Tamanhos { get; set; }
    }
}
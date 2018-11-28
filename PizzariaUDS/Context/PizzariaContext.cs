using Microsoft.EntityFrameworkCore;
using PizzariaUDS.Models;

namespace PizzariaUDS.Context
{
    public class PizzariaContext : DbContext
    {
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Personalizacao> Personalizacoes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public PizzariaContext(DbContextOptions<PizzariaContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sabor>()
                .HasKey(s => s.SaborId);
            modelBuilder.Entity<Tamanho>()
                .HasKey(t => t.TamanhoId);
            modelBuilder.Entity<Pizza>()
                .HasKey(p => p.PizzaId);
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.PedidoId);
        }
    }
}

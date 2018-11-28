using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        [Required]
        public Tamanho Tamanho { get; set; }
        [Required]
        public Sabor Sabor { get; set; }
        public IEnumerable<Personalizacao> Personalizacoes { get; set; }
    }
}

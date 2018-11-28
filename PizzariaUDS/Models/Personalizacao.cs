using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Personalizacao : ItemPizza
    {
        [Key]
        public int PersonalizacaoId { get; set; }
    }
}
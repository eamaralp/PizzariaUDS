using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Personalizacao : ItemPizza, IPersonalizacaoProperties
    {
        [Key]
        public int PersonalizacaoId { get; set; }
    }
}
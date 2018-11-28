using PizzariaUDS.DTO;
using PizzariaUDS.Models;
using PizzariaUDS.Repository;
using System.Linq;

namespace PizzariaUDS.Business
{
    public class PedidoPizzaBusiness
    {
        private PizzaRepository _pizzaRepository;
        private SaborRepository _saborRepository;
        private TamanhoRepository _tamanhoRepository;
        private PersonalizacaoRepository _personalizacaoRepository;

        public PedidoPizzaBusiness(PizzaRepository pizzaRepository,
                                   SaborRepository saborRepository,
                                   TamanhoRepository tamanhoRepository,
                                   PersonalizacaoRepository personalizacaoRepository)
        {
            _pizzaRepository = pizzaRepository;
            _saborRepository = saborRepository;
            _tamanhoRepository = tamanhoRepository;
            _personalizacaoRepository = personalizacaoRepository;
        }

        public DetalhesPedidoDTO MontarPedido(PedidoDTO pedidoDto)
        {
            new ValidadorPedido().ValidarPedido(pedidoDto);
            var pedido = SalvarPedido(pedidoDto);
            return new DetalhesPedidoDTO();
        }

        private Pedido SalvarPedido(PedidoDTO pedidoDto)
        {
            var pizza = new PizzaBusiness().MontarPizza(pedidoDto);

            CalcularValorTotalPedido(pizza);
            CalcularTempoTotalProducao(pizza);

            var pedido = new Pedido()
            {
                Pizza = pizza,
                ValorTotal = CalcularValorTotalPedido(pizza),
                TempoDePreparo = CalcularTempoTotalProducao(pizza)
            };
            return new Pedido();
        }

        private static decimal CalcularValorTotalPedido(Pizza pizza)
        {
            var valorTotal = pizza.Sabor.Valor.GetValueOrDefault()
                           + pizza.Tamanho.Valor.GetValueOrDefault()
                           + pizza.Personalizacoes.Sum(x => x.Valor.GetValueOrDefault());

            return valorTotal;
        }

        private static int CalcularTempoTotalProducao(Pizza pizza)
        {
            var tempoTotalProducao = pizza.Sabor.MinutosParaProduzir.GetValueOrDefault()
                                   + pizza.Tamanho.MinutosParaProduzir.GetValueOrDefault()
                                   + pizza.Personalizacoes.Sum(x => x.MinutosParaProduzir.GetValueOrDefault());

            return tempoTotalProducao;
        }

    }
}
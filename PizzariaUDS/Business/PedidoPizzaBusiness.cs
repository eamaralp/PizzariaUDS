using PizzariaUDS.DTO;
using PizzariaUDS.Models;
using PizzariaUDS.Repository;
using System;
using System.Linq;
using System.Transactions;

namespace PizzariaUDS.Business
{
    public class PedidoPizzaBusiness : IPedidoPizzaBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPizzaBusiness _pizzaBusiness;

        public PedidoPizzaBusiness(IPedidoRepository pedidoRepository, IPizzaBusiness pizzaBusiness)
        {
            _pedidoRepository = pedidoRepository;
            _pizzaBusiness = pizzaBusiness;
        }

        public Pedido MontarPedido(PedidoDTO pedidoDto)
        {
            new ValidadorPedido().ValidarPedido(pedidoDto);

            using (var scope = new TransactionScope())
            {
                try
                {
                    return SalvarPedido(pedidoDto); 
                }
                catch (Exception exception)
                {
                    scope.Dispose();
                    throw exception;
                }
            }
        }

        private Pedido SalvarPedido(PedidoDTO pedidoDto)
        {
            var pizza = _pizzaBusiness.MontarPizza(pedidoDto);

            CalcularValorTotalPedido(pizza);
            CalcularTempoTotalProducao(pizza);

            var pedido = new Pedido()
            {
                Pizza = pizza as Pizza,
                ValorTotal = CalcularValorTotalPedido(pizza),
                TempoDePreparo = CalcularTempoTotalProducao(pizza)
            };

            _pedidoRepository.SalvarPedido(pedido);

            return pedido;
        }

        private static decimal CalcularValorTotalPedido(IPizzaProperties pizza)
        {
            var valorTotal = pizza.Sabor.Valor.GetValueOrDefault()
                           + pizza.Tamanho.Valor.GetValueOrDefault()
                           + Convert.ToDecimal(pizza.Personalizacoes?.Sum(x => x.Valor.GetValueOrDefault()));

            return valorTotal;
        }

        private static int CalcularTempoTotalProducao(IPizzaProperties pizza)
        {
            var tempoTotalProducao = pizza.Sabor.MinutosParaProduzir.GetValueOrDefault()
                                   + pizza.Tamanho.MinutosParaProduzir.GetValueOrDefault()
                                   + Convert.ToInt16(pizza.Personalizacoes?.Sum(x => x.MinutosParaProduzir.GetValueOrDefault()));

            return tempoTotalProducao;
        }
    }
}
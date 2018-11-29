using PizzariaUDS.Context;
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
        private IPedidoRepository _pedidoRepository;
        private IPizzaBusiness _pizzaBusiness;
        private IPizzariaContext _pizzariaContext;

        public PedidoPizzaBusiness(IPedidoRepository pedidoRepository, IPizzaBusiness pizzaBusiness, IPizzariaContext pizzariaContext)
        {
            _pedidoRepository = pedidoRepository;
            _pizzaBusiness = pizzaBusiness;
            _pizzariaContext = pizzariaContext;
        }

        public Pedido MontarPedido(PedidoDTO pedidoDto)
        {
            new ValidadorPedido().ValidarPedido(pedidoDto);

            using (var scope = new TransactionScope())
            {
                try
                {
                    SalvarPedido(pedidoDto);

                    scope.Complete();
                }
                catch (Exception exception)
                {
                    scope.Dispose();
                    throw exception;
                }
            }

            return SalvarPedido(pedidoDto);
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
                           + pizza.Personalizacoes.Sum(x => x.Valor.GetValueOrDefault());

            return valorTotal;
        }

        private static int CalcularTempoTotalProducao(IPizzaProperties pizza)
        {
            var tempoTotalProducao = pizza.Sabor.MinutosParaProduzir.GetValueOrDefault()
                                   + pizza.Tamanho.MinutosParaProduzir.GetValueOrDefault()
                                   + pizza.Personalizacoes.Sum(x => x.MinutosParaProduzir.GetValueOrDefault());

            return tempoTotalProducao;
        }
    }
}
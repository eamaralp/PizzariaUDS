﻿using PizzariaUDS.DTO;
using PizzariaUDS.Exceptions;
using PizzariaUDS.Models;
using PizzariaUDS.Repository;

namespace PizzariaUDS.Business
{
    public class PedidoPizzaBusiness
    {
        private PizzaRepository _pizzaRepository;
        private SaborRepository _saborRepository;
        private TamanhoRepository _tamanhoRepository;


        public PedidoPizzaBusiness(PizzaRepository pizzaRepository, SaborRepository saborRepository, TamanhoRepository tamanhoRepository)
        {
            _pizzaRepository = pizzaRepository;
            _saborRepository = saborRepository;
            _tamanhoRepository = tamanhoRepository;
        }

        public Pedido MontarPedido(PedidoDTO pedido)
        {
            ValidarPedido(pedido);
            var pizza = SalvarPedido(pedido);
            return new Pedido { MinutosParaProduzir = 15 };
        }

        private Pizza SalvarPedido(PedidoDTO pedido)
        {
            var pizza = new Pizza() { Sabor = _saborRepository.ObterSaborPorId(pedido.SaborId),
                                      Tamanho = _tamanhoRepository.ObterTamanhoPorId(pedido.TamanhoId) };
            return _pizzaRepository.SalvarPedido(pizza);
        }

        private void ValidarPedido(PedidoDTO pedido)
        {
            if (pedido.SaborId.Equals(0))
                throw new BusinessExcpetion("O código do sabor é obrigatório.");
            if (pedido.TamanhoId.Equals(0))
                throw new BusinessExcpetion("O código do tamaho é obrigatório.");
        }

    }
}
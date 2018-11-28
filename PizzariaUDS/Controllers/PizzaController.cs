using Microsoft.AspNetCore.Mvc;
using PizzariaUDS.Business;
using PizzariaUDS.DTO;
using PizzariaUDS.Models;
using PizzariaUDS.Repository;
using System.Collections.Generic;

namespace PizzariaUDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private SaborRepository _saborRepository;
        private TamanhoRepository _tamanhoRepository;
        private PedidoPizzaBusiness _pedidoPizzaBusines;

        public PizzaController(SaborRepository saborRepository, TamanhoRepository tamanhoRepository, PedidoPizzaBusiness pedidoPizzaBusines)
        {
            _saborRepository = saborRepository;
            _tamanhoRepository = tamanhoRepository;
            _pedidoPizzaBusines = pedidoPizzaBusines;
        }

        [Route("Tamanhos")]
        [HttpGet]
        public IEnumerable<Tamanho> ObterTamanhos()
        {
            return _tamanhoRepository.ObterTamanhos();
        }

        [Route("Sabores")]
        [HttpGet]
        public IEnumerable<Sabor> ObterSabores()
        {
            return _saborRepository.ObterSabores();
        }

        [Route("montar")]
        [HttpPost]
        public Pedido MontarPedido([FromBody] PedidoDTO pedido)
        {
            return _pedidoPizzaBusines.MontarPedido(pedido);
        }

    }
}

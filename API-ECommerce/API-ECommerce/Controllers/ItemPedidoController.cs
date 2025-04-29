using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private IItemPedidoRepository _itemPedidoRepository;
        //ctor (tab)
        //Método Construtor
        //Quando crir um objeto o que eu preciso ter?
        public ItemPedidoController(IItemPedidoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
        }
        [HttpGet]
        public IActionResult ListarPedido()
        {
            return Ok(_itemPedidoRepository.ListarTodos());
        }
        //Cadastrar Produto
        [HttpPost]
        public IActionResult CadastrarPedido(ItemPedido ped)
        {
            //1-Coloco o Produto no Banco de Dados
            _itemPedidoRepository.Cadastrar(ped);
            //2-Retorno o resutado
            //201-Created
            return Created();
        }
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            ItemPedido pedido = _itemPedidoRepository.BuscarPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _itemPedidoRepository.Deletar(id);
                return NoContent();
            }
            //caso der erro 
            catch (Exception ex)
            {
                return NotFound("Pedido não encontrado");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Editar(int id, ItemPedido ped)
        {
            try
            {
                _itemPedidoRepository.Atualizar(id, ped);
                return Ok(ped);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }
    }
}

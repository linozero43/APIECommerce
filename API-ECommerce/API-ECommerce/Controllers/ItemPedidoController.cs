using API_ECommerce.Context;
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
        public ItemPedidoController(ItemPedidoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
        }
        [HttpGet]
        public IActionResult ListarPedido()
        {
            return Ok(_itemPedidoRepository.ListarTodos());
        }
        //Cadastrar Produto
        
        
    }
}

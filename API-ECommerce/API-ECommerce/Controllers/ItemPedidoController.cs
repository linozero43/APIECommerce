using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IItemPedidoRepository _itemPedidoRepository;

        //ctor (tab)
        //Método Construtor
        //Quando crir um objeto o que eu preciso ter?
        public ItemPedidoController(EcommerceContext context)
        {
            _context = context;
            _itemPedidoRepository = new ItemPedidoRepository(_context);
        }
       
    }
}

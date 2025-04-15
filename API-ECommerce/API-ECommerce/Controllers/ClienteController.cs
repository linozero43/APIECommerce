using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;
        //ctor (tab)
        //Método Construtor
        //Quando crir um objeto o que eu preciso ter?
        public ClienteController(ClienteRepository clienteRepository)
        {
            _clienteRepository =clienteRepository;
        }
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }
       
    }
}

using API_ECommerce.Interfaces;
using API_ECommerce.Models;
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
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }
        [HttpPost]
        public IActionResult CadastrarPagamento(Cliente cli)
        {
            //1-Coloco o Produto no Banco de Dados
            _clienteRepository.Cadastrar(cli);
            //2-Retorno o resutado
            //201-Created
            return Created();
        }
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Cliente cliente = _clienteRepository.BuscarPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _clienteRepository.Deletar(id);
                return NoContent();
            }
            //caso der erro 
            catch (Exception ex)
            {
                return NotFound("Cliente não encontrado");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Cliente cli)
        {
            try
            {
                _clienteRepository.Atualizar(id, cli);
                return Ok(cli);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }
    }
}

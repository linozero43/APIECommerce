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
    public class PedidoController : ControllerBase
    {
        private IPedidoRepository _pedidoRepository;
        //ctor (tab)
        //Método Construtor
        //Quando crir um objeto o que eu preciso ter?
        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult ListarPedidos()
        {
            return Ok(_pedidoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarPedido(CadastrarPedidoDTO ped)
        {
            //1-Coloco o Produto no Banco de Dados
            _pedidoRepository.Cadastrar(ped);
            //2-Retorno o resutado
            //201-Created
            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _pedidoRepository.Deletar(id);
                return NoContent();
            }
            //caso der erro 
            catch (Exception ex)
            {
                return NotFound("Pedido não encontrado");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Pedido ped)
        {
            try
            {
                _pedidoRepository.Atualizar(id, ped);
                return Ok(ped);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

    }
}

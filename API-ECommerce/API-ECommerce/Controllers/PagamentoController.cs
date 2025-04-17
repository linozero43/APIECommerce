using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private IPagamentoRepository _pagamentoRepository;
        //ctor (tab)
        //Método Construtor
        //Quando crir um objeto o que eu preciso ter?
        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }
        //1-Definir o Verbo
        [HttpGet]
        public IActionResult ListarPagamentos()
        {
            return Ok(_pagamentoRepository.ListarTodos());
        }
        [HttpPost]
        public IActionResult CadastrarPagamento(Pagamento pag)
        {
            //1-Coloco o Produto no Banco de Dados
            _pagamentoRepository.Cadastrar(pag);
            //2-Retorno o resutado
            //201-Created
            return Created();
        }
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Pagamento pagamento = _pagamentoRepository.BuscarPorId(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            return Ok(pagamento);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _pagamentoRepository.Deletar(id);
                return NoContent();
            }
            //caso der erro 
            catch (Exception ex)
            {
                return NotFound("Pagamento não encontrado");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Editar(int id, Pagamento pag)
        {
            try
            {
                _pagamentoRepository.Atualizar(id, pag);
                return Ok(pag);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        } 
    }
}

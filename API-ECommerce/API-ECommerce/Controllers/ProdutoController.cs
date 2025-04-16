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
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _produtoRepository;

        //injeção de dependencia - avisa o c# que o controle depende de um repository
        public ProdutoController(IProdutoRepository produtoRepository)
        {
             _produtoRepository = produtoRepository;
        }
        // GET - Todo metodo que traz uma informação 
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }
        //Cadastrar Produto
        [HttpPost]
        public IActionResult CadastrarProduto(Produto prod)
        {
            //1-Coloco o Produto no Banco de Dados
            _produtoRepository.Cadastrar(prod);           
            //2-Retorno o resutado
            //201-Created
            return Created();
        }
        // Buscar Produto por Id
        // /api/produto
        // /api/produto/1
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Produto produto = _produtoRepository.BuscarPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);
                return NoContent();
            }
            //caso der erro 
            catch (Exception ex)
            {
                return NotFound("Produto não encontrado");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Editar(int id, Produto prod) 
        {
            try
            {
                _produtoRepository.Atualizar(id, prod);
                return Ok(prod);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }
    }
}

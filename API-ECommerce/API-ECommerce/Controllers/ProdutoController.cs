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
    }
}

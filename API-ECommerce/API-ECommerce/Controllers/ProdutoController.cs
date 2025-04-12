﻿using API_ECommerce.Context;
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
        private readonly EcommerceContext _context;
        private IProdutoRepository _produtoRepository;

        //ctor (tab)
        //Método Construtor
        //Quando crir um objeto o que eu preciso ter?
        public ProdutoController(EcommerceContext context)
        {
            _context = context;
            _produtoRepository = new ProdutoRepository(_context);
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
            //2-Salvo a Alteração
            _context.SaveChanges();
            //3-Retorno o resutado
            //201-Created
            return Created();
        }
    }
}

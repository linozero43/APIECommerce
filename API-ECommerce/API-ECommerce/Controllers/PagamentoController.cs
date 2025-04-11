using API_ECommerce.Context;
using API_ECommerce.Interfaces;
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
        private readonly EcommerceContext _context;
        private IPagamentoRepository _pagamentoRepository;

        //ctor (tab)
        //Método Construtor
        //Quando crir um objeto o que eu preciso ter?
        public PagamentoController(EcommerceContext context)
        {
            _context = context;
            _pagamentoRepository = new PagamentoRepository(_context);
        }
       
    }
}

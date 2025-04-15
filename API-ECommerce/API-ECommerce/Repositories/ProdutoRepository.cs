using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //Dentro do Repositorio ficam os metodos que acessam o Banco de Dados
        //Injetar o Context
        //Injeção de Dependencia
        private readonly EcommerceContext _context;

        //ctor (tab)
        //Método Construtor
        //Quando crir um objeto o que eu preciso ter?
        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
           _context.Produtos.Add(produto);
           _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}

using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

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
            //Encontro o produto que desejo
            Produto produtoencontrado = _context.Produtos.Find(id);
            if (produtoencontrado == null)
            {
                throw new Exception();
            }
            produtoencontrado.Nome = produto.Nome;
            produtoencontrado.Descricao = produto.Descricao;
            produtoencontrado.Preco = produto.Preco;
            produtoencontrado.Categoria = produto.Categoria;
            produtoencontrado.Imagem = produto.Imagem;
            produtoencontrado.EstoqueDisponivel = produto.EstoqueDisponivel;
            
            _context.SaveChanges();

        }

        public Produto BuscarPorId(int id)
        {
            //to list() - Pegar varios
            //ExpressoLambda
            //_context.produtos - Acesse a tabela Produto no contexto
            //FirstOrDefault -  pegue o primeiro que encontrar
            //p=>p.IdProduto == id - para cada produto P, me retorne aquele que tem o IdProduto igual ao id
            return _context.Produtos.FirstOrDefault(produto => produto.IdProduto == id);
        }

        public void Cadastrar(Produto produto)
        {
           _context.Produtos.Add(produto);
           _context.SaveChanges();
        }

        public void Deletar(int id)
        {   
            // 1- Encontrar o que eu quero excluir
            // Find - Procura pela chave primeiro
            Produto produtoencontrado = _context.Produtos.Find(id);
            // Caso não encontre o produto, lanço um erro
            if (produtoencontrado == null)
            {
                throw new Exception();
            }
            // Caso eu encontre o produto, removo ele
            _context.Produtos.Remove(produtoencontrado);
            _context.SaveChanges();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}

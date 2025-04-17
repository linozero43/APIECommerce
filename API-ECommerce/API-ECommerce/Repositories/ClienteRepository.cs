using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EcommerceContext _context;

        public  ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Cliente cliente)
        {
            Cliente clienteencontrado = _context.Clientes.Find(id);
            if (clienteencontrado == null)
            {
                throw new Exception();
            }
            clienteencontrado.NomeCompleto = cliente.NomeCompleto;
            clienteencontrado.Telefone = cliente.Telefone;
            clienteencontrado.Pedidos = cliente.Pedidos;
            clienteencontrado.Endereco = cliente.Endereco;
            clienteencontrado.Email = cliente.Email;
            clienteencontrado.IdCliente = cliente.IdCliente;
            clienteencontrado.DataCadastro = cliente.DataCadastro;

            _context.SaveChanges();
        }

        public Cliente BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(Cliente => Cliente.IdCliente == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // 1- Encontrar o que eu quero excluir
            // Find - Procura pela chave primeiro
            Cliente cliente = _context.Clientes.Find(id);
            // Caso não encontre o produto, lanço um erro
            if (cliente == null)
            {
                throw new Exception();
            }
            // Caso eu encontre o produto, removo ele
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}

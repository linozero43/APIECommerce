using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Services;
using API_ECommerce.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EcommerceContext _context;

        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Cliente cliente)
        {
            Cliente clienteencontrado = _context.Clientes.Find(id);
            if (clienteencontrado == null)
            {
                throw new ArgumentNullException("Cliente não Encontrado");
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

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            //Where - Traz todos que atendem EXATAMENTE uma Condição 
            var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();
            return listaClientes;
        }

        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            //Encontrar o cliente que possui o email e senha fornecidos
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);

            return clienteEncontrado;
        }


        public Cliente BuscarPorId(int id)
        {
            //Qualquer metodo que vai me trazer apenas 1 cliente - FirsOsDefault
            return _context.Clientes.FirstOrDefault(Cliente => Cliente.IdCliente == id);
        }

        public void Cadastrar(CadastrarClienteDTO cliente)
        {
            var passwordService = new PasswordService();

            Cliente novoCliente = new Cliente
            {
                NomeCompleto = cliente.NomeCompleto,
                Endereco = cliente.Endereco,
                Email = cliente.Email,
                Senha = cliente.Senha,
                Telefone = cliente.Telefone,
            };

            novoCliente.Senha = passwordService.HashPassword(novoCliente);

            _context.Clientes.Add(novoCliente);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // 1- Encontrar o que eu quero excluir
            // FirstOrDefault - Pesquisa por qualquer campo
            // Find - Procura pela chave primaria (ID)
            Cliente cliente = _context.Clientes.Find(id);
            // Caso não encontre o produto, lanço um erro
            if (cliente == null)
            {
                throw new ArgumentNullException("Cliente não encontrado");
            }
            // Caso eu encontre o produto, removo ele
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public List<ListarClienteViewModel> ListarTodos()
        {
            //SELECT - permite que eu selecione quais campos eu quero pegar
            return _context.Clientes.Select(c => new ListarClienteViewModel
            {
                IdCliente = c.IdCliente,
                NomeCompleto= c.NomeCompleto,
                Email = c.Email,
                DataCadastro = c.DataCadastro,
                Endereco= c.Endereco,
                Telefone= c.Telefone,

            }).ToList();
        }

        
    }
}

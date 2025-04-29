using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceContext _context;

        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pedido pedido)
        {
            Pedido pedidonovo = _context.Pedidos.Find(id);
            if (pedido == null)
            {
                throw new Exception();
            }
            pedidonovo.Status = pedido.Status;
            pedidonovo.DataPedido = pedido.DataPedido;
            pedidonovo.ValorTotal = pedido.ValorTotal;


            _context.SaveChanges();
        }

        public Pedido BuscarPorId(int id)
        {
            return _context.Pedidos.FirstOrDefault(ped => ped.IdPedido == id);
        }

        public void Cadastrar(CadastrarPedidoDTO pedido)
        {
            var ped = new Pedido
            {
                DataPedido = pedido.DataPedido,
                Status = pedido.Status,
                IdCliente = pedido.IdCliente,
                ValorTotal = pedido.ValorTotal,
            };
            _context.Pedidos.Add(ped);
            _context.SaveChanges();
            //Cadastrar os ItensPedidos
            //Para cada PRODUTO, eu crio um ItemPedido
            for (int i = 0; i < pedido.Produtos.Count; i++)
            {
                // Encontra o Produto
                var produto = _context.Produtos.Find(pedido.Produtos[i]);

                //TODO: Lançar erro se produto não existe

                // Crio uma variavel ItemPedido
                var itemPedido = new ItemPedido
                {
                    IdPedido = ped.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0
                };

                _context.ItemPedidos.Add(itemPedido);
                _context.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            Pedido pedido = _context.Pedidos.Find(id);
            // Caso não encontre o produto, lanço um erro
            if (pedido == null)
            {
                throw new Exception();
            }
            // Caso eu encontre o produto, removo ele
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.Include(p => p.ItemPedidos).ThenInclude(p => p.Produto).ToList();
        }
    }
}

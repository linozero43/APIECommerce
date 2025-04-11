using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly ItemPedido _context;

        public ItemPedidoRepository (EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, ItemPedido itemPedido)
        {
            throw new NotImplementedException();
        }

        public ItemPedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemPedido> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

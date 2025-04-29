using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly EcommerceContext _context;

        public ItemPedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, ItemPedido itemPedido)
        {
            ItemPedido itped = _context.ItemPedidos.Find(id);
            if (itped == null)
            {
                throw new Exception();
            }
            itped.Quantidade = itemPedido.Quantidade;
            itped.IdPedido = itemPedido.IdPedido;
            itped.IdProduto = itemPedido.IdProduto;            

            _context.SaveChanges(); ;
        }

        public ItemPedido BuscarPorId(int id)
        {
            return _context.ItemPedidos.FirstOrDefault(pag => pag.IdPedido == id);
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            _context.ItemPedidos.Add(itemPedido);
        }

        public void Deletar(int id)
        {
            ItemPedido itemPedido = _context.ItemPedidos.Find(id);
            // Caso não encontre o produto, lanço um erro
            if (itemPedido == null)
            {
                throw new Exception();
            }
            // Caso eu encontre o produto, removo ele
            _context.ItemPedidos.Remove(itemPedido);
            _context.SaveChanges();
        }

        public List<ListarItemPedidoViewModel> ListarTodos()
        {
            //SELECT - permite que eu selecione quais campos eu quero pegar
            return _context.ItemPedidos.Select(c => new ListarItemPedidoViewModel
            {
                IdItemPedido = c.IdItemPedido,
                IdPedido = c.IdPedido,
                IdProduto = c.IdProduto,
                Quantidade = c.Quantidade

            }).ToList();
        }
    }
}

using API_ECommerce.Models;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces
{
    public interface IItemPedidoRepository
    {
        //Retorno - R - Read(Leitura)
        List<ListarItemPedidoViewModel> ListarTodos();

        //Recebe um identificador e retorna o produto correspondente 
        ItemPedido BuscarPorId(int id);

        //C - Create (Cadastro)
        void Cadastrar(ItemPedido itemPedido);

        //U - Update(Atualização)
        //Recebe um identificador para encontrar o Produto Novo para substituir o Antigo
        void Atualizar(int id, ItemPedido itemPedido);

        //D - Delete (Deletar)
        //Recebo o Identificador de quem quero excluir
        void Deletar(int id);
    }
}

using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IPedidoRepository
    {
        //Retorno - R - Read(Leitura)
        List<Pedido> ListarTodos();

        //Recebe um identificador e retorna o produto correspondente 
        Pedido BuscarPorId(int id);

        //C - Create (Cadastro)
        void Cadastrar(Pedido pedido);

        //U - Update(Atualização)
        //Recebe um identificador para encontrar o Produto Novo para substituir o Antigo
        void Atualizar(int id, Pedido pedido);

        //D - Delete (Deletar)
        //Recebo o Identificador de quem quero excluir
        void Deletar(int id);
    }
}

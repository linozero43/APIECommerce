using API_ECommerce.DTO;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IProdutoRepository
    {
        //Retorno - R - Read(Leitura)
        List<Produto> ListarTodos();

        //Recebe um identificador e retorna o produto correspondente 
        Produto BuscarPorId(int id);

        //C - Create (Cadastro)
        void Cadastrar(CadastrarProdutoDTO produto);

        //U - Update(Atualização)
        //Recebe um identificador para encontrar o Produto Novo para substituir o Antigo
        void Atualizar(int id, Produto produto);

        //D - Delete (Deletar)
        //Recebo o Identificador de quem quero excluir
        void Deletar(int id);
    }
}

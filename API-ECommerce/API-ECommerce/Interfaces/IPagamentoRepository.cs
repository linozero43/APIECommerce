using API_ECommerce.DTO;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IPagamentoRepository
    {
        //Retorno - R - Read(Leitura)
        List<Pagamento> ListarTodos();

        //Recebe um identificador e retorna o produto correspondente 
        Pagamento BuscarPorId(int id);

        //C - Create (Cadastro)
        void Cadastrar(CadastrarPagamentoDTO pagamento);

        //U - Update(Atualização)
        //Recebe um identificador para encontrar o Produto Novo para substituir o Antigo
        void Atualizar(int id, Pagamento pagamento);

        //D - Delete (Deletar)
        //Recebo o Identificador de quem quero excluir
        void Deletar(int id);
    }
}

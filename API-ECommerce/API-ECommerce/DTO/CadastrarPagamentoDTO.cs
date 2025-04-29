using API_ECommerce.Models;

namespace API_ECommerce.DTO
{
    public class CadastrarPagamentoDTO
    {
        public int IdPedido { get; set; }

        public string FormaPagamento { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime Data { get; set; }
        
    }
}

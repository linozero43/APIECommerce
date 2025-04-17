using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly EcommerceContext _context;

        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pagamento pag)
        {
            Pagamento pagamento = _context.Pagamentos.Find(id);
            if (pagamento == null)
            {
                throw new Exception();
            }
            pagamento.Status = pag.Status;
            pagamento.Data = pag.Data;
            pagamento.IdPagamento = pag.IdPagamento;
            pagamento.FormaPagamento = pag.FormaPagamento;
            pagamento.IdPedido = pag.IdPedido;

            _context.SaveChanges();

        }

        public Pagamento BuscarPorId(int id)
        {
            return _context.Pagamentos.FirstOrDefault(pag => pag.IdPagamento == id);
        }

        public void Cadastrar(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pagamento pagamento = _context.Pagamentos.Find(id);
            // Caso não encontre o produto, lanço um erro
            if (pagamento == null)
            {
                throw new Exception();
            }
            // Caso eu encontre o produto, removo ele
            _context.Pagamentos.Remove(pagamento);
            _context.SaveChanges();
        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.ToList();
        }
    }
}

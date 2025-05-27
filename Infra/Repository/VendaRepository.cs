using curitibano.microservico.junina.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace curitibano.microservico.junina.Infra.Repository
{
    public class VendaRepository
    {
        private readonly JuninaDbContext _context;

        public VendaRepository(JuninaDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Venda venda)
        {
            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();
        }

        public async Task<Venda?> ObterPorId(int id)
        {
            return await _context.Venda.FindAsync(id);
        }

        public async Task<List<Venda>> ObterTodos()
        {
            return await _context.Venda.Include(v => v.Item).ToListAsync();
        }        
        public async Task<List<Venda>> ObterTodosPorData(DateTime inicio,DateTime fim)
        {
            return await _context.Venda.Include(v => v.Item).Where(o => o.DataVenda.Date.Date >= inicio.Date && o.DataVenda.Date<= fim.Date).ToListAsync();
        }

        public async Task Atualizar(Venda venda)
        {
            _context.Venda.Update(venda);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var venda = _context.Venda.Find(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
                await _context.SaveChangesAsync();
            }
        }
    }
}

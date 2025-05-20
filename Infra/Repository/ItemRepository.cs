using curitibano.microservico.junina.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace curitibano.microservico.junina.Infra.Repository
{
    public class ItemRepository
    {
        private readonly JuninaDbContext _context;

        public ItemRepository(JuninaDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Item item)
        {
             _context.Itens.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Item?> ObterPorId(int id)
        {
            return await _context.Itens.FindAsync(id);
        }

        public async Task<List<Item>> ObterTodos()
        {
            return await _context.Itens.ToListAsync();
        }

        public async Task Atualizar(Item item)
        {
            _context.Itens.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var item = _context.Itens.Find(id);
            if (item != null)
            {
                _context.Itens.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}

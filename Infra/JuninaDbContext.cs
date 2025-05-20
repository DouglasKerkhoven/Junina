using curitibano.microservico.junina.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace curitibano.microservico.junina.Infra
{
    public class JuninaDbContext : DbContext
    {
        public JuninaDbContext(DbContextOptions<JuninaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Itens { get; set; }
        public DbSet<Venda> Venda { get; set; }

    }
}

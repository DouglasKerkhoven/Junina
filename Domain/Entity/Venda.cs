namespace curitibano.microservico.junina.Domain.Entity
{
    public class Venda
    {
        public int Id { get; set; }
        public int ItemId { get; set; }   // chave estrangeira
        public virtual Item Item { get; set; } = null!;
        public DateTime DataVenda { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}

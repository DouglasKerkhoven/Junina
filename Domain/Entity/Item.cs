namespace curitibano.microservico.junina.Domain.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

    }
}

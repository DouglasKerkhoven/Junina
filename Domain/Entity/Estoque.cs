namespace curitibano.microservico.junina.Domain.Entity
{
    public class Estoque
    {

        private List<Item> itens = new List<Item>();

        public void AdicionarItem(Item item)
        {
            itens.Add(item);
        }

        public void AtualizarQuantidade(int id, int quantidadeVendida)
        {
            var item = itens.FirstOrDefault(i => i.Id == id);
            if (item != null && item.Quantidade >= quantidadeVendida)
            {
                item.Quantidade -= quantidadeVendida;
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente ou item não encontrado.");
            }
        }

        public void ListarItens()
        {
            foreach (var item in itens)
            {
                Console.WriteLine($"{item.Descricao} - Qtd: {item.Quantidade} - Valor: {item.Valor:C}");
            }
        }
    }
}

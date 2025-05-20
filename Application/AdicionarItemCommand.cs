using curitibano.microservico.junina.Domain.Entity;
using curitibano.microservico.junina.Infra.Repository;
using MediatR;

namespace curitibano.microservico.junina.Application
{
    public class AdicionarItemCommand : IRequest<Item>
    {

        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

    }

    public class AdicionarItemCommandHandler : IRequestHandler<AdicionarItemCommand, Item>
    {
        private ItemRepository _itemRepository;

        public AdicionarItemCommandHandler(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> Handle(AdicionarItemCommand request, CancellationToken cancellationToken)
        {
            Item item = new Item();
            item.Descricao = request.Descricao;
            item.Valor = request.Valor;
            item.Quantidade = request.Quantidade;
            Estoque estoque = new Estoque();
            estoque.AdicionarItem(item);

            await _itemRepository.Adicionar(item);

            return item;
        }
    }
}

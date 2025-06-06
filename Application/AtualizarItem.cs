using curitibano.microservico.junina.Domain.Entity;
using curitibano.microservico.junina.Infra.Repository;
using MediatR;

namespace curitibano.microservico.junina.Application
{
    public class AtualizarItemCommand : IRequest<Item>
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
    public class AtualizarItemCommandHandler : IRequestHandler<AtualizarItemCommand, Item>
    {
        private ItemRepository _itemRepository;

        public AtualizarItemCommandHandler(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> Handle(AtualizarItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.ObterPorId(request.Id);

            item.Descricao = request.Descricao;
            item.Valor = request.Valor;
            item.Quantidade = request.Quantidade;   
            await _itemRepository.Atualizar(item);
            return item;
        }
    }


}

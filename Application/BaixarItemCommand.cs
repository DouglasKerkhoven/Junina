using curitibano.microservico.junina.Domain.Entity;
using curitibano.microservico.junina.Infra.Repository;
using MediatR;

namespace curitibano.microservico.junina.Application
{
    public class BaixarItemCommand : IRequest<Item>
    {
        public int ItemId { get; set; }
        public int QtdVendida { get; set; }
        public int FormaId { get; set; }
    }
    public class BaixarItemCommandHandler : IRequestHandler<BaixarItemCommand, Item>
    {
        private ItemRepository _itemRepository;
        private VendaRepository _vendaRepository;

        public BaixarItemCommandHandler(ItemRepository itemRepository, VendaRepository vendaRepository)
        {
            _itemRepository = itemRepository;
            _vendaRepository = vendaRepository;
        }

        public async Task<Item> Handle(BaixarItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.ObterPorId(request.ItemId);
            Estoque estoque = new Estoque();
            if (item != null)
            {
                estoque.AdicionarItem(item);
                estoque.AtualizarQuantidade(item.Id, request.QtdVendida);
                await _itemRepository.Atualizar(item);

                Venda venda = new Venda();
                venda.DataVenda = DateTime.Now;
                venda.Quantidade = request.QtdVendida;
                venda.ValorTotal = item.Valor * request.QtdVendida;
                venda.ItemId = item.Id;
                venda.FormaId = request.FormaId;
                await _vendaRepository.Adicionar(venda);

                return item;
            }
            else
            {
                throw new ApplicationException("Item não econtrado");
            }
        }
    }
}

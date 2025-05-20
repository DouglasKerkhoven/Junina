using curitibano.microservico.junina.Application;
using curitibano.microservico.junina.Infra.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curitibano.microservico.junina.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ItemRepository _itemRepository;
        private IMediator _mediator;

        public ItemController(ItemRepository itemRepository, IMediator mediator)
        {
            _itemRepository = itemRepository;
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<ActionResult> PostAdicionarItem(AdicionarItemCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                return BadRequest("Erro ao Inserir item");
            }
        }

        [HttpGet("")]
        public async Task<ActionResult> GetItens()
        {
            var resultado = await _itemRepository.ObterTodos();

            return Ok(resultado);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetItemPorId(int id)
        {
            var resultado = await _itemRepository.ObterPorId(id);

            return Ok(resultado);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteItemPorId(int id)
        {
            await _itemRepository.Remover(id);

            return Ok("Item removido com sucesso");
        }

        [HttpPatch("id/{id}")]
        public async Task<ActionResult> PatchItemPorId(int id)
        {
            var item = await _itemRepository.ObterPorId(id);
            if (item is not null)
                await _itemRepository.Atualizar(item);

            return Ok("Item atualizado");
        }
        [HttpPatch("baixa")]
        public async Task<ActionResult> PatchBaixarItemPorId(BaixarItemCommand command)
        {

            var resultado = await _mediator.Send(command);
            return Ok(resultado);
           
        }


    }
}

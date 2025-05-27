using curitibano.microservico.junina.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curitibano.microservico.junina.Controllers
{
    [Route("api/vendas")]
    [ApiController]
    public class VendasController : ControllerBase
    {

        private VendaRepository _vendaRepository;

        public VendasController(VendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }


        [HttpGet("")]
        public async Task<ActionResult> GetItens()
        {
            var resultado = await _vendaRepository.ObterTodos();

            return Ok(resultado);
        }

        [HttpGet("inicio/{inicio}/fim/{fim}")]
        public async Task<ActionResult> GetItens(DateTime inicio,DateTime fim)
        {
            var resultado = await _vendaRepository.ObterTodosPorData(inicio, fim);

            return Ok(resultado);
        }

    }
}

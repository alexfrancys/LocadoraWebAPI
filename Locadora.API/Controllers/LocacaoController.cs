using Locadora.Application.Commands.CreateLocacao;
using Locadora.Application.Commands.FinalizarLocacao;
using Locadora.Application.Queries.GetLocacaoById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocacaoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Obter Locacao pelo Id
        /// </summary>
        /// <param name="locacaoId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{locacaoId:guid}")]
        public async Task<IActionResult> GetLocacaobyId([FromRoute] Guid locacaoId, CancellationToken cancellationToken)
        {
            var query = new GetLocacaoByIdQueryInput() { Id = locacaoId };

            return Ok(await _mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Nova Locacao
        /// </summary>
        /// <param name="locacao"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("cadastro")]
        public async Task<IActionResult> CreateLocacao([FromBody] CreateLocacaoCommandInput locacao, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(locacao, cancellationToken);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Finalizar Locacao
        /// </summary>
        /// <param name="locacaoId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("devolucao/{locacaoId=guid}")]
        public async Task<IActionResult> DevolucaoLocacao([FromRoute] Guid locacaoId, CancellationToken cancellationToken)
        {
            var command = new FinalizarLocacaoCommandInput() { Id = locacaoId };

            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}

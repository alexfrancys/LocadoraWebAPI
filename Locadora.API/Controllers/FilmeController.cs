using Locadora.Application.Commands.CreateFilme;
using Locadora.Application.Commands.InativarFilme;
using Locadora.Application.Queries.GetFilmeById;
using Locadora.Application.Queries.GetFilmes;
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
    public class FilmeController : ControllerBase
    {
        private IMediator _mediator;

        public FilmeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Cadastrar novo Filme
        /// </summary>
        /// <param name="filme"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("cadastro")]
        public async Task<IActionResult> CreateFilme([FromBody] CreateFilmeCommandInput filme, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(filme, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Inativar Filme
        /// </summary>
        /// <param name="filmeId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("inativar/{filmeId:guid}")]
        public async Task<IActionResult> InativarFilme([FromRoute] Guid filmeId, CancellationToken cancellationToken)
        {
            var result = new InativarFilmeCommandInput() { Id = filmeId };

            return Ok(await _mediator.Send(result, cancellationToken));
        }

        /// <summary>
        /// Obter todos os Filmes
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("filmes")]
        public async Task<IActionResult> GetFilmes([FromQuery] GetFilmesQueryInput query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Obter Filme pelo Id
        /// </summary>
        /// <param name="filmeId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{filmeId:guid}")]
        public async Task<IActionResult> GetFilmeById([FromRoute] Guid filmeId, CancellationToken cancellationToken)
        {
            var query = new GetFilmesByIdQueryInput()
            {
                Id = filmeId
            };

            return Ok(await _mediator.Send(query));
        }

    }
}

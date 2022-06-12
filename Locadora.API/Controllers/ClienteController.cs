using Locadora.Application.Commands.CreateCliente;
using Locadora.Application.Commands.InativarCliente;
using Locadora.Application.Queries.GetClientes;
using Locadora.Application.Queries.GetClientesById;
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
    public class ClienteController : ControllerBase
    {
        readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Cadastrar novo Cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("cadastro")]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteCommandInput cliente, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(cliente, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Inativar Cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("inativar/{clienteId:guid}")]
        public async Task<IActionResult> InativarCliente([FromRoute] Guid clienteId, CancellationToken cancellationToken)
        {
            var result = new InativaClienteCommandInput() { Id = clienteId };

            return Ok(await _mediator.Send(result));
        }

        /// <summary>
        /// Obter Cliente pelo Id
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{clienteId:guid}")]
        public async Task<IActionResult> GetClienteById([FromRoute] Guid clienteId, CancellationToken cancellationToken)
        {
            var query = new GetClienteByIdQueryInput() { Id = clienteId };

            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Obter todos os clientes
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetClientes([FromQuery] GetClientesQueryInput query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}

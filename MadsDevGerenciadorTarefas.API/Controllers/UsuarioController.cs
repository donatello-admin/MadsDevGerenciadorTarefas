using MadsDevGerenciadorTarefas.Application.Commands.CreateUsuario;
using MadsDevGerenciadorTarefas.Application.Commands.UpdateUsuario;
using MadsDevGerenciadorTarefas.Application.Queries.GetAllUsuario;
using MadsDevGerenciadorTarefas.Application.Queries.GetByIdUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MadsDevGerenciadorTarefas.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllUsuarioQuery = new GetAllUsuarioQuery(query);
            var usuarios = await _mediator.Send(getAllUsuarioQuery);

            return Ok(usuarios);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == null)
                return NotFound();

            var getUsuarioByIdQuery = new GetUsuarioByIdQuery(id);

            var usuario = await _mediator.Send(getUsuarioByIdQuery);

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioCommand usuarioCommand)
        {
            if (usuarioCommand == null)
            {
                return NotFound();
            }

            var id = await _mediator.Send(usuarioCommand);

            return CreatedAtAction(nameof(GetById), new { id = id }, usuarioCommand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateUsuarioCommand usuarioCommand)
        {
           var updateUsuarioCommand = await _mediator.Send(usuarioCommand);

            if (updateUsuarioCommand == null)
                return NotFound();

            return Ok(updateUsuarioCommand);
        }

        // DELETE api/<TarefaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

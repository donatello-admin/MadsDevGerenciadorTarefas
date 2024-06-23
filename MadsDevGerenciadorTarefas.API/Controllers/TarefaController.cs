using MadsDevGerenciadorTarefas.Application.Commands.CreateTarefa;
using MadsDevGerenciadorTarefas.Application.Commands.UpdateTarefa;
using MadsDevGerenciadorTarefas.Application.Commands.UpdateTarefaFinish;
using MadsDevGerenciadorTarefas.Application.Queries.GetAllTarefa;
using MadsDevGerenciadorTarefas.Application.Queries.GetByIdTarefa;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MadsDevGerenciadorTarefas.API.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TarefaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<TarefaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getTarefaById = new GetTarefaByIdQuery(id);

           var tarefa =  await _mediator.Send(getTarefaById);

            return Ok(tarefa);
        }

        // POST api/<TarefaController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTarefaCommand createTarefaCommand)
        {
            var id = await _mediator.Send(createTarefaCommand);

            return CreatedAtAction(nameof(GetById), new { id = id }, createTarefaCommand);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllTarefaQuery = new GetAllTarefaQuery(query);
            var tarefas = await _mediator.Send(getAllTarefaQuery);

            return Ok(tarefas);
        }

        // PUT api/<TarefaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTarefaCommand updateTarefaCommand)
        {
            var updateTarefa = await _mediator.Send(updateTarefaCommand);

            return Ok(updateTarefa);
        }

        [HttpPut()]
        public async Task<IActionResult> FinishTarefa(int id, [FromBody] UpdateTarefaFinishCommand updateTarefaCommand)
        {
            var updateTarefa = await _mediator.Send(updateTarefaCommand);

            return Ok(updateTarefa);
        }

        // DELETE api/<TarefaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

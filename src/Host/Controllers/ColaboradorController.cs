using ApplicationCore.Commands.ColaboradorCommand;
using ApplicationCore.Interfaces;
using Infraestructure.EventHandlers.ColaboradorHandler;
using Infraestructure.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/Colaborador")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService _service;
        private readonly IMediator _mediator;

        public ColaboradorController(IColaboradorService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet("get-colaboradores")]
        public async Task<IActionResult> GetAll()
        {
            var colaboradores = await _service.GetAllAsync();
            return Ok(colaboradores);
        }

        [HttpGet("get-colaborador/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var colaborador = await _service.GetByIdAsync(id);
            return colaborador == null ? NotFound() : Ok(colaborador);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateColaboradorCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateColaboradorCommand command)
        {
            command.id_Colaborador = id;
            var response = await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id, DeleteColaboradorCommand command)
        {
            command.id_Colaborador = id;
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}

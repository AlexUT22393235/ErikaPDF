using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;
using MediatR;
using ApplicationCore.Wrappers;
using ApplicationCore.Commands;

namespace Host.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiantesService _service;
        private readonly IMediator _mediator;

        public EstudiantesController(IEstudiantesService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        // <sumary>
        // Lisra de usuarios get
        // </sumary>

        [Route("get-estudiantes")]
        [HttpGet]

        public async Task<IActionResult> GetEstudiantes()
        {
            var result = await _service.GetEstudiantes();
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Response<int>>> CreateEstudiante(EstudianteCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("delete/{id}")]
        public async Task<ActionResult<Response<int>>> DeleteEstudiante([FromRoute] int id)
        {
            var result = await _service.DeleteEstudiante(id);
            return Ok(result);
        }

        [HttpGet("pdf")]
        public async Task<ActionResult> GetPDF()
        {
            var pdfFile = await _service.GetPDF();
            return File(pdfFile, "application/pdf", "Reporte de estudiantes.pdf");
        }
    }
}

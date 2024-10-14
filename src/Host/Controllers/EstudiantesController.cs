using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;

namespace Host.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiantesService _service;

        public EstudiantesController(IEstudiantesService service)
        {
            _service = service;
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
    }
}

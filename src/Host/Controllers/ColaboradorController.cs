using ApplicationCore.Commands.ColaboradorCommand;
using ApplicationCore.Interfaces;
using DevExpress.CodeParser;
using Domain.Entities;
using Infraestructure.EventHandlers.ColaboradorHandler;
using Infraestructure.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Host.Controllers
    // recuerda siempre importar todo
{
    // Creas un espacio para todas las apis que pongas de una misma entidad
    // en este caso "api/Colaborador")
    [Route("api/Colaborador")]
    [ApiController]
    // creas la class del controllado y le asignas el tipo "ControllerBase" eso es propio de .net
    public class ColaboradorController : ControllerBase
    {
        // creas tus variables para poder manipular los servicios
        // esta interface has de cuenta que representa a tu servicio, en ella tienes todos los metodos que debe de llamar al servicio
        // y que tipo de datos espeta
        private readonly IColaboradorService _service;
        // no se que es esto pero es necesario jajajajaj
        private readonly IMediator _mediator;
        // ya vi que hace jajaj es como la forma de comunicarse con tu handler xd

        // este es tu constructor donde inyectas lo que nesitas que es lo mismo que las variables que creas arriba
        // recuerda importar todo
        public ColaboradorController(IColaboradorService service, IMediator mediator)
        {
            // y vacias los servicios en tu variables propias para poder usarlos
            _service = service;
            _mediator = mediator;
        }

        [HttpGet("Get-filters/{type}/{age}")]
        public async Task <IActionResult> GetAllForYear(bool type, int age)
        {
            var colaboradores = await _service.GetAllFiltersAsync(type, age);
            return colaboradores == null ? NotFound() : Ok(colaboradores);
        }

        //[HttpGet("Get-administrators")]
        //public async Task<IActionResult> GetAllProfesors(bool type)
        //{
        //    var colaboradores = await _service.GetAllProfesorsAsync(type);
        //    return colaboradores == null ? NotFound() : Ok(colaboradores);
        //}

        // creando la primera ruta que llamara a tu interface "IColaboradorService", el nombre es como quieras
        // yo le puse "get-colaboradores"
        //[HttpGet("get-colaboradores")]
        //// tipo public async y devuelve un task<IActionResult> este GetAll() es importante y es de .net es el metodo que ya tiene definido
        //public async Task<IActionResult> GetAll()
        //{
        //    // creas tus colaboradores que seran el resultado de la respuesta de la peticion a tu interface osea tu servicio
        //    var colaboradores = await _service.GetAllAsync();
        //    // retornas OK y los colaboradores
        //    return Ok(colaboradores);
        //}

        // creando el traer por id, de igual manera lo llamas como quieras pero importante el {id} es un parametro por lo que si lo cambias
        // igual tienes que cambiar esto GetById(int id) y GetByIdAsync(id); porque ahi es donde le pasas el id serian igual que como le pongas
        [HttpGet("get-colaborador/{id}")]
        // tipo public async y devuelve un task<IActionResult> este GetById(int id) es importante y es de .net es el metodo que ya tiene definido
        public async Task<IActionResult> GetById(int id)
        {
            // creas tu variable que sera la respuesta de tu interface osea tu servicio
            var colaborador = await _service.GetByIdAsync(id);
            // retornas OK y el colaborador o si no tiene nada la variable retornas NotFound() que es propio de .net
            return colaborador == null ? NotFound() : Ok(colaborador);
        }

        // Aqui creas tu endpoint del create, nombre a tu eleccion
        [HttpPost("create")]
        // IMPORTANTE ESTE YA CAMBIA PORQUE YA NO CONSUMES LA INTEFACES DEL SERVICIO, CONSUMES TU COMMAND
        // tipo public async y devuelve un task<IActionResult> y el metodo create que es propio de .net y le pasas el command para esa accion
        // vaciamente haces como una inyeccion de ese command, si te preguntas porque no lo hice hasta arriba como el servicio es porque
        // este solo lo uso una vez, solo es para el create y el servicio lo use al menos 2 veces
        public async Task<IActionResult> Create(CreateColaboradorCommand command)
        {
            // creas una variable donde se vaciara la respuesta de tu _mediator que seria como tu _context para el servicio, solo que en este
            // caso es para tus handlers y el metodo Send que es propio del Mediatory para los handler y le pasas el command
            // Osea en otras palabras el handler vendria a ser tu servicio y el command tu entidad
            // solo que lo que hace el command es que la data que llegue la transforma por eso en el command vaciamos todo
            // para que no haya errores, por eso se usa en operaciones de manipulacion de datos
            var response = await _mediator.Send(command);
            // devuelve un OK y la respuesta que te de el handler
            return Ok(response);
        }

        // Aqui creas tu endpoint del update, nombre a tu eleccion y misma consideracion con el id que en el create
        [HttpPut("update/{id}")]

        // tipo public async y devuelve un task<IActionResult> y el metodo Update que es propio de .net y le pasas el command para esa accion
        public async Task<IActionResult> Update(int id, UpdateColaboradorCommand command)
        {
            // vacias aqui mismo el id de la peticion al id del command, porque recuerda que en la logica del command
            // usamos el mismo id_colaborador que esta ahi para que sepa cual actualizar
            command.id_Colaborador = id;
            // creas tu variable con la respuesta del handler. usas el _mediator para llamar al handler y el metodo "Send" para mandar tu command
            var response = await _mediator.Send(command);
            // retornas un NoContent(), la verdad no se porque eso me lo dio chat jajajaj
            return NoContent();
        }

        // creas el endpoint del delete
        [HttpDelete("delete/{id}")]
        // tipo public async y devuelve un task<IActionResult> y el metodo Delete que es propio de .net y le pasas el id de la peticion
        // junto con el command para esa accion
        public async Task<IActionResult> Delete(int id, DeleteColaboradorCommand command)
        {
            // vacias el id de la peticion en el id que recibira el command para saber cual eliminar
            command.id_Colaborador = id;
            // creas tu variable con la informacion que te mande tu handler con el _mediator para comunicarte con el y el metodo "Send" de .net
            // para mandar tu command
            var response = await _mediator.Send(command);
            // retornas un NoContent(), la verdad no se porque eso me lo dio chat jajajaj
            return NoContent();
        }
    }
}

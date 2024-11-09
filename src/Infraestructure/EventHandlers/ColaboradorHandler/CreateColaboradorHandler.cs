using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Commands.ColaboradorCommand;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Domain.Entities;
using Infraestructure.Persistence;
using MediatR;

namespace Infraestructure.EventHandlers.ColaboradorHandler
{
    // recuerda el public class, aqui cambia lo que devuelve porque devuelve un IRequestHandler, osea una respuesta tipo handler
    // y luego le pasas el command que creaste para su respectiva operacion en este caso "CreateColaboradorCommand"
    public class CreateColaboradorHandler : IRequestHandler<CreateColaboradorCommand, Response<int>>
    {
        // vuelves a crear tu variable tipo ApplicationDbContext
        private readonly ApplicationDbContext _context;
        //private readonly IColaboradorService _service;

        // la vuelves a inyectar en el constructor.
        public CreateColaboradorHandler(ApplicationDbContext context)
        {
            // asignas el context de tu BD a tu variable creada para poder manipular tu BD
            _context = context;
            //_service = service;
        }

        // Creas la logica de tu handler esta ves es public async Task<Response<int>> Handle e inyectas tu command creado para esta operacion
        // Siendo honestos el CancellationToken no se pa que es, pero tu ponlo xd
        public async Task<Response<int>> Handle(CreateColaboradorCommand command, CancellationToken cancellationToken)
        {
            // creas tu variable que al final sera la que insertes en la BD y tiene que ser del mismo tipo "new Colaborador"
            var colaborador = new Colaborador
            {
                // vacias los datos del command osea lo que recibe el command, que son los datos que tu ya definiste
                // los vacias en la nueva variable que creaste y sera la que se inserte en el BD
                nombre = command.nombre,
                edad = command.edad,
                cumpleaños = command.cumpleaños,
                es_Profesor = command.es_Profesor
            };

            if (command.es_Profesor)
            {
                //var administrador = new Administradores
                //{

                //};

                //await _context.AddAsync();
            }
            // usas el await y luego tu _context osea tu BD y usas el metodo ya definido AddAsync y le pasas los parametros de tu variable
            // que quieres crear y el cancellationToken
            await _context.AddAsync(colaborador, cancellationToken);

            // PASO IMPORTANTE, SIEMPRE QUE HAGAS ALGUN CAMBIO EN LA BD EN ESTE CASO EL "AddAsync" HAZ ESTE PASO
            //  _context.SaveChangesAsync(cancellationToken);
            // breve explicacion, lo que haces con esos metodos que manipulan la BD en realidad estas alterando el estado de ese objecto
            // en tu codigo, no en la BD y cuando llamas al SaveChangesAsync, lo que haces es que el codigo lee los cambios hechos en tu objecto
            // y ahora si los manda a la BD si no haces este paso, cambiara solo el estado de tu objecto en codigo, pero no cambiara tu BD
            await _context.SaveChangesAsync(cancellationToken);
            // Retornas una nueva respuesta tipo entero como pusiste hasta arriba Response<int>> osea true, pero que tambien es tipo handler
            // por lo que le pasas tu colaborador creado y su id asignado
            return new Response<int>(colaborador.id_Colaborador);
        }
    }
}

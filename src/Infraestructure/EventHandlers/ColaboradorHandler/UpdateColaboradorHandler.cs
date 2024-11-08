using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Commands.ColaboradorCommand;
using ApplicationCore.Wrappers;
using Domain.Entities;
using Infraestructure.Persistence;
using MediatR;

namespace Infraestructure.EventHandlers.ColaboradorHandler
{
    // recuerda el public class, aqui cambia lo que devuelve porque devuelve un IRequestHandler, osea una respuesta tipo handler
    // y luego le pasas el command que creaste para su respectiva operacion en este caso "UpdateColaboradorHandler"
    public class UpdateColaboradorHandler : IRequestHandler<UpdateColaboradorCommand, Response<int>>
    {
        // vuelves a crear tu variable tipo ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // la vuelves a inyectar en el constructor.
        public UpdateColaboradorHandler(ApplicationDbContext context)
        {
            // asignas el context de tu BD a tu variable creada para poder manipular tu BD
            _context = context;
        }

        // Creas la logica de tu handler esta ves es public async Task<Response<int>> Handle e inyectas tu command creado para esta operacion
        // Siendo honestos el CancellationToken no se pa que es, pero tu ponlo xd
        public async Task<Response<int>> Handle(UpdateColaboradorCommand command, CancellationToken cancellationToken)
        {

            // creas una variable pero que almacenara solo el id del colaborador que le pasaste por tu command 
            // el motodo FindAsync ya busca el id en tu _context  osea tu BD
            // esto "FindAsync(command.id_Colaborador);" solo busca el colaborador por el campo de tu command id_colaborador
            var colaborador = await _context.Colaboradores.FindAsync(command.id_Colaborador);

            // una validacion por si no encuentra nada
            if (colaborador == null)
            {
                // retornara un 0 osea false
                return new Response<int>(0);
            }

            // vacias los datos del command osea lo que recibe el command, que son los datos que tu ya definiste
            // los vacias en la nueva variable que creaste y sera la que se actualice en el BD
            colaborador.nombre = command.nombre;
            colaborador.edad = command.edad;
            colaborador.cumpleaños = command.cumpleaños;
            colaborador.es_Profesor = command.es_Profesor;

            // en este caso como ya existe la entidad solo necesitas hacer el "SaveChangesAsync" para que se actualice en tu bd porque
            // aqui ya actualizaste tu objecto
            await _context.SaveChangesAsync(cancellationToken);
            // Retornas una nueva respuesta tipo entero como pusiste hasta arriba Response<int>> osea true, pero que tambien es tipo handler
            // por lo que le pasas su id asignado
            return new Response<int>(colaborador.id_Colaborador);
        }
    }
}

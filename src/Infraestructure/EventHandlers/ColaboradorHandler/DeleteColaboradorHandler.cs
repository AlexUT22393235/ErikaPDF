using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Commands.ColaboradorCommand;
using ApplicationCore.Wrappers;
using Infraestructure.Persistence;
using MediatR;
using Domain.Entities;

namespace Infraestructure.EventHandlers.ColaboradorHandler
{
    // recuerda el public class, aqui cambia lo que devuelve porque devuelve un IRequestHandler, osea una respuesta tipo handler
    // y luego le pasas el command que creaste para su respectiva operacion en este caso "DeleteColaboradorHandler"
    public class DeleteColaboradorHandler : IRequestHandler<DeleteColaboradorCommand, Response<int>>
    {
        // vuelves a crear tu variable tipo ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // la vuelves a inyectar en el constructor.
        public DeleteColaboradorHandler(ApplicationDbContext context)
        {
            // asignas el context de tu BD a tu variable creada para poder manipular tu BD
            _context = context;
        }

        // Creas la logica de tu handler esta ves es public async Task<Response<int>> Handle e inyectas tu command creado para esta operacion
        // Siendo honestos el CancellationToken no se pa que es, pero tu ponlo xd
        public async Task<Response<int>> Handle(DeleteColaboradorCommand command, CancellationToken cancellationToken)
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
            // si encuentra algo usa el metodo "Remove" que eliminara ese colaborador con ese id
            _context.Colaboradores.Remove(colaborador);
            // PASO IMPORTANTE, SIEMPRE QUE HAGAS ALGUN CAMBIO EN LA BD EN ESTE CASO EL "Remove" HAZ ESTE PASO
            //  _context.SaveChangesAsync(cancellationToken);
            // breve explicacion, lo que haces con esos metodos que manipulan la BD en realidad estas alterando el estado de ese objecto
            // en tu codigo, no en la BD y cuando llamas al SaveChangesAsync, lo que haces es que el codigo lee los cambios hechos en tu objecto
            // y ahora si los manda a la BD si no haces este paso, cambiara solo el estado de tu objecto en codigo, pero no cambiara tu BD
            await _context.SaveChangesAsync(cancellationToken);
            // Retornas una nueva respuesta tipo entero como pusiste hasta arriba Response<int>> osea true, pero que tambien es tipo handler
            // por lo que le pasas el id del colaborador eliminado
            return new Response<int>(command.id_Colaborador);
        }
    }
}

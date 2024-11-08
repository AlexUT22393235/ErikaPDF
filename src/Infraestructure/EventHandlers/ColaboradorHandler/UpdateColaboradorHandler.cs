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
    public class UpdateColaboradorHandler : IRequestHandler<UpdateColaboradorCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;

        public UpdateColaboradorHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(UpdateColaboradorCommand command, CancellationToken cancellationToken)
        {
            var colaborador = await _context.Colaboradores.FindAsync(command.id_Colaborador);

            if (colaborador == null)
            {
                return new Response<int>(0);
            }

            colaborador.nombre = command.nombre;
            colaborador.edad = command.edad;
            colaborador.cumpleaños = command.cumpleaños;
            colaborador.es_Profesor = command.es_Profesor;

            await _context.SaveChangesAsync(cancellationToken);

            return new Response<int>(colaborador.id_Colaborador);
        }
    }
}

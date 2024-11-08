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
    public class DeleteColaboradorHandler : IRequestHandler<DeleteColaboradorCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;

        public DeleteColaboradorHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(DeleteColaboradorCommand command, CancellationToken cancellationToken)
        {
            var colaborador = await _context.Colaboradores.FindAsync(command.id_Colaborador);

            if (colaborador == null)
            {
                return new Response<int>(0);
            }

            _context.Colaboradores.Remove(colaborador);

            await _context.SaveChangesAsync(cancellationToken);

            return new Response<int>(command.id_Colaborador);
        }
    }
}

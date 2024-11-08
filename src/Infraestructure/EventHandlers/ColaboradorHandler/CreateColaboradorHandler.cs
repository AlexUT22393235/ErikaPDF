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
    public class CreateColaboradorHandler : IRequestHandler<CreateColaboradorCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        //private readonly IColaboradorService _service;

        public CreateColaboradorHandler(ApplicationDbContext context, IColaboradorService service)
        {
            _context = context;
            //_service = service;
        }

        public async Task<Response<int>> Handle(CreateColaboradorCommand command, CancellationToken cancellationToken)
        {
            var colaborador = new Colaborador
            {
                nombre = command.nombre,
                edad = command.edad,
                cumpleaños = command.cumpleaños,
                es_Profesor = command.es_Profesor
            };

            await _context.AddAsync(colaborador, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new Response<int>(colaborador.id_Colaborador);
        }
    }
}

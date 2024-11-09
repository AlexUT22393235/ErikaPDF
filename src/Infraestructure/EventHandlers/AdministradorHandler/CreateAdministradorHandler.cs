using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Commands.AdministradorCommand;
using ApplicationCore.Commands.ColaboradorCommand;
using ApplicationCore.Wrappers;
using Domain.Entities;
using Infraestructure.Persistence;
using MediatR;

namespace Infraestructure.EventHandlers.AdministradorHandler
{
    public class CreateAdministradorHandler : IRequestHandler<CreateAdministradorCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        public CreateAdministradorHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(CreateAdministradorCommand command, CancellationToken cancellationToken)
        {
            var administrador = new Administradores
            {
                colaborador_id = command.colaborador_id,
                correo = command.correo,
                puesto = command.puesto,
                nomina = command.nomina,
            };
            await _context.AddAsync(administrador, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new Response<int>(administrador.id_Administrado);
        }
    }
}

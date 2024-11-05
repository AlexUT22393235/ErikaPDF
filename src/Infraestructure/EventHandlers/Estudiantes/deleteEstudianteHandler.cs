using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Commands;
using ApplicationCore.Wrappers;
using Infraestructure.Persistence;
using MediatR;

namespace Infraestructure.EventHandlers.Estudiantes
{
    public class DeleteEstudianteHandler : IRequestHandler<EstudianteDeleteCommand, Response<int>>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteEstudianteHandler(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Response<int>> Handle(EstudianteDeleteCommand command, CancellationToken cancellationToken)
        {
            // Buscar el estudiante por ID
            var estudiante = await _dbContext.Estudiantes.FindAsync(command.id);
            if (estudiante == null)
            {
                return new Response<int>(0, "Estudiante no encontrado.");
            }
            
            _dbContext.Estudiantes.Remove(estudiante);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return new Response<int>(estudiante.Id, "Eliminación exitosa");
        }
    }
}

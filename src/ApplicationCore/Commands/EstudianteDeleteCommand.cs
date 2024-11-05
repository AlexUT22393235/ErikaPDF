using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commands
{
    public class EstudianteDeleteCommand : IRequest<Response<int>>
    {
        public int id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commands.AdministradorCommand
{
    public class CreateAdministradorCommand : IRequest<Response<int>>
    {
        public int colaborador_id { get; set; }
        public string correo { get; set; }
        public string puesto { get; set; }
        public double nomina { get; set; }
    }
}

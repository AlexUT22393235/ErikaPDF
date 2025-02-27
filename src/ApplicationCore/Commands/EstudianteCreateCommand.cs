﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commands
{
    public class EstudianteCreateCommand: IRequest<Response<int>>
    {
        public int? Id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string correo { get; set; }
    }
}

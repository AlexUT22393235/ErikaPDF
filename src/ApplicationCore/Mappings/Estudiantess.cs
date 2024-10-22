using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Commands;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class Estudiantess : Profile
    {
        public Estudiantess()
        {
            CreateMap<EstudianteCreateCommand, Estudiantes>()
            .ForMember(x => x.Id, y => y.Ignore());
        }
    }

}

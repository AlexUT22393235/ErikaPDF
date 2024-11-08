using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commands.ColaboradorCommand
{
    public class UpdateColaboradorCommand : IRequest<Response<int>>
    {
        public int id_Colaborador { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public DateTime cumpleaños { get; set; }
        public bool es_Profesor { get; set; }
    }
}

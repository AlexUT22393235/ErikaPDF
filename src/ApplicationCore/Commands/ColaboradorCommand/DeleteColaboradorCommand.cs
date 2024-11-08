using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commands.ColaboradorCommand
{
    public class DeleteColaboradorCommand : IRequest<Response<int>>
    {
        public int id_Colaborador { get; set; }

        //public DeleteColaboradorCommand(int id)
        //{
        //    id_Colaborador = id;
        //}
    }
}

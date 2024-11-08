using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commands.ColaboradorCommand
{
    // recuerda el public class y seguido del nombre del command en este caso "DeleteColaboradorCommand" va el IRequest<Response<int>>
    // se que es asi, pero segun yo es porque los commands solo devuelven un numero de true o false osea 1 o 0
    public class DeleteColaboradorCommand : IRequest<Response<int>>
    {
        // Como el delete solo necesita el id solo ese campo pones
        public int id_Colaborador { get; set; }
        // recuerda ponerles public a todos y su tipo de dato correspondiente

        // IGNORA LO DE ABAJO, ANTES MANEJABA EL DELETE DE OTRA FORMA PERO NO ME GUSTO XD

        //public DeleteColaboradorCommand(int id)
        //{
        //    id_Colaborador = id;
        //}
    }
}

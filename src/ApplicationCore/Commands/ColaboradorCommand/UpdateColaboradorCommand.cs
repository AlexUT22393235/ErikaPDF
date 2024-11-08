using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commands.ColaboradorCommand
{
    // recuerda el public class y seguido del nombre del command en este caso "UpdateColaboradorCommand" va el IRequest<Response<int>>
    // se que es asi, pero segun yo es porque los commands solo devuelven un numero de true o false osea 1 o 0
    public class UpdateColaboradorCommand : IRequest<Response<int>>
    {
        // tienes que poner aqui todos los datos que sean necesarios para actualizar tu tabla en la BD.
        // aqui si puse el id porque lo necesita para saber cual actualizar
        public int id_Colaborador { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public DateTime cumpleaños { get; set; }
        public bool es_Profesor { get; set; }
        // recuerda ponerles public a todos y su tipo de dato correspondiente
    }
}

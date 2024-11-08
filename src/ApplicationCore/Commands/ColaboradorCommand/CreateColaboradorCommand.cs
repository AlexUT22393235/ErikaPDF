using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commands.ColaboradorCommand
{
    // recuerda el public class y seguido del nombre del command en este caso "CreateColaboradorCommand" va el IRequest<Response<int>>
    // se que es asi, pero segun yo es porque los commands solo devuelven un numero de true o false osea 1 o 0
    public class CreateColaboradorCommand : IRequest<Response<int>>
    {
        // tienes que poner aqui todos los datos que sean necesarios para crear tu tabla en la BD, si te das cuenta aqui no puse el id
        // porque ese se genera solo y no se pasa por la peticion http osea no es necesario ponerlo aqui y si lo pones creo que manda error xd
        public string nombre { get; set; }
        public int edad { get; set; }
        public DateTime cumpleaños { get; set; }
        public bool es_Profesor { get; set; }
        // recuerda ponerles public a todos y su tipo de dato correspondiente
    }
}

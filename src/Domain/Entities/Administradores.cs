using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Administradores
    {
        [Key]
        public int id_Administrado { get; set; }
        public int colaborador_id { get; set; }
        public string correo { get; set; }
        public string puesto { get; set; }
        public double nomina { get; set; }

        public Colaborador colaborador { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Colaborador
    {
        [Key]
        public int id_Colaborador { get; set; } 
        public string nombre { get; set; }
        public int edad { get; set; } 
        public DateTime cumpleaños { get; set; }
        public bool es_Profesor { get; set; }
    }
}

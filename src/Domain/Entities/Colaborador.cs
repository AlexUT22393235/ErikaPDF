using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Poner public class y el nombre de la entidad
    public class Colaborador
    {
        // Señalar la primery key
        [Key]
        // Nombre del campo primery key
        public int id_Colaborador { get; set; } 
        // Campos de tu BD revisar que todos tengan el public y el tipo de dato correcto
        public string nombre { get; set; }
        public int edad { get; set; } 
        public DateTime cumpleaños { get; set; }
        public bool es_Profesor { get; set; }
    }
}

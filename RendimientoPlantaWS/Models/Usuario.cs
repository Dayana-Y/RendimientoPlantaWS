using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Models
{
    public class Usuario
    {
        public string uid { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string contrasenna { get; set; }
        public Boolean estado { get; set; }
        public int fincaId { get; set; }
        public string rol { get; set; }
        public int linea { get; set; }
    }
}

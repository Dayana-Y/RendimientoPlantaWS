using System;

namespace RendimientoPlantaWS.Models
{
    public class Operario
    {
        public int uid { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int codigo { get; set; }
        public Boolean estado { get; set; }
        public Boolean ocupado { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
    }
}

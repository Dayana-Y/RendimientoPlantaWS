using System;

namespace RendimientoPlantaWS.Models
{
    public class TallosDesasignados
    {
        public string uid { get; set; }
        public int fincaId { get; set; }
        public int lineaId { get; set; }
        public int operarioId { get; set; }
        public int tallosAsignados { get; set; }
        public int tallosDesasignados { get; set; }
        public string motivo { get; set; }
        public string fechaCreacion { get; set; }
        public string user { get; set; }
    }
}

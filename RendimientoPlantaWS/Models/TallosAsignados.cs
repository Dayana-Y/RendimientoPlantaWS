using System;

namespace RendimientoPlantaWS.Models
{
    public class TallosAsignados
    {
        public string uid { get; set; }
        public int fincaId { get; set; }
        public int lineaId { get; set; }
        public int operarioId { get; set; }
        public string operarioLineaId { get; set; }
        public string fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public int tallos { get; set; }
        public string tipo { get; set; }
        public Boolean estado { get; set; }
        public string fechaCreacion { get; set; }
        public string user { get; set; }
    }
}

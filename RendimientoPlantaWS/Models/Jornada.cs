﻿
namespace RendimientoPlantaWS.Models
{
    public class Jornada
    {
        public string uid { get; set; }
        public int fincaId { get; set; }
        public int lineaId { get; set; }
        public string fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public string fechaCreacion { get; set; }
        public string user { get; set; }
    }
}

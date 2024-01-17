using System;

namespace RendimientoPlantaWS.Models
{
    public class CierreLinea
    {
        public string uid { get; set; }
        public int fincaId { get; set; }
        public int lineaId { get; set; }
        public string fechaCierre { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public int tallosParciales { get; set; }
        public int tallosCompletados { get; set; }
        public int minutosEfectivos { get; set; }
        public int tallosXhora { get; set; }
        public Double rendimientoXhora { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string usuarioCierre { get; set; }
        public Boolean cerrado { get; set; }
    }
}

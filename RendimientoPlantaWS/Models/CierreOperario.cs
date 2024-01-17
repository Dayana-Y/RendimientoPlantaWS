using System;

namespace RendimientoPlantaWS.Models
{
    public class CierreOperario
    {
        public string uid { get; set; }
        public int fincaId { get; set; }
        public int lineaId { get; set; }
        public int operarioId { get; set; }
        public string fechaCierre { get; set; }
        public int tallosParciales { get; set; }
        public int tallosCompletados { get; set; }
        public int minutosEfectivos { get; set; }
        public int tallosXhora { get; set; }
        public Double rendimientoXhora { get; set; }
        public string cierreLineaId { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string usuarioCierre { get; set; }
        public Boolean cerrado { get; set; }
    }
}


namespace RendimientoPlantaWS.Models
{
    public class Rendimiento
    {
        public string uid { get; set; }
        public int fincaId { get; set; }
        public int linea { get; set; }
        public int rendimientoPorHora { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
    }
}

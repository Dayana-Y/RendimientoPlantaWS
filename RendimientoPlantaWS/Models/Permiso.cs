using System;
using System.Collections;
using System.Collections.Generic;

namespace RendimientoPlantaWS.Models
{
    public class Permiso
    {
        public string uid { get; set; }
        public IEnumerable<string> nombres { get; set; }
        public Boolean sql { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using RendimientoPlantaWS.Models;
using RendimientoPlantaWS.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CierreLineaController : ControllerBase
    {
        private readonly CierreLineaRepository _repository;
        public CierreLineaController(CierreLineaRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<CierreLinea> jsonCierreLinea)
        {
            await _repository.Insert(jsonCierreLinea);
        }
    }
}

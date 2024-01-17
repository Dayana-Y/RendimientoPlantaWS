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
    public class RendimientoController : ControllerBase
    {
        private readonly RendimientoRepository _repository;
        public RendimientoController(RendimientoRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<Rendimiento> jsonRendimientos)
        {
            await _repository.Insert(jsonRendimientos);
        }
    }
}

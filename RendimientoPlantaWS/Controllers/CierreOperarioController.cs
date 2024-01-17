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
    public class CierreOperarioController : ControllerBase
    {
        private readonly CierreOperarioRepository _repository;
        public CierreOperarioController(CierreOperarioRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<CierreOperario> jsonCierreOperario)
        {
            await _repository.Insert(jsonCierreOperario);
        }
    }
}

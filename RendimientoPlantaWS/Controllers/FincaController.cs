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
    public class FincaController : ControllerBase
    {
        private readonly FincaRepository _repository;
        public FincaController(FincaRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<Finca> jsonFincas)
        {
            await _repository.Insert(jsonFincas);
        }
    }
}

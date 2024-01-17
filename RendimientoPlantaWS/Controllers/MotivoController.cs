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
    public class MotivoController : ControllerBase
    {
        private readonly MotivoRepository _repository;
        public MotivoController(MotivoRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<string> jsonMotivos)
        {
            await _repository.Insert(jsonMotivos);
        }
    }
}

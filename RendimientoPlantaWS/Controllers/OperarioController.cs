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
    public class OperarioController : ControllerBase
    {
        private readonly OperarioRepository _repository;
        public OperarioController(OperarioRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<Operario> jsonOperarios)
        {
            await _repository.Insert(jsonOperarios);
        }

        [HttpGet]
        public IEnumerable<Operario> Get() 
        {
            return _repository.GetOperarios();
        }
    }
}

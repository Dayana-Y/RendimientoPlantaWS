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
    public class TallosDesasignadosController : ControllerBase
    {
        private readonly TallosDesasignadosRepository _repository;
        public TallosDesasignadosController(TallosDesasignadosRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<TallosDesasignados> jsonTallosDesasignadoss)
        {
            await _repository.Insert(jsonTallosDesasignadoss);
        }
    }
}

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
    public class TallosAsignadosController : ControllerBase
    {
        private readonly TallosAsignadosRepository _repository;
        public TallosAsignadosController(TallosAsignadosRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<TallosAsignados> jsonTallosAsignadoss)
        {
            await _repository.Insert(jsonTallosAsignadoss);
        }
    }
}

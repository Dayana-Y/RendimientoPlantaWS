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
    public class DelPermisoController : ControllerBase
    {
        private readonly DelPermisoRepository _repository;
        public DelPermisoController(DelPermisoRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<string> jsonPermisos)
        {
            await _repository.Insert(jsonPermisos);
        }
    }
}

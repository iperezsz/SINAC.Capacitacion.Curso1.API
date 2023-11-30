using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SINAC.Capacitacion.Curso1.API.Data.Interfaces;
using SINAC.Capacitacion.Curso1.API.Models;

namespace SINAC.Capacitacion.Curso1.API.Controllers
{
    public class AgentesController : ODataController
    {
        private readonly IAgenteRepository _repo;

        public AgentesController(IAgenteRepository repo)
        {
            _repo = repo;
        }

        [EnableQuery]
        public IQueryable<Agents> Get()
        {
            return _repo.ObtenerAgentes();
        }

        public IActionResult Get([FromODataUri] string key) {
            Agents? agente = _repo.ObtenerAgente(key);

            if(agente == null)
            {
                return NotFound("Agente no encontrado");
            }
            else
            {
                return Ok(agente);
            }
        }

        public IActionResult Post([FromBody] Agents agente)
        {
            if(!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            _repo.CrearAgente(agente);

            return Created(agente);
        }

        public IActionResult Patch([FromODataUri] string key, Delta<Agents> delta)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            Agents? agente = _repo.ObtenerAgente(key);

            if (agente == null)
            {
                return NotFound("Agente no encontrado");
            }
            else
            {
                delta.Patch(agente);
                _repo.ActualizarAgente(agente);

                return Updated(agente);
            }
        }

        public IActionResult Delete([FromODataUri] string key)
        {
            _repo.EliminarAgente(key);

            return NoContent();
        }
    }
}

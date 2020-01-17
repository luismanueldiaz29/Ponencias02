using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ponencias02.Models;
using Microsoft.EntityFrameworkCore;

namespace Ponencias02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoInvestigacionController: ControllerBase
    {
        private readonly PonenciaContext _context;

        public GrupoInvestigacionController(PonenciaContext context){

            _context = context;
            if (_context.GrupoInvestigacion.Count() == 0){
                _context.GrupoInvestigacion.Add(new GrupoInvestigacion {NombreGrupo = "Grupo de luis"});
                _context.GrupoInvestigacion.Add(new GrupoInvestigacion {NombreGrupo = "Grupo de Carlos"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoInvestigacion>>> GetGrupoInvestigacion()
        {
            return await _context.GrupoInvestigacion.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoInvestigacion>> GetGrupoInvestigacion(int id)
        {
            var GrupoInvestigacion = await _context.GrupoInvestigacion.FindAsync(id);
            if (GrupoInvestigacion == null){
                return NotFound();
            }
            return GrupoInvestigacion;
        }

        [ProducesResponseType(201)]     // Created
        [ProducesResponseType(400)]     // BadRequest
        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<GrupoInvestigacion>> Post(GrupoInvestigacion item)
        {
            await _context.SaveChangesAsync();
            _context.GrupoInvestigacion.Add(item); 
            return CreatedAtAction(nameof(GetGrupoInvestigacion), new { id = item.id }, item);
        }

         // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GrupoInvestigacion item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

                        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var GrupoInvestigacion = await _context.GrupoInvestigacion.FindAsync(id);

            if (GrupoInvestigacion == null)
            {
                return NotFound();
            }

            _context.GrupoInvestigacion.Remove(GrupoInvestigacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
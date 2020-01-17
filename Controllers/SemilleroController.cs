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
    public class SemilleroController: ControllerBase
    {
        private readonly PonenciaContext _context;

        public SemilleroController(PonenciaContext context){
            _context = context;
             if (_context.Semillero.Count() == 0){
                _context.Semillero.Add(new Semillero {NombreSemillero = "Grupo de luis", GrupoInvestigacionId = 1});
                _context.Semillero.Add(new Semillero {NombreSemillero = "Grupo de Carlos", GrupoInvestigacionId = 2});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semillero>>> GetSemillero()
        {
            return await _context.Semillero.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semillero>> GetSemillero(int id)
        {
            var Semillero = await _context.Semillero.FindAsync(id);
            if (Semillero == null){
                return NotFound();
            }
            return Semillero;
        }

        [ProducesResponseType(201)]     // Created
        [ProducesResponseType(400)]     // BadRequest
        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Semillero>> Post(Semillero item)
        {
           
           
            _context.Semillero.Add(item); 
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSemillero), new { id = item.id }, item);
        }

         // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Semillero item)
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
            var Semillero = await _context.Semillero.FindAsync(id);

            if (Semillero == null)
            {
                return NotFound();
            }

            _context.Semillero.Remove(Semillero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GrupoInvestigacion/{id}")]
        public async Task<ActionResult<Semillero>> GetEventoSolicitud(int id)
        {
            var semilleros = await _context.Semillero.ToListAsync();
            
            foreach(Semillero element in semilleros){
                if(element.GrupoInvestigacionId == id){
                    return element;
                }
            }

            return NotFound();
        }

    }
}
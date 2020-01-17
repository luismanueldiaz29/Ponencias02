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
    public class FacultadController: ControllerBase
    {
        private readonly PonenciaContext _context;

        public FacultadController(PonenciaContext context){

            _context = context;
            if (_context.Facultad.Count() == 0){
                _context.Facultad.Add(new Facultad {NombreFacultad = "INGENIERIAS Y TECNOLOGIAS"});
                _context.Facultad.Add(new Facultad {NombreFacultad = "SALUD"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facultad>>> GetFacultad()
        {
            return await _context.Facultad.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facultad>> GetFacultad(int id)
        {
            var facultad = await _context.Facultad.FindAsync(id);
            if (facultad == null){
                return NotFound();
            }
            return facultad;
        }

        [ProducesResponseType(201)]     // Created
        [ProducesResponseType(400)]     // BadRequest
        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Facultad>> Post(Facultad item)
        {
           
           
            _context.Facultad.Add(item); 
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFacultad), new { id = item.id }, item);
        }

         // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Facultad item)
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
            var facultad = await _context.Facultad.FindAsync(id);

            if (facultad == null)
            {
                return NotFound();
            }

            _context.Facultad.Remove(facultad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
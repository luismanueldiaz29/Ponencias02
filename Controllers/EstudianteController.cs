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
    public class EstudianteController: ControllerBase
    {
        private readonly PonenciaContext _context;

        public EstudianteController(PonenciaContext context){

            _context = context;
            if (_context.Estudiante.Count() == 0){
                _context.Estudiante.Add(new Estudiante { NombreEstudiante = "luis Manuel", ApellidoEstudiante = "Diaz Sequea", SemilleroId = 1});
                _context.Estudiante.Add(new Estudiante {NombreEstudiante = "Carlos", ApellidoEstudiante = "Daza Murgas", SemilleroId = 1 });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            return await _context.Estudiante.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante == null){
                return NotFound();
            }
            return estudiante;
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante item)
        {
            _context.Estudiante.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEstudiante), new { id = item.id }, item);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}
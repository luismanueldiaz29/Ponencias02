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
    public class InvestigacionController: ControllerBase
    {
        private readonly PonenciaContext _context;

        public InvestigacionController(PonenciaContext context){

            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investigacion>>> GetInvestigacions()
        {
            return await _context.Investigacion.ToListAsync();
        }

        [HttpGet("Solicitud/{id}")]
        public async Task<ActionResult<Investigacion>> GetInvestigacionSolicitud(int id)
        {
            var Investigaciones = await _context.Investigacion.ToListAsync();
            foreach(Investigacion elemet in Investigaciones){
                if(elemet.SolicitudId == id){
                    return elemet;
                }
            }
            return NotFound();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investigacion>> GetInvestigacion(int id)
        {
            var Investigacion = await _context.Investigacion.FindAsync(id);
            if (Investigacion == null){
                return NotFound();
            }
            return Investigacion;
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Investigacion>> PostInvestigacion(Investigacion item)
        {
            _context.Investigacion.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInvestigacion), new { id = item.id }, item);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestigacion(int id, Investigacion item)
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
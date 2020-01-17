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
    public class TransporteController: ControllerBase
    {
        private readonly PonenciaContext _context;

        public TransporteController(PonenciaContext context){
            _context = context;
            if (_context.Transporte.Count() == 0){
                _context.Transporte.Add(new Transporte { TipoTransporte = "aereo", ValorTrasporte = 2000, SolicitudId = 1});
                _context.Transporte.Add(new Transporte {TipoTransporte = "aereo", ValorTrasporte = 2000, SolicitudId = 2});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transporte>>> GetTransportes()
        {
            return await _context.Transporte.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transporte>> GetTransporte(int id)
        {
            var Transporte = await _context.Transporte.FindAsync(id);
            if (Transporte == null){
                return NotFound();
            }
            return Transporte;
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Transporte>> PostTransporte(Transporte item)
        {
            _context.Transporte.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransporte), new { id = item.id}, item);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransporte(int id, Transporte item)
        {
            if (id != item.id)
            {
            return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("Solicitud/{id}")]
        public async Task<ActionResult<Transporte>> GetEventoSolicitud(int id)
        {
            var transportes = await _context.Transporte.ToListAsync();
            
            foreach(Transporte element in transportes){
                if(element.SolicitudId == id){
                    return element;
                }
            }

            return NotFound();
        }
    }
}
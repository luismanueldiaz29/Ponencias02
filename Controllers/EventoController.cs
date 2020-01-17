using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ponencias02.Models;
using Microsoft.EntityFrameworkCore;
//https://www.entityframeworktutorial.net/efcore/one-to-one-conventions-entity-framework-core.aspx
namespace Ponencias02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController: ControllerBase
    {
        
        private readonly PonenciaContext _context;

        public EventoController(PonenciaContext context){
            _context = context;
            if (_context.Evento.Count() == 0){
                _context.Evento.Add(new Evento {
                                                NombreEvento="Ponencia"
                                                ,LinkEvento="luismaajas"
                                                ,Pais= "colombia",
                                                Ciudad="Bogotá"
                                                ,Telefono="30051725445",
                                                ValorInscripcion = 30012,
                                                FechaEvento = "30/12/20",
                                                FechaInicio= "01/12/20",
                                                FechaFinal = "01/12/23",
                                                NumeroDias=3,
                                                Entidad="Young",
                                                Email="Unfair@young.com",
                                                SolicitudId = 1
                                            });
                                                      
                _context.Evento.Add(new Evento {
                                                NombreEvento="Ponencia"
                                                ,LinkEvento="luismaajas",
                                                 Pais= "colombia",
                                                 Ciudad="Valledupar",
                                                 Telefono="30051725445",
                                                ValorInscripcion = 30012,
                                                FechaEvento = "30/12/20",
                                                FechaInicio= "01/12/20",
                                                FechaFinal = "01/12/23", 
                                                NumeroDias=3,
                                                Email="NobMasterPro@Carlos.com",
                                                Entidad="life book",
                                                SolicitudId = 2    
                                            });
                _context.SaveChanges();
            }
        }
   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            return await _context.Evento.ToListAsync();
        }

 // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _context.Evento.FindAsync(id);
            if (evento == null){
                return NotFound();
            }
            return evento;
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento item)
        {
            _context.Evento.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvento), new { id = item.id }, item);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento item)
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
            var evento = await _context.Evento.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            _context.Evento.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Solicitud/{id}")]
        public async Task<ActionResult<Evento>> GetEventoSolicitud(int id)
        {
            var eventos = await _context.Evento.ToListAsync();
            
            foreach(Evento element in eventos){
                if(element.SolicitudId == id){
                    return element;
                }
            }

            return NotFound();
        }

    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ponencias02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace Ponencias02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController: ControllerBase
    {
        private readonly PonenciaContext _context;
        //envio de correo
        EnvioDeEmail envioDeEmail = new EnvioDeEmail();
        //envio de correo
        public DocenteController(PonenciaContext context){

            _context = context;
            if (_context.Docente.Count() == 0){
                _context.Docente.Add(new Docente { id = "1",  Nombres = "Carlos ", Apellidos = "Daza", Telefono = "101291212", VinculoInst = "docente", Email = "luis@gmail.com", direccion = "calle linda", Pass = "123", FacultadId = 1, GrupoInvestigacionId = 1});
                _context.Docente.Add(new Docente {  id = "2", Nombres = "Luis Manué", Apellidos = "Diaz", Telefono = "101291212", VinculoInst = "docente", Email = "luis@gmail.com", direccion = "calle cuba", Pass = "123", FacultadId = 1, GrupoInvestigacionId  = 1});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docente>>> GetDocentes()
        {
            return await _context.Docente.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Docente>> GetDocente(string id)
        {
            var docente = await _context.Docente.FindAsync(id);
            if (docente == null){
                return NotFound();
            }
            return docente;
        }

        //[ProducesResponseType(201)]     // Created
        //[ProducesResponseType(400)]     // BadRequest
        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Docente>> Post(Docente item)
        {
           
        //    var facultad=_context.Facultad.FindAsync(item.FacultadId);

        //    if(facultad==null)
        //    {
        //      ModelState.AddModelError("Facultad", "mesnahe");
        //         var problemDetails = new ValidationProblemDetails(ModelState)
        //         {
        //             Status = StatusCodes.Status400BadRequest,
        //         };
        //         return BadRequest(problemDetails);

        //    }

            
            _context.Docente.Add(item); 
            await _context.SaveChangesAsync();
            //envio de correo

            string encabezado = "Registro de Usuario " + DateTime.Now.ToString("dd/ MMM / yyy hh:mm:ss");
            string body = $"Estimado Docente : {item.Nombres} {item.Apellidos}\n se ha registrado su inventario exitosamente. Su Usuario: {item.Email}\n Contraseña: {item.Pass} ";
            
            envioDeEmail.EnviarEmail(item, encabezado, body);

            //envio de correo
            return CreatedAtAction(nameof(GetDocente), new { id = item.id }, item);
        }

         // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Docente item)
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
        public async Task<IActionResult> Delete(string id)
        {
            var docente = await _context.Docente.FindAsync(id);

            if (docente == null)
            {
                return NotFound();
            }

            _context.Docente.Remove(docente);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        

    }
}
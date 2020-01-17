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
    public class AdministradorController: ControllerBase
    {
        
        private readonly PonenciaContext _context;

        public AdministradorController(PonenciaContext context){
            _context = context;
            if (_context.Administrador.Count() == 0){
                _context.Administrador.Add(new Administrador{ id = "123",  Nombres = "Carlos ", Apellidos = "Daza", Usuario = "2carlosdaza@gmail.com", Pass = "123"});
                _context.Administrador.Add(new Administrador{ id = "321",  Nombres = "Luis ", Apellidos = "Diaz", Usuario = "luis@gmail.com", Pass = "123"});
                _context.SaveChanges();
            }
        }
   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradors()
        {
            return await _context.Administrador.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(string id)
        {
            var Administrador = await _context.Administrador.FindAsync(id);
            if (Administrador == null){
                return NotFound();
            }
            return Administrador;
        }

    }
    
}
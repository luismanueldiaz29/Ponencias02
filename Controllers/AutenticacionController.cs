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
    public class AutenticacionController: ControllerBase
    {
        private readonly PonenciaContext _context;

        public AutenticacionController(PonenciaContext context){

        }

        // GET: api/Task/5
        // [HttpGet("{usuario}/{Password}")]
        // public async Task<ActionResult<Docente>> AutenticacionDocente(string usuario, string Password){

        //     var docentes = await _context.Docente.ToListAsync();
        //     foreach (Docente element in docentes){
        //         if(element.Email == usuario && element.Pass == Password){
        //             return element;
        //         }
        //     }
        //     return NotFound();
        // } 

        // [HttpGet]
        // public async Task<ActionResult<Administrador>> AutenticacionAdmin(LoginInputModel loginInputModel){

        //     var docentes = await _context.Administrador.ToListAsync();
        //     foreach (Administrador element in docentes){
        //         if(element.Usuario == loginInputModel.Usuario && element.Pass == loginInputModel.Password){
        //             return element;
        //         }
        //     }
        //     return NotFound();
        // } 


    }

    public class LoginInputModel{

        public string Usuario {get; set;}

        public string Password {get; set;}
    
    }
}
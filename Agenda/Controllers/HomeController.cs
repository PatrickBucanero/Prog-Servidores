using Agenda.Data;
using Agenda.models;

using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    //Obter todos os contatos
    [ApiController]
    public class HomeController: ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices]AppDbContext context)
        {
            var todosContatos = context.Contatos.ToList();
            return Ok(todosContatos);
        }
        //Criar Contato
        [HttpPost("/")]
        public IActionResult Post([FromServices]AppDbContext context,[FromBody]Contato umcontato)
        {
            context.Contatos.Add(umcontato);
            context.SaveChanges();

            return Created($"/{umcontato.Id}",umcontato);
        }

        //Obter 1 contato por ID
        [HttpGet("/{id:int}")]
         public IActionResult GetById([FromRoute]int id ,[FromServices]AppDbContext context)
         {
            var umcontato = context.Contatos.Find(id);
            if(umcontato is null)
            return NotFound();
            return Ok(umcontato);
         }
    }   

}
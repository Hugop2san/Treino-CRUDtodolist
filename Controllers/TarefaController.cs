using Microsoft.AspNetCore.Mvc;
using todolist.Data;
using todolist.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace todolist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : Controller
    {
        //instancia do banco
        private readonly AppDbContext _context;

        //constructor
        public TarefaController(AppDbContext context)
        {
            _context = context;
        }



        //[HttpPut]

        //[HttpDelete]

        [HttpPost]


        [HttpGet(Name = "idtaefa")]
        public async Task<ActionResult<Tarefa> >GetId(int Id)
        {
         
            return await _context.Tarefas.FindAsync();
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using todolist.Data;
using todolist.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.OpenApi.Any;
using todolist.Dto;

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



        [HttpPut("atualiza/id/{id}")]
        public async Task<ActionResult<Tarefa>> Atualiza(int id,[FromBody] Tarefa tarefa)
        {
            if (id == null)
            {
                return BadRequest("Tarefa nao encontrada");
            }
            var tarefadb = await _context.Tarefas.FirstOrDefaultAsync(x =>x.Id == id);

            if (tarefadb == null)
            {
                return NotFound("Tarefa nao encontrada");
            }

            tarefadb.Id = id;
            tarefadb.Titulo = tarefa.Titulo;
            tarefadb.Descricao = tarefa.Descricao;
            tarefadb.Status = tarefa.Status;
            tarefadb.DataCriacao = new DateTime();

            await _context.SaveChangesAsync();

            return Ok($"{tarefa}\nProduto Atualizado!");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Tarefa>> Delete(int id) 
        {
            if (id == null)
            {
                return BadRequest("Tarefa nao encontrada");
            }
            var retornotarefa = await _context.Tarefas.FindAsync(id);

            if (retornotarefa  == null)
            {
                return NotFound("Tarefa nao encontrada");
            }

            //Removo e salvo
            _context.Tarefas.Remove(retornotarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        } 

        [HttpPost("criartarefa")]
        public async Task<ActionResult<Tarefa>> Criartarefa([FromBody] DtoTarefa dtotarefa)
        {
            if (dtotarefa == null)
                return BadRequest("Tarefa Not Found");

            var tarefa = new Tarefa()
            {
                Titulo = dtotarefa.Titulo,
                Descricao = dtotarefa.Descricao,
                Status = dtotarefa.Status,

            };

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetId), new { Id = tarefa.Id}, tarefa);
        }

        // Busca por ID
        [HttpGet("{Id:Int}")] 
        public async Task<ActionResult<Tarefa>>GetId(int Id)
        {
            var objeto = await _context.Tarefas.FindAsync(Id);
            if( objeto== null)
            {
             return NotFound("Seu objeto é nulo!") ;
            }
            return objeto;
        }

        // Busca a tarefa por nome extato
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<Tarefa>> Getnome(string nome)
        {
            if (nome == null)
            {
                return BadRequest("Tarefa nao encontrada");
            }
            var retorno = await _context.Tarefas.Where(x => x.Titulo == nome).FirstOrDefaultAsync();
            if (retorno == null)
            {
                return NotFound("Tarefa nao encontrada");
            }
            
            return retorno;
        }


        //retorna todas as tarefas
        [HttpGet("todastarefas")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> Getall()
        {
            var retorno = await _context.Tarefas.ToListAsync();
            if (!retorno.Any())
            {
             return NotFound("Nao possui tarefas.");
            } 

            return retorno;
        }




    }
}

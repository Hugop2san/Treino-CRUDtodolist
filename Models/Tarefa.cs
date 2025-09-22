// 		○ CRUD da entidade Tarefa (Id, Título, Descrição, Status, DataCriacao).


namespace todolist.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descrição { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }  = new DateTime();

        public override string ToString()
        {
           return $"Id: {Id}\n" +
               $"Título: {Titulo}\n" +
               $"Descrição: {Descrição}\n" +
               $"Status: {Status}\n" +
               $"Data de Criação: {DataCriacao:dd/MM/yyyy HH:mm}"; ;
        }


    }
}

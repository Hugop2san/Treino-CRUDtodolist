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
        

    }
}

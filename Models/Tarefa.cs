// 		○ CRUD da entidade Tarefa (Id, Título, Descrição, Status, DataCriacao).


namespace todolist.Models
{
    public class Tarefa
    {
        private static readonly Random _random;
      
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }  = new DateTime();

        public Tarefa()
        {
            Id = _random.Next(0, 1000);
        }
        public override string ToString()
        {
           return $"Id: {Id}\n" +
               $"Título: {Titulo}\n" +
               $"Descrição: {Descricao}\n" +
               $"Status: {Status}\n" +
               $"Data de Criação: {DataCriacao:dd/MM/yyyy HH:mm}"; ;
        }


    }
}

using System.Collections.Generic;

namespace Quiz.Entities.Entitites
{
    public class Prova
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int Pontos { get; set; }
        public IEnumerable<Questao> Questoes { get; set; }
    }
}

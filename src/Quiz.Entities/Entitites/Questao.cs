namespace Quiz.Entities.Entitites
{
    public class Questao
    {
        public string Id { get; set; }
        public string Pergunta { get; set; }
        public string[] Respostas { get; set; }
        public string RespostaCorreta { get; set; }
        public string RespostaMarcada { get; set; }
        public string DescricaoRespostaCorreta { get; set; }
        public string Image { get; set; }
        public string Categoria { get; set; }
        public string Dificuldade { get; set; }
        public bool Jogado { get; set; }
    }
}

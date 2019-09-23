using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Quiz.Repositories.Model
{
    public class QuestaoModel
    {
        
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
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

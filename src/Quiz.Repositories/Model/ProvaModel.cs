using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Quiz.Repositories.Model
{
    public class ProvaModel
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public int Pontos { get; set; }

        public IEnumerable<QuestaoModel> Questoes { get; set; }
    }
}

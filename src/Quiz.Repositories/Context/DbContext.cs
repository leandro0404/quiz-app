using System;
using MongoDB.Driver;
using Quiz.Repositories.Model;

namespace Quiz.Repositories.Context
{
    public class DbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _dataBase { get; }
        public DbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _dataBase = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }
        public IMongoCollection<ProvaModel> Prova
        {
            get
            {
                return _dataBase.GetCollection<ProvaModel>("prova");
            }
        }

        public IMongoCollection<QuestaoModel> Questao
        {
            get
            {
                return _dataBase.GetCollection<QuestaoModel>("questao");
            }
        }

    }
}

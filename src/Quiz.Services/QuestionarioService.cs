using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.Entities.Entitites;
using Quiz.Repositories.Abstractions;

namespace Quiz.Services
{
    public class QuestionarioService : IQuestionarioService
    {
        private readonly IQuestionarioRepository _repository;
        public QuestionarioService(IQuestionarioRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Questao>> Get()
        {
            return _repository.Get();
        }

        public Task<IEnumerable<Prova>> GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public Task<IEnumerable<Prova>> Rank()
        {
            return _repository.Rank();
        }

        public Task<Prova> Save(Prova prova)
        {
            return _repository.Save(prova);

        }
    }
}

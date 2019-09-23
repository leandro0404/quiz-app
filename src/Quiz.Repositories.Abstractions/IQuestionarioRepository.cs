using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.Entities.Entitites;

namespace Quiz.Repositories.Abstractions
{
    public interface IQuestionarioRepository
    {
        Task<IEnumerable<Questao>> Get();
        Task<Prova> Save(Prova prova);
        Task<IEnumerable<Prova>> Rank();
        Task<IEnumerable<Prova>> GetByEmail(string email);
    }
}

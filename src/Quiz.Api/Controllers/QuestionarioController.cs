using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.Entities.Entitites;
using Quiz.Services;

namespace Quiz.Api.Controllers
{
    public class QuestionarioController : Controller
    {
        private readonly IQuestionarioService _service;
        public QuestionarioController(IQuestionarioService service)
        {
            _service = service;
        }

        [Route("/questoes"), HttpGet]
        public Task<IEnumerable<Questao>> Get()
        {
            return _service.Get();
        }

        [Route("/prova"), HttpPost]
        public Task<Prova> Post([FromBody]Prova prova)
        {
            return _service.Save(prova);
        }

        [Route("/rank"), HttpGet]
        public Task<IEnumerable<Prova>> Rank()
        {
            return _service.Rank();
        }

        [Route("/prova/{email}"), HttpGet]
        public Task<IEnumerable<Prova>> Rank(string email)
        {
            return _service.GetByEmail(email);
        }
    }
}

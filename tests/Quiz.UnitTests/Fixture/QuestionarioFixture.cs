using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.Entities.Entitites;
using Quiz.Repositories.Abstractions;

namespace Quiz.UnitTests.Fixture
{
    public class QuestionarioFixture
    {
        public IQuestionarioRepository Repository { get; }

        public QuestionarioFixture()
        {
            Repository = MockQuestionarioService();
        }

        public IQuestionarioRepository MockQuestionarioService()
        {
            var mock = new Mock<IQuestionarioRepository>();

            mock.Setup(x => x.Get())
                .Returns(Task.FromResult<IEnumerable<Questao>>(new List<Questao>()));

            return mock.Object;
        }

    }
}

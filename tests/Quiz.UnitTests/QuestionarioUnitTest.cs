using System.Threading.Tasks;
using Quiz.Services;
using Quiz.UnitTests.Fixture;
using Xunit;

namespace Quiz.UnitTests
{
    public class QuestionarioUnitTest : QuestionarioFixture
    {
        private readonly IQuestionarioService _questionarioService;
        public QuestionarioUnitTest()
        {
            _questionarioService = new QuestionarioService(Repository);
        }

        [Fact]
        public async Task Get()
        {
            var questionario =  await _questionarioService.Get();
            Assert.Equal(1, 1);
        }
    }
}

using GraphQL.Types;
using Quiz.Api.GraphQL.Type;
using Quiz.Entities.Entitites;
using Quiz.Services;

namespace Quiz.Api.GraphQL
{
    public class Mutation : ObjectGraphType
    {
        private const string Prova = "Prova";
        private const string Input = "input";

        public Mutation(IQuestionarioService service)
        {
            Field<ProvaType>(
                Prova,
                arguments: new QueryArguments(
                    new QueryArgument<ProvaInputType> { Name = Input }
                ),
                resolve: context =>
                {
                    var prova = context.GetArgument<Prova>(Input);
                    return service.Save(prova);
                });
        }
    }
}

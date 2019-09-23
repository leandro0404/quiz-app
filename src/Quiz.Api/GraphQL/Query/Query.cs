using GraphQL.Types;
using Quiz.Api.GraphQL.Type;
using Quiz.Entities.Entitites;
using Quiz.Services;

namespace Quiz.Api.GraphQL
{
    public class Query : ObjectGraphType
    {
        private const string Questoes = "Questoes";
        private const string Rank = "Rank";
        private const string Prova = "Prova";
        private const string Input = "input";
        public Query(IQuestionarioService service)
        {
            Field<ListGraphType<QuestaoType>>(
               Questoes,
               resolve: context =>
              {
                  return service.Get().Result;
              }
           );

            Field<ListGraphType<ProvaType>>(
               Rank,
               resolve: context =>
               {
                   return service.Rank().Result;
               }
           );

            Field<ListGraphType<ProvaType>>(
              Prova,
               arguments: new QueryArguments(
                    new QueryArgument<ProvaInputType> { Name = Input }
                ),
              resolve: context =>
              {
                  var prova = context.GetArgument<Prova>(Input);
                  return service.GetByEmail(prova?.Email).Result;
              }
          );
        }
    }
}

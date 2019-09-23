using GraphQL.Types;
using Quiz.Entities.Entitites;

namespace Quiz.Api.GraphQL.Type
{
    public class ProvaType : ObjectGraphType<Prova>
    {
        public ProvaType()
        {
            Field(x => x.Id);
            Field(x => x.Email);
            Field(x => x.Pontos);
            Field<ListGraphType<QuestaoType>>(name: nameof(Prova.Questoes));
        }
    }
    public class ProvaInputType : InputObjectGraphType<Prova>
    {
        public ProvaInputType()
        {
            Field(x => x.Email, nullable: true);
            Field(x => x.Pontos, nullable: true);
            Field<ListGraphType<QuestaoInputType>>(name: nameof(Prova.Questoes));
        }
    }
}

using GraphQL;
using GraphQL.Types;

namespace Quiz.Api.GraphQL
{
    public class QuestionarioSchema : Schema
    {
        public QuestionarioSchema(IDependencyResolver resolver)
        : base(resolver)
        {
            Query = resolver.Resolve<Query>();
            Mutation = resolver.Resolve<Mutation>();
        }
    }
}

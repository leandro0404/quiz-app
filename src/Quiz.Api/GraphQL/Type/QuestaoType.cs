using GraphQL.Types;
using Quiz.Entities.Entitites;

namespace Quiz.Api.GraphQL.Type
{
    public class QuestaoType : ObjectGraphType<Questao>
    {
        public QuestaoType()
        {
            Field(x => x.Id);
            Field(x => x.Pergunta);
            Field(x => x.Respostas);
            Field(x => x.RespostaCorreta);
            Field(x => x.RespostaMarcada);
            Field(x => x.DescricaoRespostaCorreta);
            Field(x => x.Image);
            Field(x => x.Categoria);
            Field(x => x.Dificuldade);
            Field(x => x.Jogado);
        }
    }

    public class QuestaoInputType : InputObjectGraphType<Questao>
    {
        public QuestaoInputType()
        {
            Field(x => x.Id, nullable: true);
            Field(x => x.Pergunta, nullable: true);
            Field(x => x.Respostas, nullable: true);
            Field(x => x.RespostaCorreta, nullable: true);
            Field(x => x.RespostaMarcada, nullable: true);
            Field(x => x.DescricaoRespostaCorreta, nullable: true);
            Field(x => x.Image, nullable: true);
            Field(x => x.Categoria, nullable: true);
            Field(x => x.Dificuldade, nullable: true);
            Field(x => x.Jogado, nullable: true);
        }
    }
}

var localVars = {
    email: null,
    quiz: new QuizComponent('frame'),
    login: new LoginComponent('frame')
};

function initPage() {

    localVars.login.init();

    localVars.login.clickLogin(function () {
        $.when(loadData()).then(function (result) {
            localVars.quiz.fill(result.data.questoes);
            localVars.quiz.save(save);
        });
    });
}

function loadData() {

    var query = {
        "query": `
                    query {
                      questoes
                      {
                        id,
                        categoria,
                        dificuldade,
                        pergunta,
                        respostas,
                        respostaCorreta,
                        image,
                        jogado
                      }
                    }
                    `
    };
    return postGraphQLRequest(query);
}

function save() {

    var query = {
        query: ` mutation Prova($email: String!, $pontos: Int!) {
                    prova(
                        input: {
                            email: $email,
                            pontos: $pontos
                            questoes : ${JSON.stringify(localVars.quiz.getQuestions()).ConvertJsonToInputQuery()}
                        }
                    )
                    {
                            id,
                            email,
                            pontos
                    }
                }`,
        variables: { "email": localVars.email, "pontos": localVars.quiz.getScore() }
    };

    postGraphQLRequest(query);

    setTimeout(function () { location.reload(); }, 2000);
}

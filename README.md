### Development  
 #### Run
```cmd
dotnet build
dotnet run
```

#### Running tests
Bash script
```
.\alltests.sh
```


**para cadastro das perguntas use o modelo abaixo no arquivo \Questoes.json**

campo imagem deve estar  empty ou conter url de imagem descritiva caso precise de uma ilustração.
```

 {
    "pergunta": "coloque aqui a pergunta ",
    "respostas": [
      "resposta 1 ",
      "resposta 2 ",
      "resposta 3 ",
      "resposta 4 ",
      "resposta 5 ",
      "resposta 6 "
    ],
     "image": "",
    "respostaCorreta": "6"
  }

```


*Query

```

query Questoes{
  questoes
  {
    id,
    categoria,
    dificuldade,
    pergunta,
    respostas,
    respostaCorreta,
    jogado
  }
}



query Rank{
  rank {
    email,
    pontos
  }
}


query ProvaByEMail {
  prova(
    input:{
      email:"leandrobhmgg@gmail.com"
    }
  )
  {
    email,
    pontos
  }
}

```

*Mutation

```graphql
mutation {
  prova(
    input:{
      email:"leandro@gmail.com",
      pontos: 4,
      id:2,
      questoes: [
      {
        id: 1,
        categoria: 0,
        dificuldade: 0,
        pergunta: "Quanto � 1 + 1?",
        respostas: [
          "1",
          "2",
          "3",
          "4"
        ],
        respostaCorreta: 1,
        respostaMarcada:2,
        jogado: false
      }
        {
        id: 2,
        categoria: 0,
        dificuldade: 0,
        pergunta: "Quanto � 1 + 1?",
        respostas: [
          "1",
          "2",
          "3",
          "4"
        ],
        respostaCorreta: 1,
        respostaMarcada:3,
        jogado: false
      }
    ]
      
    }
  ){
    id,
    email
    pontos,
    questoes {
      respostaCorreta
      respostaMarcada
    }
    
  }
}
```






![alt text](https://github.com/leandro0404/quiz-app/blob/master/images/img-01.png)

![alt text](https://github.com/leandro0404/quiz-app/blob/master/images/img-02.png)

![alt text](https://github.com/leandro0404/quiz-app/blob/master/images/img-03.png)


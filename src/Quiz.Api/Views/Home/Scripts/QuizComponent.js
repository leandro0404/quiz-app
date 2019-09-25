var QuizComponent = (function () {

    var quizComponent = function (containerId) {

        var _config = {
            question: null,
            score: 0,
            currentpergunta: 0,
            submt: true,
            picked: null,
            save: null
        };

        this.fill = function (data) {
            _config.question = data;
            var myNode = document.getElementById(containerId);
            while (myNode.firstChild) {
                myNode.removeChild(myNode.firstChild);
            }
            init(data);
        };

        this.getScore = function () {
            return _config.score;
        };

        this.getQuestions = function () {
          return  _config.question;
        };

        this.save = function (func) {
            _config.save = func;
        };

        function init(data) {
            //add pager and question
            if (typeof data !== "undefined" && $.type(data) === "array") {
                //add pager
                $(document.createElement('p')).addClass('pager').attr('id', 'pager').text('pergunta 1 de ' + data.length).appendTo('#frame');
                //add first pergunta
                $(document.createElement('h2')).addClass('pergunta').attr('id', 'pergunta').text(data[0]['pergunta']).appendTo('#frame');

                $(document.createElement('p')).addClass('descricaoRespostaCorreta').attr('id', 'descricaoRespostaCorreta').html('&nbsp;').appendTo('#frame');

                //question holder
                $(document.createElement('ul')).attr('id', 'choice-block').appendTo('#frame');

                //add respostas
                addrespostas(data[0]['respostas']);

                //add submit button
                $(document.createElement('div')).addClass('choice-box').attr('id', 'submitbutton').text('OK')
                    .css({ 'font-weight': 300, 'color': '#222', 'padding': '30px 0' }).appendTo('#frame');

                setupButtons();
            }
        }

        function htmlEncode(value) {
            return $(document.createElement('div')).text(value).html();
        }

        function addrespostas(respostas) {
            if (typeof respostas !== "undefined" && $.type(respostas) == "array") {
                $('#choice-block').empty();
                for (var i = 0; i < respostas.length; i++) {
                    $(document.createElement('li')).addClass('choice choice-box').attr('data-index', i).text(respostas[i]).appendTo('#choice-block');
                }
            }
        }

        function nextpergunta() {
            _config.submt = true;
            $('#descricaoRespostaCorreta').empty();
            $('#pergunta').text(_config.question[_config.currentpergunta]['pergunta']);
            $('#pager').text('pergunta ' + Number(_config.currentpergunta + 1) + ' of ' + _config.question.length);
            addrespostas(_config.question[_config.currentpergunta]['respostas']);
            setupButtons();

        }

        function processpergunta(choice) {

            if (_config.question[_config.currentpergunta]['respostas'][choice] == _config.question[_config.currentpergunta]['respostaCorreta']) {
                $('.choice').eq(choice).css({ 'background-color': '#50D943' });
                $('#descricaoRespostaCorreta').html('<strong>resposta Correta!</strong> ' + htmlEncode(_config.question[_config.currentpergunta]['descricaoRespostaCorreta']));
                _config.score++;
            } else {
                $('.choice').eq(choice).css({ 'background-color': '#D92623' });
                $('#descricaoRespostaCorreta').html('<strong>Resposta Correta È : </strong> ' + htmlEncode(_config.question[_config.currentpergunta]['descricaoRespostaCorreta']));
            }
            _config.question[_config.currentpergunta].respostaMarcada = _config.question[_config.currentpergunta]['respostas'][choice];
            _config.currentpergunta++;
            if (_config.currentpergunta == _config.question.length) {

                endQuiz();
            }
            $('#submitbutton').html('Próxima pergunta &raquo;').on('click', function () {
                if (_config.currentpergunta == _config.question.length) {

                    endQuiz();
                } else {
                    $(this).text('OK').css({ 'color': '#222' }).off('click');
                    nextpergunta();
                }
            });
        }

        function setupButtons() {
            $('.choice').on('mouseover', function () {
                $(this).css({ 'background-color': '#e1e1e1' });
            });
            $('.choice').on('mouseout', function () {
                $(this).css({ 'background-color': '#fff' });
            })
            $('.choice').on('click', function () {
                _config.picked = $(this).attr('data-index');
                $('.choice').removeAttr('style').off('mouseout mouseover');
                $(this).css({ 'border-color': '#222', 'font-weight': 700, 'background-color': '#c1c1c1' });
                if (_config.submt) {
                    _config.submt = false;
                    $('#submitbutton').css({ 'color': '#000' }).on('click', function () {
                        $('.choice').off('click');
                        $(this).off('click');
                        processpergunta(_config.picked);
                        nextpergunta();
                        $(this).text('OK').css({ 'color': '#222' }).off('click');

                    });
                }
            })
        }

        function endQuiz() {
            $('#descricaoRespostaCorreta').empty();
            $('#pergunta').empty();
            $('#choice-block').empty();
            $('#submitbutton').remove();
            $('#pergunta').text("Você acertou " + _config.score + " de " + _config.question.length + " question!");
            $(document.createElement('h2')).css({ 'text-align': 'center', 'font-size': '4em' }).text(Math.round(_config.score / _config.question.length * 100) + '%').insertAfter('#pergunta');
            _config.save.call(_config.question);
        }

    };

    quizComponent.version = "1.0.0";

    return quizComponent;

})();



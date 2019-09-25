var LoginComponent = (function () {

    var loginComponent = function (componentId) {

        this.init = function () {            

            $('<img>').attr({
                src: '/Home/Content/logo.png'
            }).addClass('login-logo').appendTo('#' + componentId);

            $('<h3>').text('Este desafio consiste em responder um Quiz técnico sobre o tema desta oficina. Entre com seu email para iniciar o desafio.').addClass('login-title').appendTo('#' + componentId);

            $('<form>').attr({
                id: 'form-login'
            }).addClass('form-inline').appendTo('#' + componentId);

            $('<input>').attr({
                type: 'text',
                id: 'email',
                name: 'email',
                placeholder: "Digite seu e-mail"
            }).addClass('form-control').appendTo('#form-login');

            $('<button>').attr({
                type: 'button',
                id: 'start',
                name: 'start'
            }).addClass('btn btn-primary').text('Iniciar').appendTo('#form-login');

        };

        this.clickLogin = function (func) {

            return $('#start').on('click', function () {
                if (isEmail($('#email').val())) {
                    localVars.email = $('#email').val();
                    $('#email').hide();
                    $('#start').hide();
                    func.call();
                }
                else {
                    $("#email").text("email inválido!");
                }
            });
        };
    };

    function isEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }

    loginComponent.version = "1.0.0";

    return loginComponent;

}());
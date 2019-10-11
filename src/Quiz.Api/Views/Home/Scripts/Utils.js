function postGraphQLRequest(query) {
    return $.ajax({
        method: "POST",
        url: "/graphql",
        contentType: "application/json",
        headers: {
            Authorization: "bearer ***********"
        },
        data: JSON.stringify(query)
    });
}

String.prototype.ConvertJsonToInputQuery = function () {
    return this.replace(/"([^(")"]+)":/g, "$1:");
};

jQuery(document).ready(function ($) {

    initPage();

});

$.ajaxSetup({
    cache: false,
    dataType: "JSON",
    contentType: "application/json; charset=utf-8",
    beforeSend: function (request, settings) {
        var data = JSON.parse(settings.data);
        console.info("--- GRAPHQL QUERY-----------------\n\n " + data.query + " -------------------------\n\n");
    },
    complete: function (e, status) {
        if (status == 'success') {

            try {
               
                    var responseText = JSON.parse(e.responseText);
                    console.info("Dados -------------------\n")
                    console.info(responseText);
                
            } catch (err) {
            }
        }
    }
});
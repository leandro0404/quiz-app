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
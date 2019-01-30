$(document).ready(function () {
    $("#dla_main_div").html('<p class="bg-success">Downloading dangers list</p>');
    //let url = 'https://api.um.warszawa.pl/api/action/19115store_getNotifications/?id=28dc65ad-fff5-447b-99a3-95b71b4a7d1e&apikey=7c0e8f2a-34d8-4a98-93b7-abf1941558c3';
    let url = 'http://api.nbp.pl/api/exchangerates/rates/c/usd/2016-04-04/?format=json';
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json"
    })
        .done(function (json) {
            $("#dla_main_div").html('<p class="bg-success">List downloaded</p>');
        })

        .fail(function (xhr, status, errorThrown) {     
            $("#dla_main_div").html('<p class="bg-danger">"Error: " + errorThrown</p>');
        })

        .always(function (xhr, status) {
            
        });
});
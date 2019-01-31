$.date = function (dateObject) {
    var d = new Date(dateObject);
    var day = d.getDate();
    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    if (day < 10) {
        day = "0" + day;
    }
    if (month < 10) {
        month = "0" + month;
    }
    var date = year + "-" + month + "-" + day;

    return date;
};

$(document).ready(function () {
    $("#dla_main_div").html('<p class="bg-success">Downloading dangers list</p>');
    let url = '/Home/DangersAjaxData';
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json"
    })
        .done(function (json) {
            $("#dla_main_div").html('<p class="bg-success">List downloaded</p>');
            let tabela = '<table class="table table-condensed"><tr><th>Data zgłoszenia</th><th>Adres</th><th>Dzielnica</th>';
            tabela += '<th>Miasto</th> <th>Lokalizacja</th> <th>Kategoria</th> <th>Podkategoria</th> <th>Źródło</th>';
            tabela += '<th>Typ zgłoszenia</th><th>Status zgłoszenia</th></tr>';
            json.forEach(function (zgloszenie) {
                let street = zgloszenie.street ? zgloszenie.street : '';
                let street2 = zgloszenie.street2 ? zgloszenie.street2 : '';
                let district = zgloszenie.district ? zgloszenie.district : '';
                let city = zgloszenie.city ? zgloszenie.city : '';
                let category = zgloszenie.category ? zgloszenie.category : '';
                let subcategory = zgloszenie.subcategory ? zgloszenie.subcategory : '';
                let Source = zgloszenie.Source ? zgloszenie.Source : '';
                let notificationType = zgloszenie.notificationType ? zgloszenie.notificationType : '';

                tabela += '<tr><td>' + $.date(new Date(zgloszenie.createDate)) + '</td><td>' + street + street2 + '</td>';
                tabela += '<td>' + district+'</td><td>' + city + '</td>';
                tabela += '<td><a target="_blank" href="https://www.google.pl/maps/@' + zgloszenie.yCoordWGS84 + ',' + zgloszenie.xCoordWGS84 + ',16z">Mapa</a></td>';
                tabela += '<td>'+ category + '</td><td>'+ subcategory + '</td>';
                tabela += '<td>'+ Source + '</td><td>'+ notificationType + '</td><td>';
                zgloszenie.statuses.forEach(function (status) {
                    tabela += '<div>' + status.status + '-' + $.date(new Date(status.changeDate)) + '</div>';
                });
                tabela +='</td></tr>';
            });
            $("#dla_data_div").html(tabela);

        })

        .fail(function (xhr, status, errorThrown) {     
            $("#dla_main_div").html('<p class="bg-danger">"Error: " + errorThrown</p>');
        })

        .always(function (xhr, status) {
            
        });
});

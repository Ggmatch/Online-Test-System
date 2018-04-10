$(document).ready(function () {
    // Send an AJAX request
    $.getJSON("http://localhost:2838/api/administrator/test")
        .done(function (data) {
            // On success, 'data' contains a string
            alert(data)
        });
        }).fail(alert("fail"));
});
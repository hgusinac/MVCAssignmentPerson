


function closePeopleDetails(id, event) {
    event.preventDefault();

    var endDetailsURL = event.target.href;

    $.post(endDetailsURL, { id: id },
        function (data, status) {
            console.log("Data:" + data + "\nStatus: " + status);
            $("#person" + id).replaceWith(data);
        }
    );
}

function detailsPerson(id, event) {
    event.preventDefault();

    var detailsURL = event.target.href;
    $.post(detailsURL, { id: id },
        function (data, status) {
            console.log("Data:" + data + "\nStatus: " + status);
            $("#person" + id).replaceWith(data);
        }
    );

}

function deletePerson(element, event) {
    event.preventDefault();
    console.log(element);
    console.log(event);

    var deleteURL = event.target.href;

    $.get(deleteURL, function (data, status) {
        alert("Data: " + data + "\nStatus: " + status);
        console.log(deleteURL);
        console.log(data);
        $("#" + data).remove();
    })

}
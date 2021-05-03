function getAll() {
    $.get("/Ajax/GetAll", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);

        $("#result").html(data);
    });

}

function personDetails() {


    var personId = document.getElementById("personId").value;
    console.log("personId:", personId);

    $.post("/Ajax/PartialDetails",//url, Ajax och metoden i controllern. 
        {
            id: personId
        },
        function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);

            $("#result").html(data);
        }
    );
}

function deletePerson() {


    var personId = document.getElementById("personId").value;
    console.log("personId:", personId);

    $.post("/Ajax/Delete",
        {
            id: personId
        },
        function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);

            alert("Delete success");
        }
    ).fail(function (jqXHR, textStatus, errorThrown) {
        console.log("jqXHR", jqXHR);
        console.log("textStatus", textStatus);
        console.log("errorThrown", errorThrown);
        if (jqXHR.status == 404) {
            alert("Person not found.\n Was not able to delete the Person whit Id:" + personId)
        }
        else {
            alert("Status: " + jqXHR.status);
        }
    });
}
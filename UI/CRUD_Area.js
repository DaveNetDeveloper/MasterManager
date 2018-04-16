function GetAreaById(idArea) {
    var areaInPut = {};
    areaInPut.Id = idArea;

    $.ajax({
        type: "POST",
        url: "../WebServices/wsVisitante.asmx/GetById",
        async: true,
        data: "{pArea:" + JSON.stringify(areaInPut) + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            var areaOutPut = data.d;
            $("#ContainerAreaById").html("Id = " + areaOutPut.Id + " = " + areaOutPut.IP);
            //alert("El DIV con id 'Container' contiene:  " + $("#ContainerAreaById").html());
            //debugger;
        },
        error: function (error) {
            alert(error.responseText);
            //debugger;
        }
    });
}
function GetAllAreas() {
    $.ajax({
        type: "POST",
        url: "../WebServices/wsVisitante.asmx/GetAllAreas",
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            if (data.d.length > 0) {
                $("#ContainerAllAreas").empty();
            }

            var hrElement = document.createElement("hr");
            $("#ContainerAllAreas").append(hrElement);
            data.d.forEach(function (area) {

                var itemCcontent = area.Id.toString() + " - " + area.IP + " - " + area.Region + " - " + area.Ciudad;
                var pElement = document.createElement("p");
                pElement.id = "p" + area.Id.toString();
                pElement.innerHTML = itemCcontent;

                $("#ContainerAllAreas").append(pElement);
            });
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}
function DeleteAreaById(idArea) {
    $.ajax({
        type: "POST",
        url: "../WebServices/wsVisitante.asmx/EliminarAreaById",
        async: true,
        data: "{idArea:" + JSON.stringify(idArea) + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d)
                alert('El area ' + idArea + ' se ha borrado correctamente');
            else
                alert('El borrado del area ha fallado');
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}
function CreateArea(nombreArea) {
    $.ajax({
        type: "POST",
        url: "../WebServices/wsVisitante.asmx/InsertarArea",
        async: true,
        data: "{nombreArea:" + JSON.stringify(nombreArea) + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d)
                alert('El area [' + nombreArea + '] se ha creado correctamente');
            else
                alert('La creación del area ha fallado');
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}
function UpdateAreaById(idArea, nombreArea) {
    $.ajax({
        type: "POST",
        url: "../WebServices/wsVisitante.asmx/UpdateAreaById",
        async: true,
        data: "{idArea:" + JSON.stringify(idArea) + ", nombreArea:" + JSON.stringify(nombreArea) + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d)
                alert('El area ' + idArea + ' se ha modificado correctamente');
            else
                alert('La modificación del area ha fallado');
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}
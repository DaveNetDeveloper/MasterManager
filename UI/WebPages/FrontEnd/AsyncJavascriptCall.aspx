<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/UI/WebPages/FrontEnd/AsyncJavascriptCall.aspx.cs" Inherits="AsyncJavascriptCall" %> 
<%@ Register Src="~/UI/UserControls/DbEntities/EntityList.ascx" TagPrefix="uc" TagName="EntityList" %>

<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Async Javascript Call Page</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <style type="text/css"> 
        .gridClass th
            {  
                text-align: center;
                
            }
        .gridClass th
        {       
                background-image: linear-gradient(to bottom,#337ab7 0,#265a88 100%);
                color: #ffffff;
                font-weight: bold;
                text-transform: uppercase;
                height: 31px;
                font-size: 0.9em;
                cursor: pointer;
                border: none; 

                
        }
        .gridClass th:hover
        {       
                border-right: 2px solid #FFFFFF;
                color: #ffffff; 
                text-transform: uppercase;
                height: 31px;
                font-size: 0.9em; 
                font-weight: bold;
                border: none;
        }
        .gridClass td
        {
            font-size: 14px;
            border: none;
            font-weight: 100; 
             border-left: 2px solid #FFFFFF;    
        } 
        .gridClass tr
        {
                height: 40px;
                border: none;
                border: 1px solid #D8D8D8 !important;
        } 
        .gridClass tr:hover
        {
            /*background-color: #367fc3; 
            color: white;
            cursor: pointer;*/ 
            /* opacity: 0.8; */

            background-image: -webkit-linear-gradient(top,#fff 0,#F2F2F2  100%);
            background-image: -o-linear-gradient(top,#fff 0,#F2F2F2  100%);
            background-image: -webkit-gradient(linear,left top,left bottom,from(#fff),to(#F2F2F2 ));
            background-image: linear-gradient(to bottom,#fff 0,#F2F2F2  100%);

        } 
        .gridClass td:hover
        {
            /*background-color: #367fc3; 
            /*color: white;*/
            cursor: pointer; 
        } 

        .buttondisable
        { 
            background-image: -webkit-linear-gradient(top,#F5F5DC 0,#ffffff 100%);
            background-image: -o-linear-gradient(top,#F5F5DC 0,#ffffff 100%);
            background-image: -webkit-gradient(linear,left top,left bottom,from(#F5F5DC),to(#ffffff));
            background-image: linear-gradient(to bottom,#F5F5DC 0,#ffffff 100%); 
            background-repeat: repeat-x; 
            border-color: darkgray;

        } 
        .buttondisable:hover
        { 
            color:#337ab7;
        } 
        
        a:hover 
        {
            text-decoration: none;
        }
    </style>  
</head> 
<body>
<form id="form" runat="server"> 
    <div>
        <br />
        <input id="inputIdArea" type="text" value="" /> 
        <input id="btnGetAreaById" type="button" value="Cargar un area desde base de datos" onclick="GetAreaById($('#inputIdArea').val());" />
        <div id="ContainerAreaById"></div> 
        <br />
        <hr />
        <br />
        <input id="btnGetAllAreas" type="button" value="Cargar todas las areas desde base de datos" onclick="GetAllAreas();" />
        <div id="ContainerAllAreas"></div>
        <br />
        <hr /> <br />
        <label id="inputLabel">Id del area a eliminar</label>
        <input id="inputEliminarArea" type="text" value="" /> 
        <input id="btnEliminarAreaById" type="button" value="Eliminar area" onclick="DeleteAreaById($('#inputEliminarArea').val());" />
        <hr />
        <br />
        <label id="inputLabelInsertar">Insertar nueva area con el siguiente nombre</label>
        <input id="inputNombreArea" type="text" value="" /> 
        <input id="btnInsertarArea" type="button" value="Insertar nueva area" onclick="CreateArea($('#inputNombreArea').val());" />
        <br />
        <br />
         <hr />
        <label id="inputLabelUpdateId">Actualizar el area</label>
        <input id="inputUpdateAreaId" type="text" value="" /> 
        <label id="inputLabelUpdateNombre">con el siguiente nombre</label>
        <input id="inputUpdateAreaNombre" type="text" value="" /> 
        <input id="btnUpdateArea" type="button" value="Modificar area existentes" onclick="UpdateAreaById($('#inputUpdateAreaId').val(), $('#inputUpdateAreaNombre').val());" />
    </div>
    <br /><br />
    <uc:EntityList runat="server" BussinesObject="Documento" ID="LisOftDocuments" /> 
</form>
</body>

<%--Registrar creación de objeto de tipo interface mediante componente TypeScript--%>
<%--<script src="../TypeScripts/TsAreas.ts" type="text/javascript"></script>--%>

<script type="text/javascript">

    function GetAreaById(idArea) { 

        //Para trabajar con la interface IModel en vez del type concreto ModelArea
        //var pIModel = GetInitializedIModel(idArea);

        var pModel = {};
        pModel.Id = idArea;  

        $.ajax({
            type: "POST",
            url: "../WebServices/WsAreas.asmx/GetById",
            async: true,
            data: "{pModel:" + JSON.stringify(pModel) + "}",
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
            url: "../WebServices/WsAreas.asmx/GetAll",
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
            url: "../WebServices/WsAreas.asmx/EliminarById",
            async: true,
            data: "{id:" + JSON.stringify(idArea) + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
              //  if (data.d)
                    //alert('El area ' + idArea + ' se ha borrado correctamente');
              //  else
                    //alert('El borrado del area ha fallado');
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    }
    function CreateArea(nombreArea) {

        $.ajax({
            type: "POST",
            url: "../WebServices/WsAreas.asmx/Insertar",
            async: true,
            data: "{nombre:" + JSON.stringify(nombreArea) + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
              //  if (data.d)
                    //alert('El area [' + nombreArea + '] se ha creado correctamente');
               // else
                    //alert('La creación del area ha fallado');
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    }
    function UpdateAreaById(idArea, nombreArea) { 
        $.ajax({
            type: "POST",
            url: "../WebServices/WsAreas.asmx/UpdateById",
            async: true,
            data: "{id:" + JSON.stringify(idArea) + ", nombre:" + JSON.stringify(nombreArea) + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
               // if (data.d)
                    //alert('El area ' + idArea + ' se ha modificado correctamente');
               // else
                    //alert('La modificación del area ha fallado');
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    }
</script>  
</html> 
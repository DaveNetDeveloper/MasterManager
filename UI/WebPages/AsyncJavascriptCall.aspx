<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/UI/WebPages/AsyncJavascriptCall.aspx.cs" Inherits="AsyncJavascriptCall" %> 

<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Async Javascript Call Page</title>
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

    <%--<script src="../CRUD_Area.js"></script>--%>

</head> 
<body>
    <form id="form" runat="server"> 
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

        <%--       <asp:GridView Visible="false" ID="gvDocumentos" Width="100%" runat="server" OnRowDataBound="gvDocumentos_RowDataBound" OnRowCommand="gvDocumentos_RowCommand" DataKeyNames="Id" AutoGenerateColumns="false" CssClass ="gridClass" EmptyDataText="No hay datos.">
        <Columns> 
              <asp:TemplateField>
                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                <ItemStyle HorizontalAlign="Center" Width="50px" />
                <HeaderTemplate> 
                        <asp:CheckBox AutoPostBack="false" OnCheckedChanged="chkSelAll_Checked"  Enabled="true"  ID="chkSel" CssClass="chkSel" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox AutoPostBack="false" onClick="$('#buttonDonwload').addClass('btn-primary');$('#buttonDonwload').removeClass('buttondisable');" Enabled="true"  ID="chkSel" CssClass="chkSel" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="IP" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderText="IP" />

            <asp:BoundField DataField="Id" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" HeaderText="Id" />

            <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderText="Region" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblRegion" Text='<%# Eval("Region") + " x" %>'></asp:Label> 
            </ItemTemplate>
            </asp:TemplateField>  
             
            <asp:BoundField DataField="Ciudad" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="125px" HeaderText="Ciudad" />
             
            <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderStyle-VerticalAlign="Middle" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
            <ItemTemplate> 
                    <asp:ImageButton ImageAlign="Middle" CommandName='<%# Eval("Ubicacion") %>' Height="25px" ImageUrl='<%# Eval("Tipo").Equals("pdf") ? "~/Images/pdf.png" : "~/Images/doc.png" %>' ID="btnVerDocumento" 
                                     runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
            </ItemTemplate>
            </asp:TemplateField> 
        </Columns>
        </asp:GridView>--%>

    </form>
</body>   
     
<script type="text/javascript">

    function GetAreaById(idArea) { 
        var areaInPut = {};
        areaInPut.Id = idArea;  

        $.ajax({
            type: "POST",
            url: "../WebServices/wsAreas.asmx/GetById",
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
            url: "../WebServices/wsAreas.asmx/GetAllAreas",
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
            url: "../WebServices/wsAreas.asmx/EliminarAreaById",
            async: true,
            data: "{idArea:" + JSON.stringify(idArea) + "}",
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
            url: "../WebServices/wsAreas.asmx/InsertarArea",
            async: true,
            data: "{nombreArea:" + JSON.stringify(nombreArea) + "}",
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
            url: "../WebServices/wsAreas.asmx/UpdateAreaById",
            async: true,
            data: "{idArea:" + JSON.stringify(idArea) + ", nombreArea:" + JSON.stringify(nombreArea) + "}",
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
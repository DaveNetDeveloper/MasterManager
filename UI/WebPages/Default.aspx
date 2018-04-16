<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/UI/WebPages/Default.aspx.cs" Inherits="Default" %> 

<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Default Page</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.1.min.js"></script>   
</head> 
<body>
    <form id="form" runat="server"> 
        <input name="inputIdArea" type="text" value="" /> 
        <input id="btnGetAreaById" type="button" value="Cargar un area desde base de datos" onclick="GetAreaById(document.getElementsByName('inputIdArea')[0].value);" />
        <div id="ContainerAreaById"></div> 
        <br />
        <hr />
        <br />
        <input id="btnGetAllAreas" type="button" value="Cargar todas las areas desde base de datos" onclick="javascript:GetAllAreas();" />
        <div id="ContainerAllAreas"></div>
        <br /><br />
        <hr />
        <label id="inputLabel">Id del area a eliminar</label>
        <input name="inputEliminarArea" type="text" value="" /> 
        <input id="btnEliminarAreaById" type="button" value="Eliminar area" onclick="javascript: EliminarAreaByIdArea(document.getElementsByName('inputEliminarArea')[0].value);" />
        <hr />

        <label id="inputLabelInsertar">Insertar nueva area con el siguiente nombre</label>
        <input name="inputNombreArea" type="text" value="" /> 
        <input id="btnInsertarArea" type="button" value="Insertar nueva area" onclick="javascript:InsertarArea(document.getElementsByName('inputNombreArea')[0].value);" />

         <hr />
        <label id="inputLabelUpdateId">Actualizar el area</label>
        <input name="inputUpdateAreaId" type="text" value="6" /> 
        <label id="inputLabelUpdateNombre">con el siguiente nombre</label>
        <input name="inputUpdateAreaNombre" type="text" value="" /> 
        <input id="btnUpdateArea" type="button" value="Modificar area existentes" onclick="javascript: UpdateAreaByIdArea(document.getElementsByName('inputUpdateAreaId')[0].value, document.getElementsByName('inputUpdateAreaNombre')[0].value);" />

        <asp:GridView Visible="false" ID="gvDocumentos" Width="100%" runat="server" OnRowDataBound="gvDocumentos_RowDataBound" OnRowCommand="gvDocumentos_RowCommand" DataKeyNames="Id" AutoGenerateColumns="false" CssClass ="gridClass" EmptyDataText="No hay datos.">
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
             
            <%--<asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderStyle-VerticalAlign="Middle" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
            <ItemTemplate> 
                    <asp:ImageButton ImageAlign="Middle" CommandName='<%# Eval("Ubicacion") %>' Height="25px" ImageUrl='<%# Eval("Tipo").Equals("pdf") ? "~/Images/pdf.png" : "~/Images/doc.png" %>' ID="btnVerDocumento" 
                                     runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
            </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
        </asp:GridView>
    </form>
</body> 
<script type="text/javascript">
    function GetAreaById(idArea) { 
        var visitante = {};
        visitante.Id = idArea;
        //visitante.NavegadorCookkies = navigator.cookieEnabled;
        //visitante.NavegadorPlataforma = navigator.platform
        //visitante.IP = '';
             
        $.ajax({
            type: "POST",
            url: "../WebServices/wsVisitante.asmx/GetById",
            async: true,
            data: "{pVisitante:" + JSON.stringify(visitante) + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var visitante = data.d;
                $("#ContainerAreaById").html("Id = " + visitante.Id + " = " + visitante.IP);
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
            url: "../WebServices/wsVisitante.asmx/GetVisitors",
            async: true,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                if (data.d.length > 0) {
                    $("#ContainerAllAreas").empty();
                }

                var hrElement = document.createElement("hr");
                $("#ContainerAllAreas").append(hrElement);
                data.d.forEach(function (visitante) {

                    var itemCcontent = visitante.Id.toString() + " - " + visitante.IP + " - " + visitante.Region + " - " + visitante.Ciudad;
                    var pElement = document.createElement("p");
                    pElement.id = "p" + visitante.Id.toString();
                    pElement.innerHTML = itemCcontent;

                    $("#ContainerAllAreas").append(pElement);
                });
                
            },
            error: function (error) {
                alert(error.responseText);
            }
        }); 
    }  
    function EliminarAreaByIdArea(idArea) {
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
    function InsertarArea(nombreArea) {
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
    function UpdateAreaByIdArea(idArea, nombreArea) { 
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
</script> 
</html> 
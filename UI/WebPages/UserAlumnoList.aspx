<%@ Page Title="UserAlumnoList" Language="C#"  AutoEventWireup="true" CodeFile="UserAlumnoList.aspx.cs" Inherits="UserAlumnoList" %>
 
<%@ Import Namespace="System.Resources" %>
 
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Lista de Alumnos</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
 
    <script type = "text/javascript">
         
        function EnviarSMS() {

            $.ajax({
                type: "POST",
                url: "UserAlumnoList.aspx/EnviarSMS",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessEnviarSMS,
                failure: function (response) {

                    //alert('FAIL');
                }
            });
        }

        function OnSuccessEnviarSMS(response) {
            //alert('response.d --> ' + response.d);

            var confirmText = '';
            var alertText = '';

            if (response.d > 0) {

                confirmText = '¿Está seguro de que quiere enviar un sms al usuario seleccionado?';
                alertText = '';
            }
            else if (response.d == -1) {

                confirmText = '¿Está seguro de que quiere enviar un sms los usuarios seleccionados?';
                alertText = '';
            }
            else if (response.d == 0) {
                //confirmText = 'Al menos un elemento de la lista ha de estar seleccionado.';
                alertText = 'Al menos un usuario de la lista ha de estar seleccionado.';
            }

            if (alertText == '' && confirm(confirmText)) {
                __doPostBack('EnviarSMS', 'EnviarSMS');
            }
            else {
                alert(alertText.toString());
            }
        }

        function Eliminar() {

            /*if (confirm("¿Está seguro de que quiere eliminar los elementos seleccionados?")) {
                __doPostBack('Eliminar', 'Eliminar');

            }*/

            $.ajax({
                type: "POST",
                url: "UserAlumnoList.aspx/Eliminar",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessEliminar,
                failure: function (response) {

                    //alert('FAIL');
                }
            });
        }

        function OnSuccessEliminar(response) {
            //alert('response.d --> ' + response.d);

            var confirmText = '';
            var alertText = '';

            if (response.d > 0) {

                confirmText = '¿Está seguro de que quiere eliminar el elemento seleccionados?';
                alertText = '';
            }
            else if (response.d == -1) {

                confirmText = '¿Está seguro de que quiere eliminar los elementos seleccionados?';
                alertText = '';
            }
            else if (response.d == 0) {
                //confirmText = 'Al menos un elemento de la lista ha de estar seleccionado.';
                alertText = 'Al menos un elemento de la lista ha de estar seleccionado.';
            }

            if (alertText == '' && confirm(confirmText)) {
                __doPostBack('Eliminar', 'Eliminar');
            }
            else {
                alert(alertText.toString());
            }

        }

        function ExportarExcel() {

            __doPostBack('ExportarExcel', 'ExportarExcel');

        }
        //Page print
        function Imprimir() {
            //window.print();
            var ficha = document.getElementById('divToPrint'); var ventimp = window.open(' ', 'popimpr'); ventimp.document.write(ficha.innerHTML); ventimp.document.close(); ventimp.print(); ventimp.close();
        }

    </script> 

    <link rel="stylesheet" href="css/reveal.css" />
	<script type="text/javascript" src="js/jquery.reveal.js"></script>

    <script type="text/javascript" >

        $(document).ready(function () {
            $(".close-reveal-modal").click(function () {
                $(".reveal-modal").hide();
                $(".reveal-modal-bg").hide();
            });

            $("#btnCancelarModal").click(function () {
                $(".reveal-modal").hide();
                $(".reveal-modal-bg").hide();
            });
        });

    </script> 

    <script type="text/javascript">

        $(function () {
            $("#<%= gvPrivateUser.ClientID %> tr").hover(
                function () {

                    if ($(this).hasClass('pgr')) {

                        //nothing
                        //  alert('tiene pgr');
                    }
                    else {
                        //alert('no tiene pgr, le añadimos highlight');
                        $(this).addClass('highlight');
                    }

                },
                function () {
                    $(this).removeClass('highlight');
                }
            )
        })

    </script>

    <%--Page content Styles --%>
    <style type="text/css">

    .marginrRight 
    { 
        float: right; 
    }

  
</style>
         
    <!-- Style Buttons -->
    <link rel="stylesheet" href="css/css3-buttons.css" type="text/css"  media="screen" />
   
    <script type="text/javascript">
 
    function Editar() {
        __doPostBack('Editar', 'Editar');
    }

    function Crear() {
        __doPostBack('Crear', 'Crear');
    }

    function Ver() {
        __doPostBack('Ver', 'Ver');
    }
 
    function FiltrarListado() {
        __doPostBack('FiltrarListado', 'FiltrarListado');
    }
         
    </script>
    
    <!-- Kept Scroll Window--> 
    <script>
        window.onload = function () {
            var pos = window.name || 0;
            window.scrollTo(0, pos);
        }
        window.onunload = function () {
            window.name = self.pageYOffset || (document.documentElement.scrollTop + document.body.scrollTop);
        }
    </script>
</head>
<body>
    <form id="form" runat="server">
    <div id="divToPrint">
        <asp:GridView   ID="gvPrivateUser" ClientIDMode="Static"
                        FooterStyle-CssClass="mGrid"
                        HeaderStyle-Font-Bold="true"
                        HeaderStyle-BackColor="Transparent" 
                        HeaderStyle-HorizontalAlign="Center" 
                        HeaderStyle-Height="40px" 
                        DataKeyNames="ID"
                        runat="server"
                        AutoGenerateColumns="False" 
                        GridLines="Horizontal"
                        AllowPaging="true"
                        OnPageIndexChanging="gvPrivateUser_Paging"
                        AllowSorting="true"
                        OnSorting="gvPrivateUser_Sorting"          
                        CssClass="mGrid"  
                        PagerStyle-CssClass="pgr" 
                        PageSize="15"
                        ShowFooter="false" 
                        AutoGenerateSelectButton="False"
                        PagerStyle-Font-Bold="true" 
                        PagerStyle-HorizontalAlign="Center" 
                        PagerStyle-Height="40px"       
                        OnRowDataBound="gvPrivateUser_RowDataBound" >
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" Position="Bottom" />
        <HeaderStyle Font-Bold="true" BackColor="DimGray" />
        <Columns>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" Width="40px" />
                <HeaderTemplate> 
                        <asp:CheckBox AutoPostBack="true" OnCheckedChanged="chkSelAll_Checked" Enabled="true"  ID="chkSel" CssClass="chkSel" runat="server" />
                </HeaderTemplate>

                <ItemTemplate>
                    <asp:CheckBox AutoPostBack="true" OnCheckedChanged="chkSel_Checked" Enabled="true"  ID="chkSel" CssClass="chkSel" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="ID" DataField="ID" HeaderText="ID" ItemStyle-Width="20px" ItemStyle-Height="35"/>
            
           <asp:TemplateField Visible="false" ItemStyle-Width="175px" HeaderStyle-Width="175px" SortExpression="name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">              
                 <HeaderTemplate> 
                             <asp:Label ID="lblCompleteName" Text="Nombre" runat="server"></asp:Label>
                </HeaderTemplate>
               <ItemTemplate>
                    <asp:Label ID="lblCompleteName" Text='<%#Eval("name").ToString().Insert(Eval("name").ToString().Length, " " + Eval("surname").ToString())%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" SortExpression="name" DataField="name" HeaderText="Nombre" ItemStyle-Width="125px" ItemStyle-Height="35" />
            
            <asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" SortExpression="mail" DataField="mail" HeaderText="Mail" ItemStyle-Width="150px" ItemStyle-Height="35" />
            
            <asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" SortExpression="phone" DataField="phone" HeaderText="Teléfono" ItemStyle-Width="100px" ItemStyle-Height="35" />

            <asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" SortExpression="user_name" DataField="user_name" HeaderText="Usuario" ItemStyle-Width="100px" ItemStyle-Height="35" />
            
            <asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" SortExpression="password" DataField="password" HeaderText="Contraseña" ItemStyle-Width="100px" ItemStyle-Height="35" />
           
            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-Width="80px" SortExpression="entered" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">                 
                  <HeaderTemplate>
                    <asp:Label Visible="true" ID="lblEntered" Text="Ha Accedido" runat="server"></asp:Label>
                </HeaderTemplate> 
                <ItemTemplate>
                    <asp:RadioButton ID="rbtnEntered" Enabled="false" runat="server"></asp:RadioButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField Visible="false">                 
                <ItemTemplate>
                    <asp:HiddenField ID="hdnEntered" Value='<%#Eval("entered") %>' runat="server"></asp:HiddenField>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-Width="80px" SortExpression="active" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">                 
                  <HeaderTemplate>
                    <asp:Label Visible="true" ID="lblActive" Text="Activo" runat="server"></asp:Label>
                </HeaderTemplate> 
                <ItemTemplate>
                    <asp:RadioButton ID="rbtnActive" Enabled="false" runat="server"></asp:RadioButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField Visible="false">                 
                <ItemTemplate>
                    <asp:HiddenField ID="hdnActive" Value='<%#Eval("active") %>' runat="server"></asp:HiddenField>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#c1c1c1" BorderWidth="1" ForeColor="#c1c1c1" />
        </asp:GridView>
    </div>
     

    <asp:Button runat="server" ID="btnEnvioSMS"  visible="false" Text="Enviar SMS" />

    <asp:Label ID="lblNoRecords" Text="No records to display" runat="server" Visible="false" ForeColor="red"></asp:Label>

    <br /><br />
          
    <asp:Button Visible="false" Text="Exportar a Excel" Enabled="true" runat="server" ID="btnExportExcel" style="border-radius:0px" CssClass="blue" Width="150px" OnClick="btnExport_Click" meta:resourcekey="ExportToExcel" />
    <asp:Button Visible="false" Text="Exportar a Pdf" Enabled="true" runat="server" ID="btnExportPDF" style="border-radius:0px" CssClass="blue" Width="150px" meta:resourcekey="ExportToExcel" />
    
    <br /><br />

    <div runat="server" id="divResultadoEnvioSMS">
    </div>
    
    <br />
    
    <!-- Modal para Confirmación de cambio de contraseña-->
    <div id="mySMSModalPanel" runat="server" style="font-family: Verdana;visibility:hidden;" class="reveal-modal">

        <h2 style="font-family: Verdana;font-size: 20px;text-transform: uppercase;">
            ENVÍO DE SMS
        </h2>
        <br /><br />
        
        <h3>
            ¿Desea enviar un SMS con el siguiente contenido y a los destinatarios indicados?
        </h3>
        <br />

        <label><b>MENSAJE</b></label>
        <asp:TextBox runat="server" Width="425px" Height="120px" ID="txtContenidoSMS" TextMode="MultiLine" Text=""></asp:TextBox>
        
         <br /><br />

        <asp:Label runat="server" ID="lblRecuerda"></asp:Label>
        <br /><br />

        <label><b>DESTINATARIOS</b></label>
        <asp:TextBox Enabled="false" Width="425px" Height="150px" runat="server" ID="txtDestinatariosSMS" TextMode="MultiLine"></asp:TextBox>

        <br /><br />
       

        <asp:Button Text="Confirmar Envío" OnClick="btnEnviarSMS_Click" ID="btnEnviarSMS" runat="server" style="font-family: Verdana;font-size: 14px;cursor: pointer;margin-left: -5px;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;width: 190px;"/>

        <input type="button" id="btnCancelarModal" value="Cancelar" style="margin-left: 40px;font-family: Verdana;font-size: 14px;cursor: pointer;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;width: 190px;"/>
        
        <a class="close-reveal-modal">×</a>

	</div>

    <div class="reveal-modal-bg" id="mySMSModalBackground" runat="server" style="display: none; cursor: pointer;"></div>
 
    </form>
</body>  
</html>
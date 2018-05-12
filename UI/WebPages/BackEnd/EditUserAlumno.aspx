<%@ Page  Title="EditUserAlumno" Language="C#" AutoEventWireup="true" CodeFile="~/UI/WebPages/BackEnd/EditUserAlumno.aspx.cs" Inherits="EditUserAlumno" %>
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
    <title title="Edición de un alumno"></title> 
    <script type="text/javascript" src="js/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.0.custom.min.js"></script>
    <link rel="stylesheet" href="css/jquery-ui-1.10.0.custom.min.css" type="text/css"/>
	<style type="text/css">
        body { font-family: "HelveticaNeue","Helvetica-Neue", "Helvetica", "Arial", sans-serif; }
        .big-link { display:block; text-align: center; font-size: 70px; color: #06f; }
	</style>
<%--    <script type="text/javascript">

        //AJAX for web method Guardar()
        function Guardar() {

            alert("Guardar");

            $.ajax({
                type: "POST",
                url: "EditUserAlumno.aspx/Guardar",
                data: '{name: "param"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert('ERROR: ' + response.d);
                }
            });
        }

        function OnSuccess(response) {

            alert(response.d);
            if (response.d == "OK")
            {
                window.location.href = 'http://up2web.es/EscuelaNauticaSantalo_ContentManager/UserAlumnoList.aspx';
            }
        }

    </script>--%>
</head> 
<body>

    <form id="form" runat="server">

    <div>
         <asp:Button OnClick="SaveModelClick" runat="server" style="float: right;width: 105px;height:26px;font-family:Verdana;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;" id="btnGuardar" class="action" Text="Guardar" />
        <div id="emptyDiv" runat="server" style="width:25px;float: right;">&nbsp</div>
        <asp:Button id="btnVolver" OnClick="GoBackClick" Text="Volver" runat="server" style="float: right; width: 105px;height:26px;font-family:Verdana;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;" />
    </div>
    
    <br /><br /><br />

    <div style="text-align:left;" class="form_row clearfix link">
        <table>
            <tr>
                <td style="width: 200px;">
                    <label  class="control-label required" for="privateUserName">NOMBRE:</label>
                </td>
                 <td>
                    <asp:TextBox Width="350px"  BorderWidth="1px" runat="server"  ID="privateUserName" name="privateUserName"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>

    <div style="text-align:left;" class="form_row clearfix link">
        <table>
            <tr>
                <td style="width: 200px;">
        <label  class="control-label required" for="privateUserSurname">APELLIDOS:</label>
                     </td>
             <td>
        <asp:TextBox Width="350px"  BorderWidth="1px" runat="server" ID="privateUserSurname" name="privateUserSurname"></asp:TextBox>
                </tr>
        </table>
    </div>
    <div style="text-align:left;" class="form_row clearfix link">
         <table>
            <tr>
                <td style="width: 200px;">
        <label  class="control-label required" for="privateUserMail">EMAIL:</label>
       </td>
                 <td>
         <asp:TextBox Width="350px"  BorderWidth="1px" runat="server" ID="privateUserMail" name="privateUserMail"></asp:TextBox>
                        </td>
            </tr>
        </table>
    </div>

    <div style="text-align:left;" class="form_row clearfix link">
          <table>
            <tr>
                <td style="width: 200px;">

        <label  class="control-label required" for="privateUserBirthDate">FECHA DE NACIMIENTO:</label>
                      </td>
                 <td>

        <asp:TextBox Width="350px" Text="dd/mm/aaaa"  BorderWidth="1px" runat="server" ID="privateUserBirthDate" name="privateUserBirthDate"></asp:TextBox>
      </td>
            </tr>
        </table>
                     </div>

    <div style="text-align:left;" class="form_row clearfix link">
         <table>
            <tr>
                <td style="width: 200px;">
        <label class="control-label required" for="privateUserPhone">TELÉFONO:</label>
          </td>
                 <td>
                     <asp:TextBox Width="350px"  BorderWidth="1px" runat="server" ID="privateUserPhone" name="privateUserPhone"></asp:TextBox>
                      </td>
            </tr>
        </table>
    </div>

    <div style="text-align:left;" class="form_row clearfix link">
          <table>
            <tr>
                <td style="width: 200px;">
        <label class="control-label required" for="privateUserUserName">NOMBRE DE USUARIO:</label>
         </td>
                 <td>
         <asp:TextBox Width="350px"  BorderWidth="1px" runat="server"  ID="privateUserUserName" name="privateUserUserName"></asp:TextBox>
         </td>
            </tr>
        </table>
    </div>

    <div style="text-align:left;" class="form_row clearfix link">
          <table>
            <tr>
                <td style="width: 200px;">
         <label class="control-label required" for="privateUserPassword">CONTRASEÑA:</label>
                     </td>
                 <td>
         <asp:TextBox Width="350px"  BorderWidth="1px" runat="server"   ID="privateUserPassword" name="privateUserPassword"></asp:TextBox>
                      </td>
            </tr>
        </table>
    </div>

    <div title="Este campo es auto-caulculado por el sistema." style="text-align:left;" class="form_row clearfix link">
         <table>
            <tr>
                <td style="width: 200px;">
                     <label class="control-label required" for="privateUserEntered">HA ACCEDIDO?:</label>
                     </td>
                 <td>
         <asp:CheckBox Width="350px"  BorderWidth="0px" runat="server" ID="privateUserEntered" name="privateUserEntered"></asp:CheckBox>
                      </td>
            </tr>
        </table>
    </div>

    <div style="text-align:left;" class="form_row clearfix link">
          <table>
            <tr>
                <td style="width: 200px;">
                    <label class="control-label required" for="privateUserActive">ACTIVO:</label>
                     </td>
                 <td>
         <asp:CheckBox Width="350px"  BorderWidth="0px" runat="server" ID="privateUserActive" name="privateUserActive"></asp:CheckBox>
                      </td>
            </tr>
        </table>
    </div>

    <div style="text-align:left;" class="form_row clearfix link">
          <table>
            <tr>
                <td style="width: 200px;">
                    <label class="control-label required" for="privateUserCreated">FECHA DE CREACIÓN:</label>
                     </td>
                 <td>
          <asp:TextBox Width="350px"  BorderWidth="1px" runat="server" ID="privateUserCreated" name="privateUserCreated"></asp:TextBox>
                      </td>
            </tr>
        </table>
    </div>

    <div id="divDateUpdated" runat="server" style="text-align:left;" class="form_row clearfix link">
          <table>
            <tr>
                <td style="width: 200px;">
                    <label class="control-label required" for="privateUserUpdated">FECHA DE MODIFICACIÓN:</label>
                     </td>
                 <td>
          <asp:TextBox Width="350px"  BorderWidth="1px" runat="server" ID="privateUserUpdated" name="privateUserUpdated"></asp:TextBox>
                      </td>
            </tr>
        </table>
    </div>

    </form>
</body>  
</html>
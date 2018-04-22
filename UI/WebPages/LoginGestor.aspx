<%@ Page Title="Login" Language="C#" AutoEventWireup="true" EnableEventValidation="true" EnableTheming="true" CodeFile="LoginGestor.aspx.cs" Inherits="LoginGestor" %>

<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="reveal.css" />
	  	 
	<script type="text/javascript" src="jquery.reveal.js"></script>
	
    <style type="text/css">
		body { font-family: Verdana,"HelveticaNeue","Helvetica-Neue", "Helvetica", "Arial", sans-serif; }
		.big-link { display:block; text-align: center; font-size: 70px; color: #06f; }
	</style>

<script type="text/javascript" >

$(document).ready(function()
{
    $(".close-reveal-modal").click(function ()
    {
        $(".reveal-modal").hide();
        $(".reveal-modal-bg").hide();
    });

    $("#btnAceptarModal").click(function () {
        $(".reveal-modal").hide();
        $(".reveal-modal-bg").hide();
 
    });
}); 
  
</script> 

</head> 
<body>
    <form id="form" runat="server">   
    <div style="border-radius: 6px; box-shadow: 0 2px 8px rgba(0, 0, 0, 0.45); border: solid 3px lightgrey;width:750px">

        <hgroup class="title" style="border-bottom: 2px solid lightgray;background-color: #7ac0da;height: 47px;padding-top: 16px;">
            <h1 style="display: inline;font-family: Verdana;font-size: 20px;text-transform: uppercase;color:white;">INICIAR SESIÓN</h1>
        </hgroup>

        <section id="loginForm" style="margin-left: 165px;">

            <div style="">
                <table>
                  <tr style="cursor: default;height:30px">
                        <td style="cursor: default;"" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;"">
                            <asp:Label runat="server" AssociatedControlID="UserName">Nombre de usuario</asp:Label>
                        </td>
                        <td style="width:30px">
                            <!-- espacio -->
                        </td>
                        <td >
                             <asp:TextBox style="font-size: 10pt;background-color:white;" BackColor="white" runat="server" Text="" ID="UserName" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;">
                              <asp:Label runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                        </td>
                        <td style="width:30px">
                            <!-- espacio -->
                        </td>
                        <td>
                            <asp:TextBox runat="server"  style="font-size: 10pt;" Text="" ID="Password" TextMode="Password" />
                        </td>
                    </tr>
                    <tr>
                       <td style="text-align: left;">
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">¿Recordar sesión?</asp:Label>
                        </td>
                         <td style="width:30px">
                            <!-- espacio -->
                        </td> 
                        <td style="text-align: left;">
                             <asp:CheckBox runat="server" ID="RememberMe" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                           <br />

                            <asp:label runat="server" ForeColor="Red" Font-Bold="true" Text="" ID="txtLiteralMessage"></asp:label>
                        </td>
                    </tr>
                    <tr style="height:25px">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"  style="text-align: left;">
                              <asp:Button style="font-size: 14px;cursor: pointer;margin-left: 55px;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;width: 180px;" ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="Iniciar sesión" />
                        </td>
                        <td colspan="1">
                              <asp:Button style="font-size: 14px;cursor: pointer;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;width: 180px;" ID="btnResetPassword" OnClick="btnResetPassword_Click" runat="server" Text="Recordar Password" />
                        </td>
                    </tr>
                    <tr style="cursor: default;height:40px">
                        <td style="cursor: default;"" colspan="3">
                        </td>
                    </tr>
                </table>
            </div>
        </section>
    </div>

    <!-- Modal para Confirmación de cambio de contraseña-->
    <div id="myModal" runat="server" style="font-family: Verdana;visibility:hidden;" class="reveal-modal">

        <h2 style="font-family: Verdana;font-size: 20px;text-transform: uppercase;">
            Contraseña cambiada correctamente.
        </h2  >
        <br /><br />
        <h3>
            Hemos envíado un mail a su dirección de correo electrónico con la nueva contraseña.
        </h3>
        <br /><br />

        <input type="button" id="btnAceptarModal" value="Aceptar" style="font-family: Verdana;font-size: 14px;cursor: pointer;margin-left: -5px;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;width: 190px;"/>
        <a class="close-reveal-modal">×</a>

	</div>

    <div class="reveal-modal-bg" id="myModalBackground" runat="server" style="display: none; cursor: pointer;"></div>
    </form>
</body>  
</html>
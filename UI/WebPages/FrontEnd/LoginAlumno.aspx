<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeFile="LoginAlumno.aspx.cs" Inherits="LoginAlumno" %>
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="<%: ResolveUrl("~/Scripts/jquery.min.cache") %>"></script>
     
        <style type="text/css"> 
        .botonLogin
        {
            background-color: #367fc3;
            color: white;
            width: 200px;
            height: 30px;
            font-weight: bold;
            font-family: Arial;
            font-size: 15px;
            margin-left: 18%;
        }

        .botonLogin:hover
        {
            background-color: white;
            color: #367fc3;
            opacity:1;
        } 
        </style>
     
     <title title="Login"> Iniciar Sesión</title> 
</head> 
<body>
    <form id="form" runat="server">
        <div id="content">
            <div style="padding-top: 15px;padding-bottom: 10px;">

                <table style="width: 70%;margin-left: 21%;">
                    <tr>
                        <td style="text-align: left;width: 45%;">
                            <asp:Label runat="server" ForeColor="#024b94" Font-Bold="true" AssociatedControlID="UserName">USUARIO</asp:Label>
                        </td>
                        <td >
                             <asp:TextBox Width="200px" ForeColor="#024b94" style="font-size: 10pt;background-color:white;" BackColor="white" runat="server" Text=" " ID="UserName" />
                        </td>
                    </tr>
                   <tr style="cursor: default;height:15px">
                        <td style="cursor: default;" "="" colspan="3" class="">
                        </td>
                    </tr>
                    <tr style="margin-top:10px">
                        <td style="text-align: left;">
                              <asp:Label runat="server" ForeColor="#024b94" Font-Bold="true" AssociatedControlID="Password">CONTRASEÑA</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" Width="200px" ForeColor="#024b94" style="font-size: 10pt;" Text=" " ID="Password" TextMode="Password" />
                        </td>
                    </tr>
                     <tr style="cursor: default;height:15px">
                        <td style="cursor: default;" "="" colspan="3" class="">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label   runat="server" ForeColor="Red" Font-Size="0.9em" Font-Bold="true" Text="" ID="txtLiteralMessage"></asp:Label>
                        </td>
                    </tr>
                     <tr style="cursor: default;height:15px">
                        <td style="cursor: default;" "="" colspan="3" class="">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3"  style="text-align: left;">
                              <asp:Button CssClass="botonLogin" ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="ENTRAR" />
                        </td>
                    </tr>
                </table> 
            </div>
        </div>
    </form>
</body>  
</html>
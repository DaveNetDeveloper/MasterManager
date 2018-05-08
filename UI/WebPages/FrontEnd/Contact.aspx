<%@ Page Title="Contacto" Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyA3ndfeZn4Tuk8_DS3bVmKM9YX7odJZzkA&sensor=false"></script>
   
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta charset="utf-8" />

    <script type="text/javascript">
         $(document).ready(function () {
             $('body').hide();
             $('body').fadeIn(2000);
         });
    </script>

    <style type="text/css">
        .botonEnviar
        {
            background-color: white;
            color: #367fc3;
            width: 400px;
            height: 30px;
            font-weight: bold;
            font-family: Arial;
            font-size: 15px;
        }
        .botonEnviar:hover
        {
            background-color: #367fc3;
            color: white;
        }
    </style>
     
     <title title="Escuela Nautica Santaló - Contacto">Escuela Nautica Santaló - Contacto</title>
</head> 
<body>
    <form id="form" runat="server">
        <section class="wrapper" style="margin-top: 45px;">
    
        <%-- <div id="maximage" style="height:100%;">
            <div>
                <img src="img/fondos/sections/ContactoGris.png" alt="">
            </div>
        </div><!-- #maximage -->--%>

        <div class="container">
            <div class="container clearfix">
                <h2 style="color: #024b94;margin: 0.5em 0;font-size: 1.5em;">CONTACTO</h2>
                <div class="sidebar-left" style="width: 60%;margin-top: 4px;">
                    <input type="text" id="contact_name" runat="server" style="color: #024b94;width: 100%;" name="contact[name]" required="required" placeholder="Nombre y apellidos" onclick="if (this.placeholder == 'Nombre y apellidos') this.placeholder = ''" onblur="if(this.placeholder=='') this.placeholder='Nombre y apellidos'"/>
                    <br /><br />
                    <input type="text" id="contact_email" runat="server" style="color: #024b94;width: 100%;" name="contact[email]" required="required" placeholder="E-mail" onclick="if (this.placeholder == 'E-mail') this.placeholder = ''" onblur="if(this.placeholder=='') this.placeholder='E-mail'"/>
                    <br /><br />
                    <input type="text" id="contact_phone" runat="server" style="color: #024b94;width: 100%;" name="contact[phone]" required="required"  placeholder="Teléfono" onclick="if (this.placeholder == 'Teléfono') this.placeholder = ''" onblur="if(this.placeholder=='') this.placeholder='Teléfono'"/>
                    <br /><br />
                    <textarea type="text" id="contact_body" runat="server" style="color: #024b94;width: 100%; height: 115px;" name="contact[body]" required="required" placeholder="Observaciones" rows="10" onclick="if (this.placeholder == 'Observaciones') this.placeholder = ''" onblur="if(this.placeholder=='') this.placeholder='Observaciones'"></textarea>
                    <br /><br />
                    <asp:Button OnClick="btnEnviar_Click" CssClass="botonEnviar" Width="101%" runat="server"  ID="btnEnviar" Text="ENVIAR" />
                </div>

                <div id="map_canvas" style="float: none;width: auto;height: 100%;"> 
                    <iframe src="~/UI/Html/MapaRutasEscuela.html" style="width: 100%; height: 100%; border: none;" runat="server" id="iframeMapa"></iframe>
                </div>
            </div>
        </div>
        </section>
    </form>
</body>  
</html>
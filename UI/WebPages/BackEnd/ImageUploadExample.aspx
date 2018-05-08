<%@ Page  Title="Ejemplo de Imnage Upload" Language="C#"  AutoEventWireup="true" CodeFile="ImageUploadExample.aspx.cs" Inherits="ImageUploadExample" %>

<%@ Import Namespace="System.Resources" %>
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title title="Ejemplo File Upload Image"></title>

    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
     
    <%--  Tab Control--%>
    <script  type="text/javascript">
      $(function () {
          $("#tabs").tabs();
      });

      $(function () {
          $("#tabsTexto").tabs();
      });

    </script>
 
    <link rel="stylesheet" href="css/reveal.css" /> 
	
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.min.js"></script>

	<script type="text/javascript" src="Scripts/jquery.reveal.js"></script>
		
	<style type="text/css">
		body { font-family: "HelveticaNeue","Helvetica-Neue", "Helvetica", "Arial", sans-serif; }
		.big-link { display:block; text-align: center; font-size: 70px; color: #06f; }
	</style>
      
	<link rel="stylesheet" href="css/jquery.ui.timepicker.css?v=0.3.3" type="text/css" />

    <script type="text/javascript" src="js/include/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="js/include/ui-1.10.0/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="js/include/ui-1.10.0/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="js/include/ui-1.10.0/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="js/include/ui-1.10.0/jquery.ui.position.min.js"></script>

    <script type="text/javascript" src="js/jquery.ui.timepicker.js?v=0.3.3"></script>
     
    <style type="text/css"> 
        .ui-widget-header {
            border: 1px solid #aaa;
            background: white url(images/ui-bg_highlight-soft_75_cccccc_1x100.png) 50% 50% repeat-x;
            color: #222;
            font-weight: bold;
            }

        .ui-tabs .ui-tabs-nav li {
            list-style: none;
            float: left;
            position: relative;
            top: 0;
            margin: 1px .2em 0 0;
            border-bottom: 0;
            padding: 0;
            white-space: nowrap;
            }

        .ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default {
            border: 1px solid #d3d3d3;
            /*background: white url(images/ui-bg_glass_75_e6e6e6_1x400.png) 50% 50% repeat-x;*/
            font-weight: normal;
            color: #555;

            }

        .ui-tabs .ui-tabs-nav li a, .ui-tabs-collapsible .ui-tabs-nav li.ui-tabs-active a {
            cursor: pointer;

            }
 
        .ui-tabs .ui-tabs-nav li a {
            float: left;
            padding: .5em 1em;
            text-decoration: none;
            }
         
        .ui-state-default a, .ui-state-default a:link, .ui-state-default a:visited {
        color: #555;
        text-decoration: none;

        }

        .ui-widget-content {
        border: 1px solid #ddd;
            background: #F9F9F9 url(images/ui-bg_highlight-soft_100_eeeeee_1x100.png) 50% top repeat-x; 
        color: #333;
        /*height: 106px;*/
        padding-left: 0px; 

        }

        .ui-tabs .ui-tabs-nav li.ui-tabs-active {
        margin-bottom: -1px;
        padding-bottom: 1px;
        background-color: #F9F9F9;
        }
    </style>   
</head> 
<body>
    <form id="form" runat="server"> 
    <br />
    <div>
        <asp:Button OnClick="btnGuardar_Click" runat="server" style="float: right;width: 105px;height:26px;font-family:Verdana;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;" id="btnGuardar" class="action" Text="Guardar" />
        <div id="emptyDiv" runat="server" style="width:25px;float: right;">&nbsp</div>
        <asp:Button id="btnVolver" OnClick="btnVolver_Click" Text="Volver" runat="server" style="float: right; width: 105px;height:26px;font-family:Verdana;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;" />
    </div>
       
    <br />

        <h1 style="display:none" class="main"> </h1> 
        <div style="float: left;"></div> 

        <%--Tabs Control TITULO--%>
        <div style="margin-top: 25px;" id="simpaleTabsTitulo"> 
        <ul>
            <li><a href="#tabs--1">Español</a></li>
			<li><a href="#tabs--2">Catalán</a></li>
			<li><a href="#tabs--3">Inglés</a></li> 
		</ul>
         
        <div style="padding-left: 0px;" id="tabs--1">
            
            <div class="form_row clearfix title">
            <table>
            <tr>
                <td style="width: 200px;">

                <label style="padding-right: 148px;" class="control-label required" for="txtTituloES">Título:</label>
                </td><td><asp:TextBox runat="server" BorderWidth="1px" Width="425px" type="text" ID="txtTituloES"></asp:TextBox>
                </td>
            </tr>
            </table>

            <button title="Traducciones" value="..." runat="server" style="display:none; vertical-align:middle;width: 50px;height:18px;font-family:Verdana;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;" id="btnAbrirPopUpLiterales_Title" >...</button>

            </div>
        </div>
        <div style="padding-left: 0px;" id="tabs--2">
         
            <div class="form_row clearfix title">
                <table>
            <tr>
                <td style="width: 200px;">
            <label style="padding-right: 155px;" class="control-label required" for="txtTituloCA">Títol:</label></td><td>
            <asp:TextBox runat="server" BorderWidth="1px" Width="425px" type="text" ID="txtTituloCA"></asp:TextBox></td></tr></table>
        </div>
                  </div>
        <div style="padding-left: 0px;" id="tabs--3">
            
            <div class="form_row clearfix title">
                     <table>
            <tr>
                <td style="width: 200px;"> <label style="padding-right: 155px;" class="control-label required" for="txtTituloEN">Title:</label></td><td>
                <asp:TextBox BorderWidth="1px" runat="server" Width="425px" type="text" ID="txtTituloEN"></asp:TextBox></td></tr></table>
            </div>
        </div>

	    <script type="text/javascript">
	        $(function () {
	            $('#simpaleTabsTitulo').tabs();
	        });
	    </script>
        </div>  
        <br />
        <br />
        <!-- PRECIO -->
        <div style="text-align:left;" class="form_row clearfix price">
               <table>
            <tr>
                <td style="width: 200px;"><label  style="padding-right: 153px;" class="control-label required" for="featured_price">Precio:</label></td><td>
             <asp:TextBox  runat="server" Text="00,00" BorderWidth="1px" Width="85px" type="text" id="featured_price" name="featured_price"></asp:TextBox> €</td></tr></table>
        </div>

        <%--Tabs Control TEXTO--%>
        <div id="simpaleTabsTexto">
        <ul>
            <li><a href="#tabs_1">Español</a></li>
			<li><a href="#tabs_2">Catalán</a></li>
			<li><a href="#tabs_3">Inglés</a></li>
		</ul>
         
        <div style="padding-left: 0px;" id="tabs_1">
            <div class="form_row clearfix title">
                <table>
            <tr>
                <td style="width: 200px;"><label style="padding-right: 148px;" class="control-label required" for="txtTextoES">Texto:</label></td><td>
                <asp:TextBox runat="server" Width="425px" BorderWidth="1px" type="text" ID="txtTextoES"></asp:TextBox></td></tr></table>
            </div>
        </div>
        <div style="padding-left: 0px;" id="tabs_2">
            <div class="form_row clearfix title">
                <table>
            <tr>
                <td style="width: 200px;"><label style="padding-right: 155px;" class="control-label required" for="txtTextoCA">Text:</label></td><td>
                <asp:TextBox runat="server" Width="425px" BorderWidth="1px" type="text" ID="txtTextoCA"></asp:TextBox></td></tr></table>
            </div>
        </div>
        <div style="padding-left: 0px;" id="tabs_3">
             
            <div class="form_row clearfix title">
                <table>
            <tr>
                <td style="width: 200px;"><label style="padding-right: 155px;" class="control-label required" for="txtTextoEN">Text:</label></td><td>
                <asp:TextBox BorderWidth="1px" Width="425px" runat="server" type="text" ID="txtTextoEN"></asp:TextBox></td></tr></table>
            </div>
        </div>

	    <script type="text/javascript">
	        $(function () {
	            $('#simpaleTabsTexto').tabs();
	        });
	    </script>
       </div>
        <br />
        <div style="text-align:left;" class="form_row clearfix link">
              <table>
            <tr>
                <td style="width: 200px;"> <label style="padding-right: 149px;" class="control-label required" for="featured_link">Enlace:</label></td><td>
            <asp:TextBox Width="425px" BorderWidth="1px" runat="server" type="text" id="featured_link" name="featured_link"></asp:TextBox></td></tr></table>
        </div>

        <!-- UPLOAD BUTTON -->
        <div style="text-align:left;" class="form_row clearfix link"> 
            <table>
                <tr>
                    <td style="width: 200px;">
                        <label style="padding-right: 121px;"" class="control-label required" for="featured_link">Imágen:</label>
                    </td>
                    <td style="padding: 0;">
                         <asp:FileUpload Width="350px"  runat="server" ID="fileUploadcontrol"   />
                    </td>
                    <td style="padding-top: 5px;"> 
                        <!-- FILE UPLOAD ICON -->
                        <asp:Button Visible="false" OnClick="UploadButton_Click" style="cursor: pointer;background-color: #4b6c9e;color: white;width: 125px; height: 26px;" id="fileUploadbutton" Text="Upload file" runat="server" />
                         <button title="Guardar imagen" runat="server" style="width: 100px;height: 22px" id="btnSave" class="action">
                                <asp:ImageButton runat="server" ID="imgBtnImageUpload" OnClick="UploadButton_Click"  ImageUrl="Images/png/upload2.png" style="background-repeat: no-repeat;background-size: contain;margin-left: 1px;height: 14px;width: 20px;" CssClass="label" />
                         </button>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2" >
                        <asp:TextBox runat="server" Width="431px" Height="92px" BorderWidth="1px" TextMode="MultiLine" ID="txtFileDetails" Text="...."></asp:TextBox>
                    </td>
                    <td>
                         <a href="#" class="big-link" data-reveal-id="myModal" data-animation="fade">
                            <asp:Image Width="100px" Height="100px" runat="server" ID="FeatureImageMiniatura" />
                        </a>
                    </td>
                </tr>
            </table>
        </div>
        <!-- DATES -->
        <div style="text-align:left;" class="form_row clearfix link">
             <table>
                <tr>
                    <td style="width: 200px;">
            <label style="padding-right: 117px;" class="control-label required" for="featured_fechaIni">Fecha Inicio:</label>
            </td><td>
            <asp:TextBox Enabled="false" BorderWidth="1px" Width="200px" runat="server" ID="txtbox"></asp:TextBox>
            <asp:ImageButton Width="16px" ImageAlign="TextTop" ImageUrl="Images/Calendar_scheduleHS.png" runat="server" ID="btnCalendar" />
             
      </td></tr></table>
        </div>
        <div style="text-align:left;" class="form_row clearfix link">
           <table>
                <tr>
                    <td style="width: 200px;">
            <label style="padding-right: 131px;" class="control-label required" for="featured_fechaFin">Fecha Fin:</label>
             </td><td>
            <asp:TextBox Enabled="false" BorderWidth="1px" Width="200px" runat="server" ID="txtbox_fechaFin"></asp:TextBox>
            <asp:ImageButton Width="16px" ImageAlign="TextTop" ImageUrl="Images/Calendar_scheduleHS.png" runat="server" ID="btnCalendar_fechaFin" />
             </td></tr></table>
        </div>
        <div style="display:none;" class="form_row clearfix link">
            <!-- Time Picket -->
             <div style="float: right; padding: 0 0 20px 20px; font-size: 10px; text-align: right">
 
                <div id="floating_timepicker"></div>
                <span id="floating_selected_time"></span>
            </div> 
            <div style="text-align:left;">
                <table>
                <tr>
                    <td style="width: 200px;">
                    <label style="padding-right: 131px;" class="control-label required" for="timepicker_noPeriodLabels">Horario:</label>
</td><td> 
                 <input  type="text" style="width: 85px;" runat="server" id="timepicker_noPeriodLabels" value="00:00" /> 
                 </td> </tr></table>
            </div>
          
        </div>

        <!-- ACTIVE -->
        <div style="text-align:left;" class="form_row clearfix link">
             <table>
                <tr>
                    <td style="width: 200px;"><label style="padding-right: 155px;" class="control-label required" for="featured_active">Activo:</label>
             </td><td><asp:CheckBox  runat="server" ID="featured_active" ></asp:CheckBox> </td></tr></table>
        </div>
     
        <div id="myModal" style="visibility:hidden;" class="reveal-modal">
			
            <asp:Image Width="100%" Height="100%" runat="server" ID="FeatureImage" />
            <a style="text-decoration:none;" class="close-reveal-modal">x</a>
		</div>
    </form>
</body>  
</html>
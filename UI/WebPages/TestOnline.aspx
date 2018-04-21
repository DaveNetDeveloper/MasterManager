<%@ Page Title="Test On-Line" Language="C#" AutoEventWireup="true" CodeFile="TestOnline.aspx.cs" Inherits="TestOnline" %>
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="http://code.jquery.com/jquery-latest.js" type="text/javascript"></script> 
    <script src="../Scripts/vallenato.js" type="text/javascript"></script>

    <link rel="stylesheet" href="css/vallenato.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <link rel="stylesheet" href="css/reveal.css" />

    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script> 
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.reveal.js"></script>

    <style type="text/css">
        body { font-family: "HelveticaNeue","Helvetica-Neue", "Helvetica", "Arial", sans-serif; }
        .big-link { display:block; text-align: center; font-size: 70px; color: #06f; }
        .cat a, .examen a, .test a, .cat a:visited, .examen a:visited, .test a:visited, .temaS, .temaS:visited, .temaNS, .temaNS:visited, .temaSS, .temaSS:visited {
                color: #018CDC;
                text-decoration: none;
                font-size: 14px;
        }
        .botonValidarTest:hover
        {
            background-color: #367fc3;
            color: white;
        }
        .botonValidarTest {
            background-color: white;
            color: #367fc3;
            width: 200px;
            height: 30px;
            font-weight: bold;
            font-family: Arial;
            font-size: 15px;
            cursor: pointer;
            float:right;
        } 
    </style> 
    <title title="Test On-Line">Test On-Line</title>  
</head> 
<body>
    <form id="form" runat="server">
    <section runat="server" class="wrapper" style="width: 95%;margin-left: 2.5%;min-height:700px; margin-top: 40px; margin-bottom: 20px;">  
        <h2 runat="server" id="TituloTest" style="color: #2d3382;font-weight:bold;margin-left: 5px;"></h2> 
        <hr /> 
        <p id="pPresentaciónTest" runat="server" style="color: #2d3382;font-weight:bold;margin-left: 5px;"> </p> 
        <div id="divResultadoTestHeader" visible="false" runat="server" style="vertical-align:middle;padding-top: 12px; text-align:center;color: darkslategray; background-color:coral; height:35px;border: 2px solid beige;">
            <b>RESULTADO DEL TEST</b>
        </div> 
        <div id="divResultadoTest" visible="false" runat="server" style="vertical-align:middle;text-align:center;padding-bottom: 15px;background-color:khaki; height:90px; margin-bottom: 20px; border: 2px solid beige;"> 
        </div> 
        <br /> 
        <div>
            <asp:Button runat="server" OnClick="btnLimpiarTest1_Click" Text="Volver a comenzar" ID="btnLimpiarTest1" CssClass="botonValidarTest" />
            <asp:Button runat="server" OnClick="btnValidarRespuestas_Click" Text="Validar Respuestas" ID="btnEnviar1" CssClass="botonValidarTest" />
        </div> 
        <br /><br /> 
        <div id="accordion_container" runat="server">  
            <!-- 
                <h2 runat="server" class="accordion-header">APARTADO 1</h2> 
                <div runat="server" style="height:150px;" class="accordion-content"> 

                    <p runat="server"  class="cat"><span></span><a runat="server" title="Pregunta 1">Pregunta 1</a></p>
                    <div runat="server" style="float:left;margin: 0px 65px 0;">
                        
                        <table runat="server" id="table_"><tr  id="table_tr_" runat="server"><td  id="table_tr_td_" runat="server" style="width: 75%;">

                            <asp:RadioButtonList Enabled="true" style="margin-top: 0px;" runat="server" ID="rblOpciones">
                                            <asp:ListItem Value="Opción1" Text=" Opción 1"></asp:ListItem>
                                            <asp:ListItem Value="Opción2" Text=" Opción 2"></asp:ListItem>
                                            <asp:ListItem Value="Opción3" Text=" Opción 3"></asp:ListItem>
                                            <asp:ListItem Value="Opción4" Text=" Opción 4"></asp:ListItem>
                            </asp:RadioButtonList>

                            </td><td runat="server">
                            <div>
                                <a href="#" class="big-link" data-reveal-id="myModal" data-animation="fade" style="margin-top:0;padding-top:0;">
                                    <asp:Image  Width="150px" Height="110px" ImageUrl="~/images/DestacadoInicio.png" runat="server" ID="PreguntaImagenMiniatura" />
                                </a>
                            </div>
                        </td></tr></table>


                    </div>

                    <p class="cat"><span></span><a title="Pregunta 2">Pregunta 2</a></p>
                    <div style=" margin: 0px 65px 0;">
                        <asp:RadioButtonList Enabled="true" style="margin-top: 0px;" runat="server" ID="RadioButtonList1">
                            <asp:ListItem Value="Opción1" Text=" Opción 1"></asp:ListItem>
                            <asp:ListItem Value="Opción2" Text=" Opción 2"></asp:ListItem>
                            <asp:ListItem Value="Opción3" Text=" Opción 3"></asp:ListItem>
                            <asp:ListItem Value="Opción4" Text=" Opción 4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <p class="cat"><span></span><a title="Pregunta 3">Pregunta 3</a></p>
                    <div style=" margin: 0px 65px 0;">
                        <asp:RadioButtonList Enabled="true" style="margin-top: 0px;" runat="server" ID="RadioButtonList2">
                            <asp:ListItem Value="Opción1" Text=" Opción 1"></asp:ListItem>
                            <asp:ListItem Value="Opción2" Text=" Opción 2"></asp:ListItem>
                            <asp:ListItem Value="Opción3" Text=" Opción 3"></asp:ListItem>
                            <asp:ListItem Value="Opción4" Text=" Opción 4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <p class="cat"><span></span><a title="Pregunta 4">Pregunta 4</a></p>
                    <div style=" margin: 0px 65px 0;">
                        <asp:RadioButtonList Enabled="true" style="margin-top: 0px;" runat="server" ID="RadioButtonList3">
                            <asp:ListItem Value="Opción1" Text=" Opción 1"></asp:ListItem>
                            <asp:ListItem Value="Opción2" Text=" Opción 2"></asp:ListItem>
                            <asp:ListItem Value="Opción3" Text=" Opción 3"></asp:ListItem>
                            <asp:ListItem Value="Opción4" Text=" Opción 4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <p class="cat"><span></span><a title="Pregunta 5">Pregunta 5</a></p>
                    <div style=" margin: 0px 65px 0;">
                        <asp:RadioButtonList Enabled="true" style="margin-top: 0px;" runat="server" ID="RadioButtonList4">
                            <asp:ListItem Value="Opción1" Text=" Opción 1"></asp:ListItem>
                            <asp:ListItem Value="Opción2" Text=" Opción 2"></asp:ListItem>
                            <asp:ListItem Value="Opción3" Text=" Opción 3"></asp:ListItem>
                            <asp:ListItem Value="Opción4" Text=" Opción 4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                 
                </div>  -->
            <!-- <h2 class="accordion-header" >APARTADO 2</h2> 
                <div class="accordion-content"> 
            
                    <p>


                    </p> 
            
                </div> 

                <h2 class="accordion-header">APARTADO 3</h2> 
                <div class="accordion-content"> 
            
                    <p>


                    </p> 
            
                </div> 

                <h2 class="accordion-header">APARTADO 4</h2> 
                <div class="accordion-content"> 
            
                    <p>


                    </p> 
            
                </div> 

                <h2 class="accordion-header">APARTADO 5</h2> 
                <div class="accordion-content"> 
            
                    <p>

                    </p> 
            
                </div>

            --> 
        </div>
        <br /> 
        <div>
            <asp:Button runat="server" OnClick="btnLimpiarTest1_Click" Text="Volver a comenzar" ID="btnLimpiarTest2" CssClass="botonValidarTest" />
            <asp:Button runat="server" OnClick="btnValidarRespuestas_Click" Text="Validar Respuestas" ID="btnEnviar2" CssClass="botonValidarTest" />
        </div>
        <br /> <br /> <br />
    </section>

    <%-- MODAL PANEL--%>
    <div id="myModal" style="visibility:hidden;" class="reveal-modal">
        <asp:Image Width="100%" Height="100%" runat="server" ID="FeatureImage" />
        <a class="close-reveal-modal">×</a>
    </div> 
    </form>
</body>  
</html>
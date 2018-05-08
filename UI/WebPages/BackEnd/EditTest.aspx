<%@ Page  Title="EditTest" Language="C#" AutoEventWireup="true" CodeFile="EditTest.aspx.cs" Inherits="EditTest" %>
<%@ Import Namespace="System.Resources" %>

<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">   
    <title title="Edición de un Test Online"></title>

    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
   
    <link rel="stylesheet" href="css/reveal.css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.reveal.js"></script>
    <style type="text/css">
        body { font-family: "HelveticaNeue","Helvetica-Neue", "Helvetica", "Arial", sans-serif; }
        .big-link { display:block; text-align: center; font-size: 70px; color: #06f; }
    </style>

    <script type="text/javascript">
        function CambiarUrlImagen()
        {
            //alert(document.getElementById('MainContent_FeatureImage').src);
            //alert(document.getElementById('MainContent_rptPreguntas_QuestionImageMiniatura_0').src);
            document.getElementById('MainContent_FeatureImage').src = document.getElementById('MainContent_rptPreguntas_QuestionImageMiniatura_0').src;
        }
    </script>
</head> 
<body>
    <form id="form" runat="server">
    <div id="TestFields">
         <br />
    <div>
        <asp:Button OnClick="btnGuardar_Click" runat="server" style="float: right;width: 105px;height:26px;font-family:Verdana;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;" id="btnGuardar" class="action" Text="Guardar" />
        <div id="emptyDiv" runat="server" style="width:25px;float: right;">&nbsp</div>
        <asp:Button id="btnVolver" OnClick="btnVolver_Click" Text="Volver" runat="server" style="float: right; width: 105px;height:26px;font-family:Verdana;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;" />
    </div>
       
    <br /><br /><br />

        <h1 style="display:none" class="main"> </h1>
        <div style="float: left;"></div>

        <%--FIELD [Código]--%>
        <div style="text-align:left;height:65px;" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label class="control-label required" for="TestCode">Código:</label></td><td>
            <asp:TextBox Width="200px"  BorderWidth="1px" runat="server" type="text" id="TestCode" name="TestCode"></asp:TextBox></td></tr></table>
        </div>
        <br /> <br />
        <%--FIELD [Nombre]--%>
        <div style="text-align:left;height: 90px;" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label style="padding-right: 85px;" class="control-label required" for="TestName">Nombre:</label></td><td>
            <asp:TextBox  Width="600px" BorderWidth="1px" Height="50px" TextMode="MultiLine" runat="server" type="text" id="TestName" name="TestName"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Nombre]--%>
        <div style="text-align:left;height: 80px;" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label style="padding-right: 85px;"   class="control-label required" for="TestTitle">Título:</label></td><td>
            <asp:TextBox  Width="600px" BorderWidth="1px" runat="server" type="text" id="TestTitle" name="TestTitle"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Descripción]--%>
        <div style="text-align:left;height: 90px;" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label style="padding-right: 85px;"  class="control-label required" for="TestDescription">Descripción:</label></td><td>
            <asp:TextBox  Width="600px" BorderWidth="1px" Height="50px" TextMode="MultiLine" runat="server" type="text" id="TestDescription" name="TestDescription"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Examen - Producto]--%>
        <div style="text-align:left;" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label style="padding-right: 85px;" class="control-label required" for="TestProduct">Título/Licencia:</label></td><td>
            <asp:DropDownList   DataTextField="NOMBRE" DataValueField="ID"  runat="server" ID="ddlTitulos"></asp:DropDownList></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Clave]--%>
        <div style="text-align:left;" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label style="padding-right: 85px;"  class="control-label required" for="TestKey">Clave:</label></td><td>
            <asp:TextBox  Width="200px" BorderWidth="1px" runat="server" type="text" id="TestKey" name="TestKey"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Fecha]--%>
        <div style="text-align:left;" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;">
                    <label style="padding-right: 85px;"  class="control-label required" for="TestFechaExamen">Fecha Examen:</label>
                </td>
                <td>
                    <asp:TextBox Width="200px" BorderWidth="1px" runat="server" type="text" id="TestFechaExamen" name="TestFechaExamen"></asp:TextBox>
                    <asp:ImageButton ImageAlign="TextTop" ImageUrl="Images/Calendar_scheduleHS.png" runat="server" ID="btnCalendarFechaExamen" />
                   <%-- <ajax:CalendarExtender runat="server" TargetControlID="TestFechaExamen" Format="dd/MM/yyyy HH:mm:ss" PopupButtonID="btnCalendarFechaExamen"></ajax:CalendarExtender>--%>
                </td>
            </tr>
             </table>
        </div>
        <br /><br />
        <%--FIELD [Origen]--%>
        <div style="text-align:left;" class="form_row clearfix link">
              <table>
            <tr>
                <td style="width: 200px;"><label style="padding-right: 85px;"  class="control-label required" for="TestFrom">Origen Examen:</label></td><td>
            <asp:TextBox  BorderWidth="1px" Width="600px" runat="server" type="text" id="TestFrom" name="TestFrom"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Firma]--%>
        <div style="text-align:left; height:110px"  class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label  class="control-label required" for="TestSign">Firma:</label></td><td>
            <asp:TextBox Width="600px"  TextMode="MultiLine" Height="70px" BorderWidth="1px" runat="server" type="text" id="TestSign" name="TestSign"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Nota Instrucciones 1]--%>
        <div style="text-align:left;height:110px" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label  class="control-label required" for="TestInstructions1">Instrucciones 1:</label></td><td>
            <asp:TextBox Width="600px"  BorderWidth="1px" TextMode="MultiLine" Height="70px" runat="server" type="text" id="TestInstructions1" name="TestInstructions1"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Nota Instrucciones 2]--%>
        <div style="text-align:left;height:110px" class="form_row clearfix link">
            <table>
            <tr>
                <td style="width: 200px;"> <label  class="control-label required" for="TestInstructions2">Instrucciones 2:</label></td><td>
            <asp:TextBox Width="600px"  BorderWidth="1px" TextMode="MultiLine" Height="70px" runat="server" type="text" id="TestInstructions2" name="TestInstructions2"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Nota Cabecera]--%>
        <div style="text-align:left;height:110px" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label  class="control-label required" for="TestHeaderNote">Nota Cabecera:</label></td><td>
            <asp:TextBox Width="600px"  BorderWidth="1px" TextMode="MultiLine" Height="70px" runat="server" type="text" id="TestHeaderNote" name="TestHeaderNote"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [Nota Pie]--%>
        <div style="text-align:left;height:110px" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label  class="control-label required" for="TestFooterNote">Nota Pie:</label></td><td>
            <asp:TextBox Width="600px"  BorderWidth="1px" TextMode="MultiLine" Height="70px" runat="server" type="text" id="TestFooterNote" name="TestFooterNote"></asp:TextBox></td></tr></table>
        </div>
        <br /><br />
        <%--FIELD [ACTIVO] --%>
        <div style="text-align:left;" class="form_row clearfix link">
             <table>
            <tr>
                <td style="width: 200px;"><label  class="control-label required" for="TestActive">Activo:</label></td><td>
            <asp:CheckBox runat="server" type="text" id="TestActive"></asp:CheckBox></td></tr></table>
        </div>
    </div>
    <br /> <br />
    
    <div id="QuestionAnswersFields">

    <!-- Question And Answers -->
    <h3 style="color: darkslateblue;"> PREGUNTAS Y RESPUESTAS</h3>
    <br /> <br /> 
    <div>
        <table style="width: 100%;">
                <asp:Repeater OnItemDataBound="rptPreguntas_ItemDataBound" ID="rptPreguntas" runat="server">
                     <ItemTemplate>
                            <asp:HiddenField  ID="hdnID" Value='<%#Eval("ID") %>' runat="server"></asp:HiddenField>
                            <asp:HiddenField  ID="hdnCheckIsNew" Value='<%#Eval("chkSelect") %>' runat="server"></asp:HiddenField>
                            <!-- DB ROW -->
                            <tr runat="server" style="background-color: ghostwhite; border-color: lightgray; border: 1px solid lightgray;">
                                <td style="text-align: center;vertical-align: middle;align-content: center;padding-left: 10px;margin: 0;padding-right: 10px;background-color: lavender;border-right: 1px gray solid;">
                                    <asp:Label style="text-align: center;font-size: 25px;" ID="lblPreguntaID" Text='<%#Eval("PREGUNTA_ID") %>' runat="server"></asp:Label>
                                </td>
                                <td>
                                   <table>
                                       <tr>
                                           <td style="padding-left: 15px;" colspan="2">
                                                <asp:Literal runat="server" Text="PREGUNTA:"></asp:Literal>
                                               <br /><br />
                                                <asp:TextBox TextMode="MultiLine" Enabled="false" Text='<%#Eval("TEXTO") %>' runat="server" Width="825px" Height="100px" ID="txtTextoPregunta" ></asp:TextBox>
                                                <br /> <br />
                                           </td>
                              
                                       </tr>
                                        <tr>
                                           <td style="padding-left: 15px;" colspan="2">
                                               <asp:Literal runat="server" Text="APARTADO:"></asp:Literal>
                                               <asp:TextBox  Width="175px" Text='<%#Eval("APARTADO") %>' Enabled="false" runat="server" ID="PreguntaApartado" ></asp:TextBox>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td style="padding-left: 15px;" colspan="2">
                                               <asp:Literal Visible="false" runat="server" Text="TIPO:"></asp:Literal>
                                               <asp:TextBox  Visible="false" Width="100px" Text='<%#Eval("TIPO") %>' Enabled="false" runat="server" ID="PreguntaTipo" ></asp:TextBox>
                                           </td>
                                       </tr>
                                      <tr >
                                            <td colspan="1" runat="server"  style="padding-left: 15px;">
                                                
                                                <asp:Label style="vertical-align: middle;" runat="server" Text="IMÁGEN:"></asp:Label>
                                                
                                                <asp:FileUpload  Enabled="true"  runat="server" ID="fileUploadcontrol" />

                                                <button title="Guardar imagen" runat="server" style="width: 100px;height: 22px" id="Button1" class="action">
                                                        <asp:Button UseSubmitBehavior="false" runat="server" ID="imgBtnImageUpload" ToolTip='<%#Eval("PREGUNTA_ID") %>' OnClick="UploadButton_Click"   style="background-repeat: no-repeat;background-size: contain;margin-left: 1px;height: 14px;width: 20px;" CssClass="label" />
                                                 </button>

                                                <asp:TextBox Enabled="false" style="vertical-align: top;width: 125px; height: 22px;" runat="server" BorderWidth="1px"  ID="txtFileDetails" Text="...."></asp:TextBox>
                                            </td>
                                            <td style="padding-right: 10px;">
                                               <a href="#" class="big-link" onclick="CambiarUrlImagen();" data-reveal-id="myModal" data-animation="fade">
                                                <asp:Image Width="115" Height="90" ImageUrl='<%#Eval("IMAGEN_URL")%>' runat="server" ID="QuestionImageMiniatura" />
                                            </a>
                                           </td>
                                       </tr>

                                        <tr>
                                            <td colspan="2" style="padding-left: 15px;">
                                                <div visible="false" runat="server" id="divRespuestaLibre">
                                                    <hr />
                                                    <asp:Literal runat="server" Text="RESPUESTA:"></asp:Literal>
                                                    <br />
                                                    <asp:TextBox TextMode="MultiLine" Text="" runat="server" ID="txtTextoRespuesta" Width="831px" Height="80px" ></asp:TextBox>
                                                </div>
                                    
                                                <div visible="false" runat="server" id="divRespuestaTest">
                                                   
                                                    <asp:Literal runat="server" Text="RESPUESTA:"></asp:Literal>
                                                    
                                                    <table style="margin-top: 0;">
                                                        <tr>
                                                            <td>
                                                                <br />

                                                                 <asp:RadioButtonList  Enabled="false" style="margin-top: 0px;" runat="server" ID="rblOpciones">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem></asp:ListItem>
                                                                </asp:RadioButtonList>

                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                       </tr>
                                   </table>
                                </td>
                                 <td  style="border-left: solid gray 1px; padding-left: 15px; padding-right: 15px; background-color:lavender;">
                                    <button title="Eliminar" runat="server" onmouseover="hoverGuardar(this);" onmouseout="unhoverGuardar(this);" style="width: 75px;height: 22px" id="btnEliminar" class="action">
                                            <asp:ImageButton runat="server" ID="imgEliminarPregunta" OnClick="btnEliminar_Click" ImageUrl="Images/png/delete.png" style="background-repeat: no-repeat;background-size: contain;margin-left: 1px;height: 15px;width: 16px;padding-top: 1px;" CssClass="label" />
                                    </button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                        </ItemTemplate>
                </asp:Repeater>
                <tr style="height:20px"><td colspan="2"></td></tr>
                <div runat="server" id="trEditRow">
                    <!-- EDIT ROW -->
                    <tr style="background-color: lightgoldenrodyellow; border-color: lightgray; border: 1px solid lightgray;">
                    <td style="text-align: center;vertical-align: middle;align-content: center;padding-left: 10px;margin: 0;padding-right: 10px;background-color: sandybrown;border-right: 1px gray solid;"">
                        <asp:Label style="text-align: center;font-size: 25px;" ID="lblPreguntaID" runat="server"></asp:Label>
                    </td>
                    <td>
                       <table>
                           <tr>
                               <td style="padding-left: 15px;" colspan="2">
                                    <asp:Label runat="server" Text="PREGUNTA:"></asp:Label>
                                   <br /> <br />
                                    <asp:TextBox TextMode="MultiLine" Text="" runat="server" Width="825px" Height="100px" ID="txtTextoPregunta" ></asp:TextBox>
                                    <br /> <br />
                               </td>
                              
                           </tr>
                             <tr>
                               <td style="padding-left: 15px;" colspan="2">
                                    <asp:Label  Width="150px" runat="server" Text="APARTADO:"></asp:Label>
                                    <asp:DropDownList AutoPostBack="true" Width="175px" runat="server" ID="ddlApartado" DataTextField="TEXT" DataValueField="ID" ></asp:DropDownList>
                                    
                               </td>
                              
                           </tr>
                           <tr>
                               <td style="padding-left: 15px;" colspan="2">
                                   <br /> <asp:Label Width="150px" Visible="true" runat="server" Text="TIPO:"></asp:Label>
                                    <asp:DropDownList Visible="true" AutoPostBack="true" Width="100px" runat="server" ID="ddlTipoPregunta" OnSelectedIndexChanged="ddlTipoPregunta_SelectedIndexChanged" DataTextField="TEXT" DataValueField="ID" ></asp:DropDownList>
                               
                               <br /><br /> 

                               </td>
                              
                           </tr>
                            <tr style="display:none;">
                                <td colspan="1" style="padding-left: 15px;">
                                    <asp:Label style="vertical-align: middle;" runat="server" Text="IMÁGEN:"></asp:Label>
                                     <asp:FileUpload  runat="server" ID="fileUploadcontrol"   />
                                    
                                    <asp:Button Visible="false"  OnClick="UploadButton_Click" style="cursor: pointer;vertical-align: top; background-color: #4b6c9e;color: white;width: 125px; height: 26px;" id="fileUploadbutton" Text="Upload file" runat="server" />
                                    
                                    <button title="Guardar" runat="server" style="width: 75px;height: 22px" id="btnSave" class="action">
                                        <img onmouseover="hoverGuardar(this);" onmouseout="unhoverGuardar(this);" src="Images/png/upload2.png" style="background-repeat: no-repeat;background-size: contain;margin-left: 1px;height: 14px;width: 20px;" class="label" />
                                    </button>
                                    
                                    <asp:TextBox style="vertical-align: top;width: 125px; height: 22px;" runat="server" BorderWidth="1px"  ID="txtFileDetails" Text="...."></asp:TextBox>
                                </td>
                                <td>
                                    <a href="#"  class="big-link" data-reveal-id="myModal" data-animation="fade">
                                    <asp:Image ImageUrl="~/Images/NoImage.jpg" Width="115" Height="90" runat="server" ID="FeatureImageMiniatura" />
                                </a>
                               </td>
                           </tr>
                            <tr>
                                <td colspan="2" style="padding-left: 15px;">
                                    <div visible="false" runat="server" id="divRespuestaLibre">
                                        <hr />
                                        <asp:Literal runat="server" Text="RESPUESTA:"></asp:Literal>
                                        <br />
                                        <asp:TextBox TextMode="MultiLine" Text="" runat="server" ID="txtTextoRespuesta" Width="831px" Height="80px" ></asp:TextBox>
                                    </div>
                                    
                                    <div  runat="server" id="divRespuestaTest">
                                        
                                        <asp:Literal runat="server" Text="RESPUESTA:"></asp:Literal>
                                        <table style="margin-top: 0;">
                                            <tr>
                                                <td>
                                                    <table>
                                                        <!-- A -->
                                                        <tr>
                                                           <td><asp:Label ID="lblRespuestaTest1" runat="server" Text="1."></asp:Label></td>
                                                             <td><asp:TextBox ID="txtRespuestaTest1" Width="600px" runat="server"></asp:TextBox></td>
                                                            <td><asp:RadioButton ID="rdbRespuestaTest1" OnCheckedChanged="rdbRespuestaTest_CheckedChanged" AutoPostBack="true" runat="server" />
                                                        </tr>
                                                        <!-- B -->
                                                         <tr>
                                                            <td><asp:Label ID="lblRespuestaTest2" runat="server" Text="2."></asp:Label></td>
                                                             <td><asp:TextBox ID="txtRespuestaTest2" Width="600px" runat="server"></asp:TextBox></td>
                                                            <td><asp:RadioButton ID="rdbRespuestaTest2" OnCheckedChanged="rdbRespuestaTest_CheckedChanged" AutoPostBack="true" runat="server" />
                                                        </tr>
                                                         <!-- C -->
                                                         <tr>
                                                            <td><asp:Label ID="lblRespuestaTest3" runat="server" Text="3."></asp:Label></td>
                                                             <td><asp:TextBox ID="txtRespuestaTest3" Width="600px" runat="server"></asp:TextBox></td>
                                                            <td><asp:RadioButton  ID="rdbRespuestaTest3" OnCheckedChanged="rdbRespuestaTest_CheckedChanged" AutoPostBack="true" runat="server" />
                                                        </tr>
                                                         <!-- D -->
                                                         <tr>
                                                            <td><asp:Label ID="lblRespuestaTest4" runat="server" Text="4."></asp:Label></td>
                                                             <td><asp:TextBox ID="txtRespuestaTest4" Width="600px" runat="server"></asp:TextBox></td>
                                                            <td><asp:RadioButton ID="rdbRespuestaTest4" OnCheckedChanged="rdbRespuestaTest_CheckedChanged" AutoPostBack="true" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                           </tr>
                       </table>
                        <br /><br />
                    </td>
                     <td style="border-left: solid gray 1px; padding-left: 15px; padding-right: 15px; background-color:sandybrown;">
                        <button title="Añadir" runat="server"  onmouseover="hoverGuardar(this);" onmouseout="unhoverGuardar(this);" style="width: 75px;height: 22px" id="btnAdd" class="action">
                                <asp:ImageButton runat="server" ID="imgAñadirPregunta" OnClick="imgAñadirPregunta_Click" ImageUrl="Images/png/add.png"  style="background-repeat: no-repeat;background-size: contain;margin-left: 1px;height: 15px;width: 16px;padding-top: 1px;" CssClass="label" />
                        </button>
                    </td>
                </tr>
                </div>

            </table>
    </div>
    <br /><br /> 
    </div> 
    <%-- MODAL PANEL--%>
    <div id="myModal" style="visibility:hidden;" class="reveal-modal">
        <asp:Image Width="100%" Height="275" ImageUrl="~/Images/NoImage.jpg" runat="server" ID="FeatureImage" />
        <a class="close-reveal-modal">×</a>
    </div> 
    </form>
</body>  
</html>
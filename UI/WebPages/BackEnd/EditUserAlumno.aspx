<%@ Page  Title="EditUserAlumno" Language="C#" AutoEventWireup="true" CodeFile="~/UI/WebPages/BackEnd/EditUserAlumno.aspx.cs" Inherits="EditUserAlumno" %>
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
    <title title="Edición de un alumno"></title>  
	<style type="text/css">
        body { font-family: "HelveticaNeue","Helvetica-Neue", "Helvetica", "Arial", sans-serif; }
        .big-link { display:block; text-align: center; font-size: 70px; color: #06f; }
	</style> 
    
    <!-- Css -->
	<link rel="stylesheet" href="../css/core.min.css" />
	<link rel="stylesheet" href="../css/skin.css" />

</head> 
<body> 
    <form id="form" runat="server"> 
        <%-- <div>
         <asp:Button OnClick="SaveModelClick" runat="server" style="float: right;width: 105px;height:26px;font-family:Verdana;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;" id="btnGuardar" class="action" Text="Guardar" />
        <div id="emptyDiv" runat="server" style="width:25px;float: right;">&nbsp</div>
        <asp:Button id="btnVolver" OnClick="GoBackClick" Text="Volver" runat="server" style="float: right; width: 105px;height:26px;font-family:Verdana;border: 1px solid #D8D8D8 !important;background: #F2F2F2;background: -webkit-linear-gradient(top, #F5F5F5, #F1F1F1);background: -moz-linear-gradient(top, #F5F5F5, #F1F1F1);background: -ms-linear-gradient(top, #F5F5F5, #F1F1F1);background: -o-linear-gradient(top, #F5F5F5, #F1F1F1);-webkit-transition: border .20s;-moz-transition: border .20s;-o-transition: border .20s;transition: border .20s;" />
    </div> 
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
    </div>--%> 
        <div class="wrapper reveal-side-navigation">
		<div class="wrapper-inner"> 
            <section class="section-block replicable-content contact-2">
                <div class="row">
					<div class="column width-4">
						<h2 class="mb-30">Edición de alumno</h2>
						<div class="row">
							<div class="column width-10">
								<p>Aquí puedes editar los detalles de un alumno.</p>
							</div>
						</div>
					</div>
					<div class="column width-8 left">
						<div class="contact-form-container">
								 
							<div class="row">
								<div class="column width-6">
									<asp:TextBox runat="server" ID="privateUserName" CssClass="form-fname form-element large" placeholder="Nombre" tabindex="1" required="required"></asp:TextBox>
								</div>
								<div class="column width-6">
									<asp:TextBox runat="server" ID="privateUserSurname" CssClass="form-lname form-element large" placeholder="Apellidos" tabindex="2" ></asp:TextBox>
								</div>
								<div class="column width-6">
									<asp:TextBox runat="server" ID="privateUserMail" CssClass="form-email form-element large" placeholder="Email" tabindex="3" required="required" ></asp:TextBox>
								</div>
								<div class="column width-6">
									<asp:TextBox runat="server" ID="privateUserPhone" CssClass="form-website form-element large" placeholder="Teléfono" tabindex="4" ></asp:TextBox>
								</div>
								<%--<div class="column width-6">
									<div class="form-select form-element large">
										<select name="options" class="form-aux" data-label="Options" tabindex="5">
											<option selected="selected" value="">Project Budget</option>
											<option value="">Less than $1000</option>
											<option value="">$1000 - $2000</option>
											<option value="">$2000 - $5000</option>
											<option value="">$5000 - $7000</option>
											<option value="">$10000 &amp; up</option>
										</select>
									</div>
								</div>
								<div class="column width-6">
									<div class="form-select form-element large">
										<select name="options" class="form-aux" data-label="Options" tabindex="5">
											<option selected="selected" value="">How'd You Find Sartre</option>
											<option value="">From a friend</option>
											<option value="">Found Sartre online</option>
											<option value="">Previous client</option>
											<option value="">Through advertising</option>
										</select>
									</div>
								</div>--%>
								<div class="column width-6">
									<input type="text" name="honeypot" class="form-honeypot form-element large" />
								</div> 
                                <div class="column width-6">
									<asp:TextBox runat="server" ID="privateUserUserName"  CssClass="form-lname form-element large" placeholder="Nombre de usuario" tabindex="2" ></asp:TextBox>
								</div>
                                    <div class="column width-6">
									<asp:TextBox runat="server" TextMode="Password" ID="privateUserPassword" CssClass="form-lname form-element large" placeholder="Contraseña" tabindex="2" ></asp:TextBox>
								</div>

                                <div class="column width-6">
										<asp:CheckBox Text="Ha accedido?" runat="server" ID="privateUserActive" CssClass="form-element checkbox"  />
                                </div>
                                <div class="column width-6">
										<asp:CheckBox runat="server" Text="Activo?" ID="privateUserEntered" CssClass="form-element checkbox"  />
								</div>

                                <div class="column width-6">
									<asp:TextBox runat="server" id="privateUserBirthDate" TextMode="DateTime" name="privateUserBirthDate" CssClass="form-lname form-element large" placeholder="Fecha de nacimiento" tabindex="2" />
								</div>
									 
								<div class="column width-12">
									<div class="field-wrapper">
										<textarea runat="server" name="message" id="message" class="form-message form-element large" placeholder="mensaje" tabindex="7" required="required"></textarea>
									</div>
								</div>
										
                                    <div class="column width-6">
									<div class="field-wrapper pt-10 pb-10">
										<asp:TextBox runat="server" id="privateUserCreated" TextMode="DateTime" name="privateUserCreated" CssClass="form-lname form-element large" tabindex="2" />
									</div>
                                </div>
                                    <div class="column width-6">
									<div class="field-wrapper pt-10 pb-10">
										<asp:TextBox runat="server" id="privateUserUpdated" TextMode="DateTime" name="privateUserUpdated" CssClass="form-lname form-element large" tabindex="2" />
									</div>
                                </div>

								<div class="column width-12">
									<input runat="server" id="btnGuardar" type="submit" value="Guardar" class="form-submit button medium bkg-theme bkg-hover-theme color-white color-hover-white" />
                                    <input runat="server" id="btnVolver" type="submit" value="Volver" class="form-submit button medium bkg-theme bkg-hover-theme color-white color-hover-white" />
								</div>
									 
								<div class="form-response center"></div>
						</div>
					</div>
				</div>
                </div>
            </section> 
		</div>
	</div>  
    </form>
</body>  
</html>
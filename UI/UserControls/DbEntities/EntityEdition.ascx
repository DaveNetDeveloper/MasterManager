<%@ Control Language="C#" AutoEventWireup="true"  CodeFile="EntityEdition.ascx.cs" Inherits="EntityEdition" %>
<form id="form" runat="server"> 
    <div runat="server" class="wrapper reveal-side-navigation">
	    <div runat="server" class="wrapper-inner"> 
            <section runat="server" class="section-block replicable-content contact-2">
                <div runat="server" class="row">
				    <div class="column width-4">
					    <h2 class="mb-30">Edición de alumno</h2>
					    <div class="row">
						    <div class="column width-10">
							    <p>Aquí puedes editar los detalles de un alumno.</p>
						    </div>
					    </div>
				    </div>
				    <div class="column width-8 left">
					    <div runat="server" class="contact-form-container"> 	 
						    <div class="row" runat="server" id="entityControlsContainer">
							    <%--<div runat="server" class="column width-6">
								    <%--<asp:TextBox runat="server" ID="entityControl_Name" CssClass="form-fname form-element large" placeholder="Nombre" tabindex="1" required="required"></asp:TextBox>
							    </div>
							    <div class="column width-6">
								    <asp:TextBox runat="server" ID="entityControl_Surname" CssClass="form-lname form-element large" placeholder="Apellidos" tabindex="2" ></asp:TextBox>
							    </div>
							    <div class="column width-6">
								    <asp:TextBox runat="server" ID="entityControl_Mail" CssClass="form-email form-element large" placeholder="Email" tabindex="3" required="required" ></asp:TextBox>
							    </div>
							    <div class="column width-6">
								    <asp:TextBox runat="server" ID="entityControl_Phone" CssClass="form-website form-element large" placeholder="Teléfono" tabindex="4" ></asp:TextBox>
							    </div>
							    <div class="column width-6">
								    <div class="form-select form-element large">
									    <select name="options" class="form-aux" data-label="Options" tabindex="5">
										    <option selected="selected" value="">Productos</option>
										    <option value="">LNA</option>
										    <option value="">PNB</option>
										    <option value="">PER</option>
										    <option value="">Patron de Yate</option>
										    <option value="">Capitán de Yate</option>
									    </select>
								    </div>
							    </div>
							    <div class="column width-6">
								    <div class="form-select form-element large">
									    <select name="options" class="form-aux" data-label="Options" tabindex="5">
										    <option selected="selected" value=""></option>
										    <option value="">From a friend</option>
										    <option value="">Found Sartre online</option>
										    <option value="">Previous client</option>
										    <option value="">Through advertising</option>
									    </select>
								    </div>
							    </div> 
							    <div class="column width-6">
								    <input type="text" name="honeypot" class="form-honeypot form-element large" />
							    </div> 
                                <div class="column width-6">
								    <asp:TextBox runat="server" ID="entityControl_UserName" CssClass="form-lname form-element large" placeholder="Nombre de usuario" tabindex="2" ></asp:TextBox>
							    </div>
                                <div class="column width-6">
								    <asp:TextBox runat="server" TextMode="Password" ID="entityControl_Password" CssClass="form-lname form-element large" placeholder="Contraseña" tabindex="2" ></asp:TextBox>
							    </div>
                                <div class="column width-6">
								    <div class="field-wrapper pt-10 pb-10">
									    <input id="entityControl_Active" runat="server" class="form-element checkbox" name="entityControl_Active" type="checkbox" />
									    <label for="entityControl_Active" class="checkbox-label">Activo?</label>
								    </div>
                                </div>
                                <div class="column width-6">
								    <div class="field-wrapper pt-10 pb-10">
									    <input id="entityControl_Entered" runat="server" class="form-element checkbox" name="entityControl_Entered" type="checkbox" />
									    <label for="entityControl_Entered" class="checkbox-label">Ha accedido?</label>
								    </div>
                                </div> 
                                <div class="column width-6">
								    <asp:TextBox runat="server" id="entityControl_BirthDate" TextMode="DateTime" name="entityControl_BirthDate" CssClass="form-lname form-element large" placeholder="Fecha de nacimiento" tabindex="2" />
							    </div>
							    <div class="column width-12">
								    <div class="field-wrapper">
									    <textarea runat ="server" name="entityControl_Message" id="entityControl_Message" class="form-message form-element large" placeholder="mensaje" tabindex="7" required="required"></textarea>
								    </div>
							    </div>
                                <div class="column width-6">
								    <div class="field-wrapper pt-10 pb-10">
									    <asp:TextBox runat="server" id="entityControl_Created" TextMode="DateTime" name="entityControl_Created" CssClass="form-lname form-element large" tabindex="2" />
								    </div>
                                </div>
                                <div class="column width-6">
								    <div class="field-wrapper pt-10 pb-10">
									    <asp:TextBox runat="server" id="entityControl_Updated" TextMode="DateTime" name="entityControl_Updated" CssClass="form-lname form-element large" tabindex="2" />
								    </div>
                                </div> --%>
							    
						    </div>  
                            <div id="buttonsContainer" style="text-align: right;" class="column width-12">
							    <asp:Button runat="server" ID="btnGuardar" Width="150px" Text="Guardar" OnClick="SaveModelClick" CssClass="form-submit button medium bkg-theme bkg-hover-theme color-white color-hover-white" />
                                <asp:Button runat="server" ID="btnVolver" Width="150px" style="margin-left: 30px !important;" Text="Volver" OnClick="GoBackClick" CssClass="form-submit button medium bkg-theme bkg-hover-theme color-white color-hover-white" />
						    </div>
						    <div class="form-response center"></div>
					    </div>
				    </div>
                </div>
            </section> 
	    </div>
    </div>  
</form>
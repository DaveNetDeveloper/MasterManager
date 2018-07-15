<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EntityEdition.ascx.cs" Inherits="EntityEdition" %>
<form id="form" runat="server"> 
    <div runat="server" class="wrapper reveal-side-navigation">
	    <div runat="server" class="wrapper-inner"> 
            <section runat="server" class="section-block replicable-content contact-2">
                <div runat="server" class="row">
				    <div class="column width-4">
					    <h2 class="mb-30">Edición de <%: BussinesObject.ToString() %></h2>
					    <div class="row">
						    <div class="column width-10">
							    <p>Aquí puedes editar los detalles de un/a  <%: BussinesObject.ToString() %>.</p>
                                <%--[<%: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") %>]--%>
						    </div>
					    </div>
				    </div>
				    <div class="column width-8 left">
					    <div runat="server" class="contact-form-container"> 	 
						    <div class="row" runat="server" id="entityControlsContainer">
                                
                                <%--  <div class="column width-6">
								    <input type="text" name="honeypot" class="form-honeypot form-element large" />
							    </div>

							    <div class="column width-12">
								    <div class="field-wrapper">
									    <textarea runat ="server" name="entityControl_Message" id="entityControl_Message" class="form-message form-element large" placeholder="mensaje" tabindex="7" required="required"></textarea>
								    </div>
							    </div>
                            </div> 
                                
                            <div class="column width-6">
                                <input type="datetime-local" id="date" name="date" value="<%:DateTime.Now.ToString("mm/dd/yyyy") %>"/>
                            </div>

                            <div class="column width-6">
                                <input type="date" name="bday" max="2000-01-01" value="<%:DateTime.Now.ToString("o") %>">
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
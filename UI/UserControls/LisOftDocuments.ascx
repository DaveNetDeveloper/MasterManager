<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LisOftDocuments.ascx.cs" Inherits="LisOftDocuments" %>

<div class="row">
	<div class="column width-12">
		<div class="row content-grid-1"> 
		<asp:GridView Visible="true" ID="gvDocumentos" Width="100%" runat="server" OnRowDataBound="gvDocumentos_RowDataBound" OnRowCommand="gvDocumentos_RowCommand" DataKeyNames="Id" AutoGenerateColumns="false" CssClass ="gridClass" EmptyDataText="No hay datos.">
        <Columns> 
            <asp:TemplateField>
            <HeaderStyle HorizontalAlign="Center" Width="50px" />
            <ItemStyle HorizontalAlign="Center" Width="50px" />
            <HeaderTemplate> 
                        <asp:CheckBox AutoPostBack="false" OnCheckedChanged="chkSelAll_Checked"  Enabled="true"  ID="chkSel" CssClass="chkSel" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox AutoPostBack="false" onClick="$('#buttonDonwload').addClass('btn-primary');$('#buttonDonwload').removeClass('buttondisable');" Enabled="true"  ID="chkSel" CssClass="chkSel" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Id" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" HeaderText="Id" />
          
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderText="Nombre" />

            <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderText="Tamaño" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblTamaño" Text='<%# Eval("Tamaño") + " Mb" %>'></asp:Label> 
            </ItemTemplate>
            </asp:TemplateField>  
             
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderText="Descripcion" />

            <asp:BoundField DataField="Ubicacion" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="125px" HeaderText="Ubicacion" />
             
            <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderStyle-VerticalAlign="Middle" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
            <ItemTemplate> 
                    <asp:ImageButton ImageAlign="Middle" CommandName='<%# Eval("Ubicacion") %>' Height="25px" ImageUrl='<%# Eval("Tipo").Equals("pdf") ? "~/Images/pdf.png" : "~/Images/doc.png" %>' ID="btnVerDocumento" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
            </ItemTemplate>
            </asp:TemplateField> 
        </Columns>
        </asp:GridView>

		</div>
    </div>
</div>
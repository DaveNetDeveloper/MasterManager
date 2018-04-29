<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EntityList.ascx.cs" Inherits="EntityList" %> 
<div class="row">
	<div class="column width-12">
		<div class="row content-grid-1">  
            <asp:GridView Visible="true" ID="GvEntityList" Width="100%" runat="server"  OnRowDataBound="GvEntityList_RowDataBound" 
                OnRowCommand="GvEntityList_RowCommand" DataKeyNames="Id" AutoGenerateColumns="false" CssClass ="gridClass" EmptyDataText="No hay datos." 
                ClientIDMode="AutoID"  FooterStyle-CssClass="mGrid" 
                HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Transparent" HeaderStyle-HorizontalAlign="Center" 
                HeaderStyle-Height="40px" GridLines="Horizontal" AllowPaging="true"
                OnPageIndexChanging="GvEntityList_OnPaging" AllowSorting="true" OnSorting="GvEntityList_Sorting"      
                PagerStyle-CssClass="pgr" PageSize="15" ShowFooter="false" AutoGenerateSelectButton="False"
                PagerStyle-Font-Bold="true"  PagerStyle-HorizontalAlign="Center" PagerStyle-Height="40px" >  
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" Position="Bottom" /> 
            <HeaderStyle Font-Bold="true" BackColor="DimGray" />
            <Columns> 
            <asp:TemplateField> 
                <HeaderTemplate> 
                    <asp:CheckBox AutoPostBack="true" OnCheckedChanged="ChkSelAll_Checked"  Enabled="true" ID="chkSel" CssClass="chkSel" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox AutoPostBack="true" onClick="$('#buttonDonwload').addClass('btn-primary');$('#buttonDonwload').removeClass('buttondisable');" OnCheckedChanged="ChkSel_Checked" Enabled="true"  ID="chkSel" CssClass="chkSel" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Id" SortExpression="Id" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" HeaderText="Id" />
          
            <asp:BoundField DataField="Nombre" SortExpression="Nombre" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderText="Nombre" />

            <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderText="Tamaño" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblTamaño" Text='<%# Eval("Tamaño") + " Mb" %>'></asp:Label> 
            </ItemTemplate>
            </asp:TemplateField>  
             
            <asp:BoundField DataField="Descripcion" SortExpression="Descripcion" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderText="Descripcion" />

            <asp:BoundField DataField="Ubicacion" SortExpression="Ubicacion"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="125px" HeaderText="Ubicacion" />
             
            <asp:TemplateField ItemStyle-VerticalAlign="Middle" SortExpression="Tipo" HeaderStyle-VerticalAlign="Middle" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
            <ItemTemplate> 
                    <asp:ImageButton ImageAlign="Middle" CommandName='<%# Eval("Ubicacion") %>' Height="25px" ImageUrl='<%# Eval("Tipo").Equals("pdf") ? "~/Images/pdf.png" : "~/Images/doc.png" %>' ID="btnVerDocumento" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
            </ItemTemplate>
            </asp:TemplateField> 
            </Columns>
            <FooterStyle BackColor="#c1c1c1" BorderWidth="1" ForeColor="#c1c1c1" />
        </asp:GridView> 
		</div>
    </div>  
    <asp:Button Visible="true" runat="server" ID="tnExportExcel" style="border-radius:0px" Text="Exportar a Excel" CssClass="blue" Width="150px" OnClick="BtnExportExcel_Click" /> 
    <br /> 
</div>

<%--<script>

    window.onload = function () {
        var pos = window.name || 0;
        window.scrollTo(0, pos);
    }
    window.onunload = function () {
        window.name = self.pageYOffset || (document.documentElement.scrollTop + document.body.scrollTop);
    }
</script>--%>
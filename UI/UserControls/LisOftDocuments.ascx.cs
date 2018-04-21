using System; 
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LisOftDocuments : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarDocumentos();
        } 
    }

    private void CargarDocumentos()
    {
        try
        {
            var entityDocumentos = new EntityDocumento();
            gvDocumentos.DataSource = entityDocumentos.GetList();
            gvDocumentos.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex;
        }
    }

    protected void chkSel_Checked(object sender, EventArgs e)
    {
        try
        {
            //Int32 rowSelectedRow = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;
            //Int32 idselected = Convert.ToInt32(gvTest.DataKeys[rowSelectedRow].Value);
            //List<Int32> lst = controlSelectedCenter(Convert.ToInt32(gvTest.DataKeys[rowSelectedRow].Value));

            //if (((CheckBox)sender).Checked)
            //{
            //    gvTest.Rows[rowSelectedRow].BackColor = System.Drawing.ColorTranslator.FromHtml("lemonchiffon");
            //    Session["SelectedTest"] = (Int32)Session["SelectedTest"] + 1;
            //    Int32 SelectedRow = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;

            //    dtTest.Rows[rowSelectedRow]["chkSelect"] = true;
            //}
            //else
            //{
            //    gvTest.Rows[rowSelectedRow].BackColor = System.Drawing.Color.White;

            //    Session["SelectedTest"] = (Int32)Session["SelectedTest"] - 1;

            //    lst.Remove(idselected);
            //    Session["SelectedTestID"] = lst;
            //    dtTest.Rows[rowSelectedRow]["chkSelect"] = false;
            //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
        }
    }

    protected void chkSelAll_Checked(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
        }
    }

    protected void gvDocumentos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
        //}
    }

    protected void gvDocumentos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = int.Parse(e.CommandArgument.ToString());
        string idDocumento = gvDocumentos.DataKeys[rowIndex]["Id"].ToString();

        Response.Redirect(e.CommandName);
    }
}
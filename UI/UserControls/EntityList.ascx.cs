using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls; 

public partial class EntityList : UserControl, IucEntityList
{
    #region [ PUBLIC PROPERTIES ]

    private IEntity _entity;
    public IEntity Entity
    {
        get
        {
            if(_entity == null)
            {
                _entity = EntityManager.GetEntity(EntityType);
            }
            return _entity;
        } 
    }

    public DataTable EntityDataTable
    {
        get
        {
            return Session["EntityDataTable"] as DataTable;
        }
        set
        {
            Session["EntityDataTable"] = (DataTable)value;
        }
    }

    public Enums.EntityType EntityType
    {
        get;
        set;
    }

    public IEnumerable<IModel> DataSource
    {
        get
        {
            return Session["DataSource"] as IEnumerable<IModel>;
        }
        set
        {
            Session["DataSource"] = value;
        }
    }
     
    public SortDirection Dir
    {
        get
        {
            if (Session["dirState"] == null)
            {
                Session["dirState"] = SortDirection.Ascending;
            }
            return (SortDirection)Session["dirState"];
        }
        set
        {
            Session["dirState"] = value;
        }

    }

    #endregion

    #region [ PAGE EVENTS ]

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) InitializeList(); 
    }

    #endregion

    #region [ PUBLIC METHODS ]

    public void InitializeList()
    { 
        LoadDataSource();
        LoadGridViewData();
    }

    public void LoadGridViewData()
    {
        GvEntityList.DataSource = DataSource;
        GvEntityList.DataBind();
    }

    public void LoadDataSource()
    {
        try
        {
            DataSource = Entity.GetList();
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
        }
    }

    public void ExportToExcel()
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pagina = new Page();
            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();

            GridView gridToExport = new GridView();

            //DataTable tableToExport = dtDocumento;
            //tableToExport.Columns.RemoveAt(7);

            gridToExport.DataSource = DataSource;
            gridToExport.DataBind();

            foreach (TableCell cell in gridToExport.HeaderRow.Cells)
            {
                cell.BackColor = System.Drawing.Color.DeepSkyBlue;
            }

            gridToExport.EnableViewState = false;

            pagina.EnableEventValidation = false;
            pagina.DesignerInitialize();
            pagina.Controls.Add(form);

            form.Controls.Add(gridToExport);

            pagina.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.AddHeader("Content-Disposition", "attachment;filename=DocumentsList.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

            //DataView dv = dtDocumento.DefaultView;
        }
        catch (Exception)
        {
            //Session["error"] = ex;
        }
    }

    #endregion

    #region [ GRID EVENTS ]

    protected void ChkSel_Checked(object sender, EventArgs e)
    {
        try
        {
            Int32 gvSelectedIndex = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;
            Int32 idselected = Convert.ToInt32(GvEntityList.DataKeys[gvSelectedIndex].Value);
            List<Int32> lst = ControlSelectedCenter(Convert.ToInt32(GvEntityList.DataKeys[gvSelectedIndex].Value));


            if (((CheckBox)sender).Checked)
            {
                GvEntityList.Rows[gvSelectedIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("lemonchiffon");
                Session["SelectedDocument"] = (Int32)Session["SelectedDocument"] + 1;
                Int32 SelectedRow = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;

                EntityDataTable.Rows[gvSelectedIndex]["chkSelect"] = true;
            }
            else
            {
                GvEntityList.Rows[gvSelectedIndex].BackColor = System.Drawing.Color.White; 
               Session["SelectedDocument"] = (Int32)Session["SelectedDocument"] - 1; 
                lst.Remove(idselected);
                Session["SelectedTestID"] = lst;
                EntityDataTable.Rows[gvSelectedIndex]["chkSelect"] = false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
        }
    }

    protected void ChkSelAll_Checked(object sender, System.EventArgs e)
    {
        //Dim rowSelectedRow As Integer = TryCast(TryCast(sender, CheckBox).Parent.Parent, GridViewRow).RowIndex

        System.Drawing.Color color;
        Boolean check;

        if (((CheckBox)sender).Checked)
        {
            check = true;
            color = System.Drawing.ColorTranslator.FromHtml("lemonchiffon");
            Session["SelectedDocument"] = GvEntityList.Rows.Count;

            Int32 SelectedRow = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;

            Session["SelectedDocumentID"] = SelectedRow; 
            //btnEliminar.Attributes.Add("class", "action red");
        }
        else
        {
            check = false;
            color = System.Drawing.Color.White;

            //btnEditar.Attributes.Add("class", "action"); 
        }

        Session["Checkall_selected"] = check;

        foreach (GridViewRow row in GvEntityList.Rows)
        {
            CheckBox cb = (CheckBox)(row.FindControl("chkSel"));
            cb.Checked = check;
            row.BackColor = color;

            Int32 idselected = Convert.ToInt32(GvEntityList.DataKeys[row.RowIndex].Value);
            if (check)
            {
                ControlSelectedCenter(idselected);
            }
            else
            {
                ControlSelectedCenter(idselected);
                //lo elimino aki fuera, pk no me va bien meter dentro el remove.
                ((List<Int32>)Session["SelectedDocumentID"]).Remove(idselected);
            } 
        } 
    }

    private List<Int32> ControlSelectedCenter(Int32 _idSC)
    { 
        if (Session["SelectedCenterID"] != null)
        {
            List<Int32> lst = (List<Int32>)Session["SelectedCenterID"];
            if (lst.Count != 0)
            {
                if (!lst.Contains(_idSC))
                {
                    lst.Add(_idSC);
                    Session["SelectedCenterID"] = lst;
                }
            } 
        }
        else
        {
            List<Int32> lstSelectedCentersbyID = new List<Int32>();
            lstSelectedCentersbyID.Add(_idSC);
            Session["SelectedDocumentID"] = lstSelectedCentersbyID;
        } 
        return (List<Int32>)Session["SelectedDocumentID"]; 
    }

    protected void GvEntityList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
        //}
    }

    protected void GvEntityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = int.Parse(e.CommandArgument.ToString());
        string idDocumento = GvEntityList.DataKeys[rowIndex]["Id"].ToString();

        Response.Redirect(e.CommandName);
    }

    #endregion

    #region [ BUTTON EVENTS ]

    protected void BtnExportExcel_Click(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void GvEntityList_OnPaging(object sender, GridViewPageEventArgs e)
    {
        GvEntityList.PageIndex = e.NewPageIndex;
        GvEntityList.DataBind();
    }

    protected void GvEntityList_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortDir = string.Empty;
        if (Dir == SortDirection.Ascending)
        {
            Dir = SortDirection.Descending;
            SortDir = "Desc";
        }
        else
        {
            Dir = SortDirection.Ascending;
            SortDir = "Asc";
        }

        //DataTable dt = CargarGridView();
        //DataView sortedView = new DataView(DataSource);
        //sortedView.Sort = e.SortExpression + " " + SortDir;

        GvEntityList.DataSource = DataSource;
        GvEntityList.DataBind();
        //dtDocumento = sortedView.Table; 
    }

    #endregion
}
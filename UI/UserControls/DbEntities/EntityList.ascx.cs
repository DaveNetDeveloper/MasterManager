﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class EntityList : BaseUC
{
    #region [ private properties ]

    public Type ModelClass { get; set; }

    private DataTable EntityDataTable
    {
        get {
            return Session["EntityDataTable"] as DataTable;
        }
        set {
            Session["EntityDataTable"] = value;
        }
    }
    private IEnumerable<IModel> DataSource
    {
        get {
            if (Session["DataSource"] == null) Session["DataSource"] = EntityManager.GetEntity().GetList();
            return (IEnumerable<IModel>)Session["DataSource"]; 
        }
        set {
            Session["DataSource"] = value;
        }
    }
    private SortDirection Dir
    {
        get {
            if (Session["dirState"] == null) {
                Session["dirState"] = SortDirection.Ascending;
            }
            return (SortDirection)Session["dirState"];
        }
        set {
            Session["dirState"] = value;
        } 
    }

    #endregion

    #region [ UC Events ]

    protected override void OnInit(EventArgs e)
    {
        if (!IsPostBack) {
            InitializeCache();
            EntityManager.InitializeTypes(BussinesObject, ProyectName);
            InitializeControls();
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack) {
            InitializeList();
        }
    }

    #endregion

    #region [ private methods ]

    private void InitializeCache()
    {
        DisposeProperties();
        InitializeSession();
    }
    private void DisposeProperties()
    {
        EntityManager = null;
        DataSource = null;
        ControlList = null;
        Entity = null;
    }
    private void InitializeControls()
    {
        InitializeGridView();
        InitializeColumns();
    }
    private void InitializeColumns()
    {
        //GvEntityList.Columns.Clear();
 
        BoundField tempId = new BoundField(); 
        tempId.HeaderText = "Id";
        tempId.DataField = "Id";
        tempId.SortExpression = "Id";
        GvEntityList.Columns.Add(tempId);

        BoundField tempNombre = new BoundField();
        tempNombre.HeaderText = "Nombre";
        tempId.SortExpression = "Nombre";
        tempNombre.DataField = "Nombre";
        GvEntityList.Columns.Add(tempNombre);

        BoundField tempUbicacion = new BoundField();
        tempUbicacion.HeaderText = "Ubicacion";
        tempUbicacion.SortExpression = "Ubicacion";
        tempUbicacion.DataField = "Ubicacion";
        GvEntityList.Columns.Add(tempUbicacion);

        BoundField tempDescripcion = new BoundField();
        tempDescripcion.HeaderText = "Descripcion";
        tempDescripcion.SortExpression = "Descripcion";
        tempDescripcion.DataField = "Descripcion";
        GvEntityList.Columns.Add(tempDescripcion);

        BoundField tempTamaño = new BoundField();
        tempTamaño.HeaderText = "Tamaño";
        tempTamaño.SortExpression = "Tamaño";
        tempTamaño.DataField = "Tamaño";
        GvEntityList.Columns.Add(tempTamaño);

        //TemplateField tempTamaño = new TemplateField();
        //tempTamaño.HeaderText = "Tamaño"; 
        //var label = new Label();
        //label.ID = "lblTamaño";
        //label.Text = " Mb";

       // tempTamaño.ItemTemplate = label as ITemplate;

    }
    private void InitializeGridView()
    { 
        //GridView gridView = new GridView();
        GvEntityList.Visible = true;
        GvEntityList.ID = "GvEntityList";
        GvEntityList.ClientIDMode = ClientIDMode.AutoID;
        GvEntityList.Width = Get100PErcentValue();
        GvEntityList.RowDataBound += GvEntityList_RowDataBound;
        GvEntityList.RowCommand += GvEntityList_RowCommand;
        GvEntityList.DataKeyNames = new string[] { "Id" }; 
        GvEntityList.AutoGenerateColumns = false;
        GvEntityList.CssClass = "gridClass";
        GvEntityList.EmptyDataText = "No hay datos.";
        GvEntityList.HeaderStyle.Font.Bold = true;
        //GvEntityList.Bold = true;
        GvEntityList.HeaderStyle.BackColor = Color.DimGray;//Transparent;
        GvEntityList.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        GvEntityList.HeaderStyle.Height = 40;
        GvEntityList.GridLines = GridLines.Horizontal;
        GvEntityList.AllowPaging = true;
        GvEntityList.PageIndexChanging += GvEntityList_OnPaging;
        GvEntityList.AllowSorting = true;
        GvEntityList.Sorting += GvEntityList_Sorting;
        GvEntityList.PagerStyle.CssClass = "pgr";
        GvEntityList.PageSize = 15;
        GvEntityList.ShowFooter = false;
        GvEntityList.AutoGenerateSelectButton = false;
        GvEntityList.PagerStyle.Font.Bold = true;
        GvEntityList.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
        GvEntityList.PagerStyle.Height = 40;
         
        //var pagerSettings = new PagerSettings();
        //pagerSettings.Mode = PagerButtons.NumericFirstLast;
        //pagerSettings.PageButtonCount = 5;
        //pagerSettings.Position = PagerPosition.Bottom;
        //GvEntityList.PagerSettings = pagerSettings;

        //GvEntityList.Columns = GetColumnItems(); 
        Controls.Add(GvEntityList);
    }  
    private void InitializeList()
    {
        GvEntityList.DataSource = DataSource;
        GvEntityList.DataBind();
    }
    private void ExportToExcel()
    {
        try {
            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pagina = new Page();
            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();

            GridView gridToExport = new GridView {
                DataSource = DataSource
            };

            //DataTable tableToExport = dtDocumento;
            //tableToExport.Columns.RemoveAt(7);

            gridToExport.DataBind();

            foreach (TableCell cell in gridToExport.HeaderRow.Cells) {
                cell.BackColor = Color.DeepSkyBlue;
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
    private List<Int32> ControlSelectedCenter(Int32 _idSC)
    {
        if (Session["SelectedCenterID"] != null) {
            List<Int32> lst = (List<Int32>)Session["SelectedCenterID"];
            if (lst.Count != 0) {
                if (!lst.Contains(_idSC)) {
                    lst.Add(_idSC);
                    Session["SelectedCenterID"] = lst;
                }
            }
        }
        else {
            List<Int32> lstSelectedCentersbyID = new List<Int32> { _idSC };
            Session["SelectedDocumentID"] = lstSelectedCentersbyID;
        }
        return (List<Int32>)Session["SelectedDocumentID"];
    }
    private Unit Get100PErcentValue()
    {
        return new Unit(100, UnitType.Percentage);
    }

    #endregion

    #region [ gridview events ]

    protected void ChkSel_Checked(object sender, EventArgs e)
    {
        try {
            Int32 gvSelectedIndex = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;
            Int32 idselected = Convert.ToInt32(GvEntityList.DataKeys[gvSelectedIndex].Value);
            List<Int32> lst = ControlSelectedCenter(Convert.ToInt32(GvEntityList.DataKeys[gvSelectedIndex].Value));

            if (((CheckBox)sender).Checked) {
                GvEntityList.Rows[gvSelectedIndex].BackColor = ColorTranslator.FromHtml("lemonchiffon");
                Session["SelectedDocument"] = (Int32)Session["SelectedDocument"] + 1;
                Int32 SelectedRow = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
                EntityDataTable.Rows[gvSelectedIndex]["chkSelect"] = true;
            }
            else {
                GvEntityList.Rows[gvSelectedIndex].BackColor = Color.White; 
                Session["SelectedDocument"] = (Int32)Session["SelectedDocument"] - 1; 
                lst.Remove(idselected);
                Session["SelectedTestID"] = lst;
                EntityDataTable.Rows[gvSelectedIndex]["chkSelect"] = false;
            }
        }
        catch (Exception ex) {
            Session["error"] = ex;
        }
    } 
    protected void ChkSelAll_Checked(object sender, EventArgs e)
    {
        //Dim rowSelectedRow As Integer = TryCast(TryCast(sender, CheckBox).Parent.Parent, GridViewRow).RowIndex

        var currentCheck = ((CheckBox)sender);

        Color color;
        Boolean check = currentCheck.Checked;

        if (currentCheck.Checked)
        {
            color = ColorTranslator.FromHtml("lemonchiffon");
            Session["SelectedDocument"] = GvEntityList.Rows.Count;

            Int32 SelectedRow = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;

            Session["SelectedDocumentID"] = SelectedRow; 
            //btnEliminar.Attributes.Add("class", "action red");
        }
        else
        {
            color = Color.White;
            //btnEditar.Attributes.Add("class", "action"); 
        }

        Session["Checkall_selected"] = check;

        foreach (GridViewRow row in GvEntityList.Rows)
        {
            CheckBox cb = (CheckBox)(row.FindControl("chkSel"));
            cb.Checked = check;
            row.BackColor = color;

            Int32 idselected = Convert.ToInt32(GvEntityList.DataKeys[row.RowIndex].Value);
            ControlSelectedCenter(idselected);
            if (!check)
            {
                ((List<Int32>)Session["SelectedDocumentID"]).Remove(idselected);
            }
        } 
    }  
    protected void GvEntityList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
        }
    } 
    protected void GvEntityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = int.Parse(e.CommandArgument.ToString());
        string idDocumento = GvEntityList.DataKeys[rowIndex]["Id"].ToString();

        Response.Redirect(e.CommandName);
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

    #region [ button events ]

    protected void BtnExportExcel_Click(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    #endregion
}
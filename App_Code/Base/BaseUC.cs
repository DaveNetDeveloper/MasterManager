using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using BussinesTypedObject;

public class BaseUC : UserControl
{
    public enum ViewMode
    {
        None,
        View,
        Edit,
        Create
    }
    public enum ActionsForControl
    {
        ClearValue,
        SetValue,
        GetValue,
        SetBorderColor
    }

    #region [ properties ]

    public string PrimaryKey
    {
        get
        {
            return (string)Session["PrimaryKey"];
        }
        set
        {
            Session["PrimaryKey"] = value;
        }
    }
    public ViewMode Mode
    {
        get { 
            if (Session["Mode"] == null) Session["Mode"] = ViewMode.None;
            return (ViewMode)Session["Mode"];
        }
        set {
            Session["Mode"] = value;
        }
    }
    public string PageTitle
    {
        get {
            return "Título";
        }
    }
     
    public List<Control> ControlList
    {
        get {
            if (null == Session["ControlList"]) Session["ControlList"] = new List<Control>();
            return (List<Control>)Session["ControlList"];
        }
        set {
            Session["ControlList"] = value;
        }
    }


    public EntityManager EntityManager
    {
        get {
            try {
                if (Session["EntityManager"] == null) Session["EntityManager"] = new EntityManager(ProyectName);
                return (EntityManager)Session["EntityManager"];
            }
            catch (Exception ex){
                throw ex;
            }
        }
        set {
            Session["EntityManager"] = value;
        }
    }
    public IEntity Entity
    {
        get {
            try {
                if (Session["Entity"] == null) Session["Entity"] = EntityManager.GetEntity();
                return (IEntity)Session["Entity"];
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        set {
            Session["Entity"] = value;
        }
    }
    public BussinesTypes.BussinesObjectType BussinesObject { get; set; }
    public BussinesTypes.ProyectName ProyectName
    {
        get
        {
            return (BussinesTypes.ProyectName)Enum.Parse(typeof(BussinesTypes.ProyectName), Settings.ProyectName);
        }
    }

    protected Color GrayHtmlColor = ColorTranslator.FromHtml("#e2e2e2");
    protected string UIControlPrefix = "entityControl_"; 
    protected Color invalidDataColor = Color.Red;

    #endregion

    #region [ methods ]

    protected void AplicarIdioma(CultureInfo culture)
    {
        try {
            Thread.CurrentThread.CurrentUICulture = culture;
        }
        catch (Exception ex) {
            throw ex;
        }
    }
    protected void ErrorTreatment(Exception ex)
    {
        Session["error"] = ex;
        //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "FillCenter()", ex.Message, DateTime.Now, 1);
        //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
    }
    protected void GetPrimaryKey()
    {
        //Substituir "Id" por la variable PrimaryKeyName que se obtiene de la definicion de base de datos
        if (!string.IsNullOrEmpty(Request.QueryString["Id"])) PrimaryKey = Request.QueryString["Id"].ToString();
        else throw new Exception();
    }
    protected void GetViewMode()
    {
        if (Request.QueryString["M"] != null) {
            switch (Request.QueryString["M"].ToString()) {
                case "V":
                    Mode = ViewMode.View;
                    break;
                case "E":
                    Mode = ViewMode.Edit;
                    break;
                case "N":
                    Mode = ViewMode.Create;
                    break;
                default:
                    Mode = ViewMode.None;
                    break;
            }
        }
        else {
            Mode = ViewMode.None;
        }

        if (Mode == ViewMode.None) throw new Exception();
    }
    protected void SetControlAsInvalid(TextBox control, ref bool validationResult)
    {
        validationResult = false;
        control.BorderColor = invalidDataColor;
        control.BorderWidth = new Unit(1);
    }
    protected void LoadControls()
    {
        ControlList = new List<Control>();
        foreach (Control form in Controls) {
            if (form.GetType().Name.Equals("HtmlForm")) {
                foreach (Control c in form.Controls) {
                    if ((c.GetType().Name.ToLower().Equals("textbox")) || (c.GetType().Name.ToLower().Contains("checkbox"))) {
                        if (c.ID.Contains(UIControlPrefix)) ControlList.Add(c);
                    }
                    else {
                        try {
                            if (((HtmlControl)c).TagName.ToLower().Equals("textarea")) {
                                ControlList.Add(c);
                            }
                        }
                        catch (Exception ex) {
                            var except = ex;
                        }
                    }
                }
                break;
            }
        }
    }
    protected void ActivateControls(bool enabled)
    {
        foreach (Control c in ControlList) {
            switch (c.GetType().Name) {
                case "TextBox":
                    ((TextBox)c).Enabled = enabled;
                    break;
                case "HtmlInputCheckBox":
                    ((HtmlInputCheckBox)c).Disabled = (enabled) ? false : true;
                    break;
                case "CheckBox":
                    ((CheckBox)c).Enabled = enabled;
                    break;
                case "HtmlTextArea":
                    ((HtmlTextArea)c).Disabled = !enabled;
                    break;
            }
        }
    }
    protected void ResetControlValues()
    {
        foreach (Control c in ControlList) {
            switch (c.GetType().Name) {
                case "TextBox":
                    ((TextBox)c).Text = string.Empty;
                    break;
                case "CheckBox":
                    ((CheckBox)c).Checked = false;
                    break;
                case "HtmlInputCheckBox":
                    ((HtmlInputCheckBox)c).Checked = false;
                    break;
                case "HtmlTextArea":
                    ((HtmlTextArea)c).Value = string.Empty;
                    break;
            }
        }
    }
    protected void ActionForControl(object value, string propertyName)
    {
        //if(action == ActionsForControl.SetValue)

        foreach (Control c in ControlList) {
            if (c.ClientID.Contains(propertyName))
            { 
                switch (c.GetType().Name) {
                case "TextBox": 
                    ((TextBox)c).Text = value.ToString(); 
                    break;
                case "CheckBox":
                    ((CheckBox)c).Checked = (bool)value;
                    break;
                case "HtmlInputCheckBox":
                    ((HtmlInputCheckBox)c).Checked = (bool)value;
                    break;
                case "HtmlTextArea":
                    ((HtmlTextArea)c).Value = value.ToString();
                    break;
                    } 
            }
        }
    }
    protected void InitializeSession()
    {
        if (null == Session || !(Session.Count > 0)) {
            Session["SessionStartTicks"] = DateTime.Now.Ticks;
            Session["SessionID"] = Session.SessionID;
            Session["UserClosedCokkiesBar"] = false;
        }
    }

    #endregion 
}
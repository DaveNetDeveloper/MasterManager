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
    public enum ViewMode {
        None,
        View,
        Edit,
        Create
    }
    public enum ActionsForControl {
        ClearValue,
        SetValue,
        GetValue,
        SetBorderColor
    }
    public enum UserControlTypes {
        None,
        EntitiesList,
        EntityEdition
    }

    #region [ properties ]

    public UserControlTypes UCType
    {
        get {
            if (Session["UCType"] == null) Session["UCType"] = UserControlTypes.None;
            return (UserControlTypes)Session["UCType"];
        }
        set {
            Session["UCType"] = value;
        }
    }
    public string PrimaryKey
    {
        get {
            return (string)Session["PrimaryKey"];
        }
        set {
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
            catch (Exception ex) {
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
        get {
            return (BussinesTypes.ProyectName)Enum.Parse(typeof(BussinesTypes.ProyectName), Settings.ProyectName);
        }
    }

    protected Color GrayHtmlColor = ColorTranslator.FromHtml("#e2e2e2");
    protected const string UIControlPrefix = "entityControl_";
    protected Color invalidDataColor = Color.Red; 

    #endregion

    #region [ methods ]

    protected void ApplyLanguage(CultureInfo culture)
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
            switch (Request.QueryString["M"]) {
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
    protected void ActivateControls(bool enabled)
    {
        foreach (Control c in ControlList) {
            switch (c.GetType().Name) {
                case "TextBox":
                    ((TextBox)c).Enabled = enabled;
                    break;
                case "HtmlInputCheckBox":
                    ((HtmlInputCheckBox)c).Disabled = (!enabled);
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
                    //if (ContainsDateTimeData(((TextBox)c).Text)) ((TextBox)c).Text = dateTimeDefaultMask;
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
    protected void InitializeSession()
    {
        Session.RemoveAll();
        Session["SessionStartTicks"] = DateTime.Now.Ticks;
        Session["SessionID"] = Session.SessionID;
        Session["UserClosedCokkiesBar"] = false;
    }
    protected bool ContainsDateTimeData(string textData)
    {
        return textData.Contains("/") && textData.Trim().Length.Equals(10);
    }

    #endregion 
}
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;
using System.Web.UI;

public class BasePage : Page
{
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
    public enum ViewMode
    {
        View,
        Edit,
        Create,
        None
    }
    public ViewMode Mode
    {
        get
        {
            return (ViewMode)Session["Mode"];
        }
        set
        {
            Session["Mode"] = value;
        }

    }

    protected Color HtmlColor = ColorTranslator.FromHtml("#e2e2e2");
    private Color invalidDataColor = Color.Red;

    public string PageTitle {
        get
        {
            return "Título";
        }
    }

    public Type ModelClass { get; set; }

    protected IEntity Entity
    {
        get {
            if (Session["Entity"] == null) {
                Session["Entity"] = EntityManager.GetEntity(ModelClass);
            }
            return (IEntity)Session["Entity"];
        }
        set {
            Session["Entity"] = value;
        }
    }
    protected IModel Model
    {
        get
        {
            if (Session["Model"] == null) Session["Model"] = Entity.GetByPrimaryKey(Int32.Parse(PrimaryKey));
            return (ModelUsuarioAlumno)Session["Model"];
        }
        set
        {
            Session["Model"] = value;
        }
    }
    protected ModelUsuarioAlumno UIModel;

    //methods
    protected void GetPrimaryKey()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"])) PrimaryKey = Request.QueryString["Id"].ToString();
    }
    protected void GetViewMode()
    {
        if (Request.QueryString["M"] != null)
        {
            switch (Request.QueryString["M"].ToString())
            {
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
    }
    protected void SetControlAsInvalid(TextBox control, ref bool validationResult)
    {
        validationResult = false;
        control.BorderColor = invalidDataColor;
        control.BorderWidth = new Unit(1);
    }
    //protected override void OnPreInit(EventArgs e)
    //{
    //    try
    //    {
    //        if (!IsPostBack)
    //        {
    //            if (Session == null || ! (Session.Count > 0))
    //            {
    //                Session["SessionStartTicks"] = DateTime.Now.Ticks;  
    //                Session["SessionID"] = Session.SessionID;
    //                Session["UserClosedCokkiesBar"] = false; 
    //            }

    //            //AplicarIdioma(new CultureInfo(Utils.GetDefautLanguage()));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //Log ex as ERROR
    //    }
    //} 
    protected void AplicarIdioma(CultureInfo culture)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = culture;
            }
            catch (Exception)
            {
                //Log ex as ERROR
            }
        }
} 
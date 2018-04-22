using System;
using System.Collections;
using System.Globalization;
using System.Resources;

public partial class Master_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    { 
    }

    #region [ METHODS ]

    private void ApplyMasterLayaout()
    {  
        //GENERIC
        btnCrear.Attributes.Add("title", GetGlobalResorce("btnCrear"));
        btnEditar.Attributes.Add("title", GetGlobalResorce("btnEditar"));
        btnVer.Attributes.Add("title", GetGlobalResorce("btnVer"));
        btnEliminar.Attributes.Add("title", GetGlobalResorce("btnEliminar"));
        btnSMS.Attributes.Add("title", GetGlobalResorce("btnSMS"));

        //For edit page
        //btnVolverAtras.Attributes.Add("title", GetGlobalResorce("btnVolverAtras"));
        //btnVolverAtras.InnerText = GetGlobalResorce("btnVolverAtras");

        //btnSave.Attributes.Add("title", GetGlobalResorce("btnSave"));
        //btnSave.InnerText = GetGlobalResorce("btnSave");

        //For edit page
        //btnVolverAtras.Attributes.Add("title", "Volver");
        //btnVolverAtras.InnerText = "Volver";

        //btnSave.Attributes.Add("title", "Guardar");
        //btnSave.InnerText = "Guardar";
    }

    private string GetGlobalResorce(string key)
    {
        ResourceSet resourceSet = null;
        ResourceManager rm = new ResourceManager(typeof(Resources.resource));
        resourceSet = (rm.GetResourceSet((CultureInfo)Session["CultureInfoByUser"], true, true));

        foreach (DictionaryEntry entry in resourceSet)
        {
            if (entry.Key.ToString() == key)
            {
                return entry.Value.ToString();
            }
            //string resourceKey = entry.Key.ToString();
            //object resource = entry.Value;
        }
        return "sin traducción";
    }

    #endregion

    #region [ LOGIN EVENTS]

    protected void registerLink_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Constants.PAGE_TITLE_ACCOUNT_LOGIN + Constants.ASP_PAGE_EXTENSION, false);
    }

    protected void loginLink_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Constants.PAGE_TITLE_ACCOUNT_LOGIN + Constants.ASP_PAGE_EXTENSION, false);
    }

    protected void logOff_OnClick(object sender, EventArgs e)
    {
        Session["IsLoginUser"] = String.Empty;
        Session.RemoveAll();
        //Response.Redirect(Constants.PAGE_TITLE_ACCOUNT_LOGIN + Constants.ASP_PAGE_EXTENSION, false);
    }

    #endregion

    #region [ TRANSLATION EVENTS ]

    protected void LbCatalan_Click(object sender, EventArgs e)
    {
        Session["CultureInfoByUser"] = new CultureInfo(Constants.CULTURE_INFO_CATALAN);
        setCulture(Session["CultureInfoByUser"] as CultureInfo);
    }

    protected void LbSpanish_Click(object sender, EventArgs e)
    {
        Session["CultureInfoByUser"] = new CultureInfo(Constants.CULTURE_INFO_ESPAÑOL);
        setCulture(Session["CultureInfoByUser"] as CultureInfo);
    }

    protected void LbEnglish_Click(object sender, EventArgs e)
    {
        Session["CultureInfoByUser"] = new CultureInfo(Constants.CULTURE_INFO_INGLES);
        setCulture(Session["CultureInfoByUser"] as CultureInfo);
    }

    private void setCulture(CultureInfo c)
    {
        //System.Threading.Thread.CurrentThread.CurrentCulture = c;
        //System.Threading.Thread.CurrentThread.CurrentUICulture = c;

        Server.Transfer(this.Request.Path);
        //Menu.DataBind();
    }

    #endregion
}
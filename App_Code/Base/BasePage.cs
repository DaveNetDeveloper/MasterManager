using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;
using System.Web.UI;

public class BasePage : Page
{
    private Color invalidDataColor = Color.Red;
    protected Color HtmlColor
    {
        get
        { 
            return ColorTranslator.FromHtml("#e2e2e2");
        } 
    }
    public enum ViewMode
    {
        View,
        Edit,
        Create
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
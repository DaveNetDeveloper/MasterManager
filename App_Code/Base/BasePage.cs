using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;

public class BasePage : Page
{
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
    private void AplicarIdioma(CultureInfo culture)
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
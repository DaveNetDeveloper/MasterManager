using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Text;
using MySql.Data;
using System.Net;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Collections;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

public partial class UserAlumnoList : BasePage
{
    #region [ PROPERTIES ]

    public DataTable dtPrivateUser
    {
        get
        {
            return Session["dtPrivateUser"] as DataTable;
        }
        set
        {
            Session["dtPrivateUser"] = (DataTable)value;
        }
    }

    public SortDirection dir
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

    #region [ PAGE_EVENTS ]

    protected void Page_Init(object sender, EventArgs e)
    {
       
        if (!this.IsPostBack)
        {
            Session["SelectedPrivateUserID"] = null;
            Session["Checkall_selected"] = false;
            
            SetUserAgentCulture();

            Session["rm"] = (ResourceManager)Application["RM"];
        }
       else
       {


       }
    }
     
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                //Session["dtPrivateUser"] = null;
                if (null != Request["__EVENTTARGET"] && Request["__EVENTTARGET"].Contains("ctl00$FeaturedContent$"))
                {
                    dtPrivateUser = CargarGridView();
                    gvPrivateUser.DataSource = dtPrivateUser;
                    //setCheckInGridView();
                    gvPrivateUser.DataBind();
                }
                else
                {
                    gvPrivateUser.DataSource = CargarGridView();
                    gvPrivateUser.DataSource = dtPrivateUser;
                    gvPrivateUser.DataBind();
                }

                Session["SelectedPrivateUser"] = 0;

                divResultadoEnvioSMS.InnerHtml = string.Empty;

                lblRecuerda.Text = Constants.SendSMS_ReminderTextMessage;

                mySMSModalPanel.Style.Add(HtmlTextWriterStyle.Visibility, "hide");
                mySMSModalBackground.Style.Add(HtmlTextWriterStyle.Display, "hidden");

            }
            else
            {
                gvPrivateUser.DataSource = (DataTable)Session["dtPrivateUser"];

                mySMSModalPanel.Style.Add(HtmlTextWriterStyle.Visibility, "hide");
                mySMSModalBackground.Style.Add(HtmlTextWriterStyle.Display, "hidden");

                if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"] == Constants.ACTIONS_LIST_PAGE_DELETE)
                {
                    EliminarSeleccionados();
                    Session["SelectedPrivateUserID"] = null;
                    Session["Checkall_selected"] = false;

                    gvPrivateUser.DataSource = CargarGridView();
                    gvPrivateUser.DataSource = dtPrivateUser;
                    gvPrivateUser.DataBind();
                }
                else if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"] == Constants.ACTIONS_LIST_SEND_SMS)
                {
                    EnvioSMS();
                }
                else if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"] == Constants.ACTIONS_LIST_PAGE_CREATE)
                {
                    Crear();
                }
                else if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"] == Constants.ACTIONS_LIST_PAGE_VIEW)
                {
                    VerSeleccionado();
                }
                else if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"] == Constants.ACTIONS_LIST_PAGE_EDIT)
                {
                    EditarSeleccionado();
                }
                else if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"] == Constants.ACTIONS_LIST_EXPORT_EXCEL)
                {
                    ExportExcel();
                }
                else if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"] == Constants.ACTIONS_LIST_FILTRAR_LISTADO)
                {
                    HtmlInputText txtSearch = (HtmlInputText)Master.FindControl("txtSearch");
                    
                    if (txtSearch.Value.Trim() != string.Empty)
                    {
                        gvPrivateUser.DataSource = CargarGridView(txtSearch.Value);
                        gvPrivateUser.DataSource = dtPrivateUser;
                        gvPrivateUser.DataBind();
                    }
                    else
                    {
                        gvPrivateUser.DataSource = CargarGridView(string.Empty);
                        gvPrivateUser.DataSource = dtPrivateUser;
                        gvPrivateUser.DataBind();
                    }
                }
                //setCheckInGridView();
                //gvCenter.DataBind();
            }

            // "<b>" + LiteralCultura + "</b>" +
//            LinkButton1.Text = Thread.CurrentThread.CurrentCulture.DisplayName;
        }
        catch (Exception ex)
        {
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
            Session["error"] = ex;
        }
    }

    #endregion

    #region [ METHODS ]

    protected void setCheckInGridView()
    {
        try
        {
            //Recorrer el gridview
            foreach (GridViewRow row in gvPrivateUser.Rows)
            {
                CheckBox checkItem = (CheckBox)row.FindControl("chkSel");

                dtPrivateUser.Rows[row.RowIndex]["chkSelect"] = checkItem.Checked;

                checkItem.Checked = getCheckByRowIndex(row.RowIndex);

                //if (null != row.Cells[5] && row.Cells[5].Text != string.Empty)
                // {


                // }
                // else
                // {


                // }


            }
            /*if(e.Row.RowType == DataControlRowType.DataRow)
            {
               int i = e.Row.DataItemIndex;

               CheckBox checkItem = (CheckBox)(e.Row.FindControl("chkSel"));

               //getCheckByRowIndex(e.Row.RowIndex);

               checkItem.Checked = getCheckByRowIndex(i);

                //["chkSelect"] = getCheckByRowIndex(e.Row.RowIndex);

            }*/


        }
        catch (Exception ex)
        {
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
            Session["error"] = ex;
        }

    }
  
    protected void SetUserAgentCulture()
    {
        //Todos los lengaujes del navegador
        /*StringBuilder sb = new StringBuilder();
        string _lng = string.Empty;
        foreach (string lng in Request.UserLanguages)
        {
            sb.Append(lng);
            sb.Append("<br />");
        }*/

        //Label1.Text = sb.ToString();

        //if (Session["CultureInfoByUser"] == null)
        //{ 
        Session["CultureInfoByUser"] = CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);//new CultureInfo(Constants.CULTURE_INFO_INGLES);
        /* }
         else
         {

         }*/
    }

    protected override void InitializeCulture()
    {
        //La cultura debería de venir de la información del usuario logeado en el sistema y seteada en la Session["CultureInfoByUser"]
        //CultureInfo culture = new CultureInfo(Constants.CULTURE_INFO_CATALAN);
        if (null != Session["CultureInfoByUser"] && Session["CultureInfoByUser"].ToString().Length > 2)
        {
            Thread.CurrentThread.CurrentCulture = (CultureInfo)Session["CultureInfoByUser"];
            Thread.CurrentThread.CurrentUICulture = (CultureInfo)Session["CultureInfoByUser"];
        }
        base.InitializeCulture();
    }

    protected bool getCheckByRowIndex(int rowIndex)
    {
        try
        {

            //Int32 idCenter = Convert.ToInt32(((DataTable)Session["dtPrivateUser"]).Rows[rowIndex]["ID"]);
            if (((List<Int32>)Session["SelectedPrivateUserID"]) != null)
            {
                if (((List<Int32>)Session["SelectedPrivateUserID"]).Contains(rowIndex))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            ///por cada rowIndex igualar el campo check a la columna check
            //string checkString = (((DataTable)Session["dtPrivateUser"]).Rows[rowIndex]["chkSelect"]).ToString();
            //return bool.Parse(checkString);

        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
            return false;
        }
    }

    protected void EnvioSMS()
    {
        Session["lstMensajePopUp_Destinatarios"] = new List<string>();
        string mensajePopUp_Destinatarios = string.Empty;

        Session["lstMensajePopUp_Textos"] = new List<string>();
        
        string mensajeGenerico = "[NOMBRE], estos son sus datos de acceso para el area privada de www.EscuelaNauticaSantalo.com:" + "\n" + "USUARIO: [USUARIO]" + "\n" + "Clave: [CONTRASEÑA]" + "\n" + "Un saludo.";
        txtContenidoSMS.Text = mensajeGenerico;

        //Preparar popUp
        foreach (Int32 id in (List<Int32>)Session["SelectedPrivateUserID"])
        {
            foreach (DataRow dr in dtPrivateUser.Rows)
            {
                if (int.Parse(dr["id"].ToString()) == id)
                {
                    ((List<string>)Session["lstMensajePopUp_Destinatarios"]).Add(dr["phone"].ToString().Trim());
                    mensajePopUp_Destinatarios += dr["name"].ToString() + " " + dr["surname"].ToString() + " - " + dr["phone"].ToString().Trim() + Environment.NewLine;

                    string mensajePersonalizado;
                    mensajePersonalizado = mensajeGenerico.Replace("[NOMBRE]", dr["name"].ToString());
                    mensajePersonalizado = mensajePersonalizado.Replace("[USUARIO]", dr["user_name"].ToString());
                    mensajePersonalizado = mensajePersonalizado.Replace("[CONTRASEÑA]", dr["password"].ToString());

                    ((List<string>)Session["lstMensajePopUp_Textos"]).Add(mensajePersonalizado);
                }
            }
        }

        txtDestinatariosSMS.Text = mensajePopUp_Destinatarios;
        
        //SHOW POP UP FOR SEND SMS CONFIRMATION
        mySMSModalPanel.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        mySMSModalBackground.Style.Add(HtmlTextWriterStyle.Display, "block");
    }

    protected void Crear()
    {
        //Response.Redirect(Constants.PAGE_TITLE_EditUserAlumno + Constants.ASP_PAGE_EXTENSION + "?M=N", false);
    }

    protected void VerSeleccionado()
    {
        //int Id = ((List<Int32>)Session["SelectedPrivateUserID"])[0];
       // Response.Redirect(Constants.PAGE_TITLE_EditUserAlumno + Constants.ASP_PAGE_EXTENSION + "?M=V&Id=" + Id, false);

    }

    protected void EditarSeleccionado()
    {
        //int Id = ((List<Int32>)Session["SelectedPrivateUserID"])[0];
        //Response.Redirect(Constants.PAGE_TITLE_EditUserAlumno + Constants.ASP_PAGE_EXTENSION + "?M=E&Id=" + Id, false);


    }

    protected void EliminarSeleccionados()
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

        foreach (Int32 id in (List<Int32>)Session["SelectedPrivateUserID"])
        {
            string consulta = "DELETE FROM USER_ALUMNO WHERE ID =" + id;
            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(consulta, cnn);
            cnn.Open();
            mc.ExecuteNonQuery();
            cnn.Close();
        }
    }

    protected DataTable CargarGridView(string filter = "")
    {
        try
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;
            string language_code = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString();

            string sConsulta = string.Empty;

            if(filter == String.Empty)
            {
                sConsulta = "SELECT id, name, surname, birth_date, mail, user_name, password, entered, active, created, updated, phone FROM USER_ALUMNO ORDER BY ID DESC";
            }
            else
            {
                sConsulta = "SELECT id, name, surname, birth_date, mail, user_name, password, entered, active, created, updated, phone ";

                sConsulta += " FROM USER_ALUMNO ";

                sConsulta += " WHERE (name like '%" + filter + "%') ";

                sConsulta += " OR (surname like '%" + filter + "%') ";

                sConsulta += " OR (user_name like '%" + filter + "%') ";

                sConsulta += " OR (phone like '%" + filter + "%') ";

                sConsulta += " ORDER BY ID DESC ";
                 
            }
           
            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(sConsulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            dtPrivateUser = new DataTable();
            dtPrivateUser.Columns.AddRange(new DataColumn[13] { new DataColumn("id"), new DataColumn("name"), new DataColumn("surname"), new DataColumn("birth_date"), new DataColumn("mail"), new DataColumn("user_name"), new DataColumn("password"), new DataColumn("entered"), new DataColumn("active"), new DataColumn("created"), new DataColumn("updated"), new DataColumn("chkSelect"), new DataColumn("phone") });

            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    DateTime? dtUpdated = dr.IsDBNull(10) ? new DateTime() : dr.GetDateTime(10);
                    dtPrivateUser.Rows.Add(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetDateTime(3).ToShortDateString(), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetInt32(7), dr.GetInt32(8), dr.GetDateTime(9), dtUpdated.ToString(), false, dr.GetInt32(11));
                }
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);

        }
        return dtPrivateUser;
    }

    protected List<Int32> controlSelectedPrivateUser(Int32 _idSC)
    {

        if (Session["SelectedPrivateUserID"] != null)
        {
            List<Int32> lst = (List<Int32>)Session["SelectedPrivateUserID"];
            if (lst.Count() != 0)
            {
                if (!lst.Contains(_idSC))
                {
                    lst.Add(_idSC);
                    Session["SelectedPrivateUserID"] = lst;
                }
            }
            else
            {
                //Error?¿?
            }
        }
        else
        {
            List<Int32> lstSelectedPrivateUsersbyID = new List<Int32>();
            lstSelectedPrivateUsersbyID.Add(_idSC);
            Session["SelectedPrivateUserID"] = lstSelectedPrivateUsersbyID;
        }

        return (List<Int32>)Session["SelectedPrivateUserID"];

    }

    protected void ExportExcel()
    {

    //**************************************************************************************************
     try
        {
      StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page pagina = new Page();
        System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();

        GridView gridToExport = new GridView();

        DataTable tableToExport = dtPrivateUser;
        tableToExport.Columns.RemoveAt(11);

        gridToExport.DataSource = dtPrivateUser;
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

        Response.AddHeader("Content-Disposition", "attachment;filename=UserAlumnoList.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();

        DataView dv = dtPrivateUser.DefaultView;

        }
     catch (Exception ex)
     {
         //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
         Session["error"] = ex;
     }
    }
    
    #endregion

    #region [ WEB METHODS ]

    [System.Web.Services.WebMethod]
    public static int Eliminar()
    {
        if (HttpContext.Current.Session["SelectedPrivateUserID"] != null && ((List<int>)HttpContext.Current.Session["SelectedPrivateUserID"]).Count > 0)
        {
            if (((List<int>)HttpContext.Current.Session["SelectedPrivateUserID"]).Count > 1)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        else { return 0; }
    }

    [System.Web.Services.WebMethod]
    public static int EnviarSMS()
    {
        if (HttpContext.Current.Session["SelectedPrivateUserID"] != null && ((List<int>)HttpContext.Current.Session["SelectedPrivateUserID"]).Count > 0)
        {
            if (((List<int>)HttpContext.Current.Session["SelectedPrivateUserID"]).Count > 1)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        else { return 0; }
    }

    [System.Web.Services.WebMethod]
    public static string Ver(string name)
    {
        // string var =  "Hello " + name + Environment.NewLine + "The Current Time is: "
        // + DateTime.Now.ToString();

        return HttpContext.Current.Session["SelectedPrivateUserID"].ToString();

    }

    #endregion

    #region [ EVENTS BUTTONS ]

    protected void btnEnviarSMS_Click(object sender, EventArgs e)
    {
        //ejecucion del envio del sms

        string phoneNumber = ((List<string>)Session["lstMensajePopUp_Destinatarios"])[0].Trim();
        string mensaje = ((List<string>)Session["lstMensajePopUp_Textos"])[0];

        string url = WebConfigurationManager.AppSettings["SendSMS_URL_JSP"] + "?" + "id=" + WebConfigurationManager.AppSettings["SendSMS_param_id"] + "&phoneNumber=" + phoneNumber + "&psw=" + WebConfigurationManager.AppSettings["SendSMS_param_psw"] + "&textSms=" + mensaje + "&remite=" + WebConfigurationManager.AppSettings["SendSMS_param_remitente"];

        // Create a request for the URL. 
        WebRequest request = WebRequest.Create(url);

        // If required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials;

        // Get the response.
        WebResponse response = request.GetResponse();

        if (((HttpWebResponse)response).StatusDescription == "OK")
        {
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            divResultadoEnvioSMS.InnerHtml = responseFromServer + "<br /> " + mensaje + "<br /> " + phoneNumber;

            // Clean up the streams and the response.
            reader.Close();
            response.Close();
        }
        else if (((HttpWebResponse)response).StatusDescription == "KO")
        {

            //1. ERROR EN TEXTO
            //   Ejemplo 'KO Error en texto: Campo vacio o contiene mas de 160 caracteres 91 0'
            //
            //
        }
        
        Session["lstMensajePopUp_Destinatarios"] = null;
        Session["lstMensajePopUp_Textos"] = null;
    }

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
    }
 
    protected void btnExport_Click(object sender, System.EventArgs e)
    {
      ExportExcel();

    }
     
    protected void btnVer_onclick(object sender, System.EventArgs e)
    {
        //  ((Int32)Session["SelectedPrivateUserID"])

        Int32 n = ((Int32)Session["SelectedPrivateUserID"]);
        //Response.Redirect(Constants.PAGE_TITLE_EditUserAlumno + Constants.ASP_PAGE_EXTENSION + "?M=V");
    }

    protected void btnEditar_onclick(object sender, System.EventArgs e)
    {
        //  ((Int32)Session["SelectedPrivateUserID"])
        Int32 n = ((Int32)Session["SelectedPrivateUserID"]);
        //Response.Redirect(Constants.PAGE_TITLE_EditUserAlumno + Constants.ASP_PAGE_EXTENSION + "?M=E");
    }

    protected void btnCrear_onclick(object sender, System.EventArgs e)
    {
        //  ((Int32)Session["SelectedPrivateUserID"])
        Int32 n = ((Int32)Session["SelectedPrivateUserID"]);
        //Response.Redirect(Constants.PAGE_TITLE_EditUserAlumno + Constants.ASP_PAGE_EXTENSION + "?M=N");


    }

    #endregion

    #region [ CHECK-BOX EVENTS ]

    protected void chkSelAll_Checked(object sender, System.EventArgs e)
    {
        //Dim rowSelectedRow As Integer = TryCast(TryCast(sender, CheckBox).Parent.Parent, GridViewRow).RowIndex

        System.Drawing.Color color;
        Boolean check;

        if (((CheckBox)sender).Checked)
        {
            check = true;
            color = System.Drawing.ColorTranslator.FromHtml("lemonchiffon");
            Session["SelectedPrivateUser"] = dtPrivateUser.Rows.Count;

            Int32 SelectedRow = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;

            // Session["SelectedPrivateUserID"] = SelectedRow;

            //btnEditar.Attributes.Add("class", "action");
            //btnVer.Attributes.Add("class", "action");
            //btnEliminar.Attributes.Add("class", "action red");
        }
        else
        {
            check = false;
            color = System.Drawing.Color.White;
           
            //btnEditar.Attributes.Add("class", "action");
            //btnVer.Attributes.Add("class", "action");
            //btnEliminar.Attributes.Add("class", "action");

        }

        Session["Checkall_selected"] = check;

        foreach (GridViewRow row in gvPrivateUser.Rows)
        {
            CheckBox cb = (CheckBox)(row.FindControl("chkSel"));         
            cb.Checked = check;
            row.BackColor = color;

            Int32 idselected = Convert.ToInt32(gvPrivateUser.DataKeys[row.RowIndex].Value);
            if (check)
            {
                controlSelectedPrivateUser(idselected);
            }
            else
            {
                controlSelectedPrivateUser(idselected);
                //lo elimino aki fuera, pk no me va bien meter dentro el remove.
                ((List<Int32>)Session["SelectedPrivateUserID"]).Remove(idselected);
            }
            
        }

    }

    protected void chkSel_Checked(object sender, System.EventArgs e)
    {

        Int32 rowSelectedRow = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;
        Int32 idselected = Convert.ToInt32(gvPrivateUser.DataKeys[rowSelectedRow].Value);
        List<Int32> lst = controlSelectedPrivateUser(Convert.ToInt32(gvPrivateUser.DataKeys[rowSelectedRow].Value));
        //Session["SelectedPrivateUserID"] = gvCenter.DataKeys[rowSelectedRow].Value.ToString();

        if (((CheckBox)sender).Checked)
        {
            gvPrivateUser.Rows[rowSelectedRow].BackColor = System.Drawing.ColorTranslator.FromHtml("lemonchiffon");
            //btnEliminar.Attributes.Add("class", "action red");
            Session["SelectedPrivateUser"] = (Int32)Session["SelectedPrivateUser"] + 1;
            Int32 SelectedRow = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;

            if (lst.Contains(idselected))
            {
                //btnEditar.Attributes.Add("class", "action");
                //btnVer.Attributes.Add("class", "action");
            }
            else
            {
                //btnEditar.Attributes.Add("class", "action green");
                //btnVer.Attributes.Add("class", "action blue");
            }

            dtPrivateUser.Rows[rowSelectedRow]["chkSelect"] = true;
        }
        else
        {
            gvPrivateUser.Rows[rowSelectedRow].BackColor = System.Drawing.Color.White;

            Session["SelectedPrivateUser"] = (Int32)Session["SelectedPrivateUser"] - 1;

            if (lst.Contains(idselected))
            {
                //btnEditar.Attributes.Add("class", "action");
                //btnVer.Attributes.Add("class", "action");
            }
            else
            {
                //btnEditar.Attributes.Add("class", "action green");
                //btnVer.Attributes.Add("class", "action blue");
            }
            
            lst.Remove(idselected);
            Session["SelectedPrivateUserID"] = lst;
            dtPrivateUser.Rows[rowSelectedRow]["chkSelect"] = false;
        }

        List<Int32> newlst = (List<Int32>)Session["SelectedPrivateUserID"];

        if (newlst.Count() == 0)
        {
            //btnEditar.Attributes.Add("class", "action");
            //btnVer.Attributes.Add("class", "action");
            //btnEliminar.Attributes.Add("class", "action");
        }
        else
        {
            //btnEliminar.Attributes.Add("class", "action red");
        }
    
    }
 
    #endregion

    #region [ GRIDVIEW EVENTS ]

    protected void gvPrivateUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if ((bool)Session["Checkall_selected"])
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("lemonchiffon");
                ((CheckBox)(e.Row.FindControl("chkSel"))).Checked = true;
            }
        }
        else
        { 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Int32 idselected = Convert.ToInt32(gvPrivateUser.DataKeys[e.Row.RowIndex].Value);
            
                //((CheckBox)(e.Row.FindControl("chkSel"))).Checked = getCheckByRowIndex(idselected);

                //Overlay selected row
                if (getCheckByRowIndex(idselected))
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("lemonchiffon");
                    ((CheckBox)(e.Row.FindControl("chkSel"))).Checked = true;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                    ((CheckBox)(e.Row.FindControl("chkSel"))).Checked = false;

                }


                //Active
                if (((HiddenField)(e.Row.FindControl("hdnActive"))).Value.Contains("1"))
                {
                    ((RadioButton)(e.Row.FindControl("rbtnActive"))).Checked = true;
                }
                else
                {
                    ((RadioButton)(e.Row.FindControl("rbtnActive"))).Checked = false;
                }

                //Entered 
                if (((HiddenField)(e.Row.FindControl("hdnEntered"))).Value.Contains("1"))
                {
                    ((RadioButton)(e.Row.FindControl("rbtnEntered"))).Checked = true;
                }
                else
                {
                    ((RadioButton)(e.Row.FindControl("rbtnEntered"))).Checked = false;
                }
            }
        }
    }

    protected void gvPrivateUser_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortDir = string.Empty;
        if (dir == SortDirection.Ascending)
        {
            dir = SortDirection.Descending;
            SortDir = "Desc";
        }
        else
        {
            dir = SortDirection.Ascending;
            SortDir = "Asc";
        }

        //DataTable dt = CargarGridView();
        DataView sortedView = new DataView(dtPrivateUser);
        sortedView.Sort = e.SortExpression + " " + SortDir;

        gvPrivateUser.DataSource = sortedView;
        gvPrivateUser.DataBind();

        dtPrivateUser = sortedView.Table;

    }

    protected void gvPrivateUser_Paging(object sender, GridViewPageEventArgs e)
    {
        gvPrivateUser.PageIndex = e.NewPageIndex;
        gvPrivateUser.DataBind();
    }

    #endregion

}
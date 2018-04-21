using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
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

public partial class ImageUploadExample : BasePage
{
    #region [ PROPERTIES ]

    public string NoImageForFeatured
    {
        get
        {
            return Constants.NoImageParaPreguntaTestOnline as string;
        }
    }

    public string mode
    {
        get
        {
            return Session["mode"] as string;
        }
        set
        {
            Session["mode"] = (string)value;
        }

    }

    public string Id
    {
        get
        {
            return Session["Id"] as string;
        }
        set
        {
            Session["Id"] = (string)value;
        }

    }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["M"] != null)
                {
                    mode = Request.QueryString["M"].ToString();
                }

                if (Request.QueryString["Id"] != null)
                {
                    Id = Request.QueryString["Id"].ToString();
                }
            
                ApplyLayout();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
          //  Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            if (!this.IsPostBack)
            {
            
            }
            else
            {

            } 

        }
        catch (Exception ex)
        {
            Session["error"] = ex;
           // Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
        }
    }

    protected Int32 GetLastFeaturedId()
    {
        try
        {
            string cadenaConexion = "Database=qsg265;Data Source=localhosts;User Id=dbUser;Password=123";
            string Consulta = "SELECT max(Id)FROM FEATURED";
            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            Int32 maxId = 0;
            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        maxId = dr.GetInt32(0);
                    }
                }
            }
            cnn.Close();

            return maxId;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
           // Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
            return 0;
        }
     }

    protected void FillFeatured()
    {
        try
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

           //string languahe_code = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString();
            string Consulta = "SELECT * FROM FEATURED  WHERE Id = " + Id;
           
           MySqlConnection cnn = new MySqlConnection(cadenaConexion);
           MySqlCommand mc = new MySqlCommand(Consulta, cnn);

           cnn.Open();
           MySqlDataReader dr = mc.ExecuteReader();

           //dtContact = new DataTable();
           //dtContact.Columns.AddRange(new DataColumn[6] { new DataColumn("ID"), new DataColumn("NAME"), new DataColumn("EMAIL"), new DataColumn("PHONE"), new DataColumn("BODY"), new DataColumn("chkSelect") });

            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    //Price field
                    if (!dr.IsDBNull(1))
                    {
                        featured_price.Text = dr.GetDecimal(1).ToString();
                    }

                    //Title y Text fields
                    if (!dr.IsDBNull(6) && dr.GetString(6).ToString() == Constants.languageCode_ESPAÑOL)
                    {
                        if (!dr.IsDBNull(10))
                        {
                            txtTituloES.Text = dr.GetString(10).ToString();
                        }
                        
                        if (!dr.IsDBNull(7))
                        {
                            txtTextoES.Text = dr.GetString(7).ToString();
                        }
                    }
                    else if (!dr.IsDBNull(6) && dr.GetString(6).ToString() == Constants.languageCode_CATALAN)
                    {
                        if (!dr.IsDBNull(10))
                        {
                            txtTituloCA.Text = dr.GetString(10).ToString();
                        }

                        if (!dr.IsDBNull(7))
                        {
                            txtTextoCA.Text = dr.GetString(7).ToString();
                        }
                    }
                    else if (!dr.IsDBNull(6) && dr.GetString(6).ToString() == Constants.languageCode_INGLES)
                    {
                        if (!dr.IsDBNull(10))
                        {
                            txtTituloEN.Text = dr.GetString(10).ToString();
                        }

                        if (!dr.IsDBNull(7))
                        {
                            txtTextoEN.Text = dr.GetString(7).ToString();
                        }
                    }

                    //Link field
                    if (!dr.IsDBNull(2))
                    {
                        featured_link.Text = dr.GetString(2);
                    }

                    //Fecfha Ini field
                    if (!dr.IsDBNull(3))
                    {
                        txtbox.Text = dr.GetDateTime(3).ToString("dd/MM/yyyy HH:mm:ss");
                    }

                    //Fecfha Fin field
                    if (!dr.IsDBNull(4))
                    {
                        txtbox_fechaFin.Text = dr.GetDateTime(4).ToString("dd/MM/yyyy HH:mm:ss");
                    }

                    //Active field
                    if (!dr.IsDBNull(12))
                    {
                        featured_active.Checked = dr.GetBoolean(12);
                    }

                    //Imnage Url field
                    if (!dr.IsDBNull(13))
                    {
                        if (dr.GetString(13).Trim().ToString() != String.Empty)
                        {
                            FeatureImage.ImageUrl = dr.GetString(13);
                            FeatureImageMiniatura.ImageUrl = dr.GetString(13);
                        }   
                        else
                        {
                            FeatureImage.ImageUrl = NoImageForFeatured;
                            FeatureImageMiniatura.ImageUrl = NoImageForFeatured;
                        }
                    }
                }
            }
            cnn.Close();
         }
        catch (Exception ex)
        {
            Session["error"] = ex;
           // Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
        }
    }

    protected void UploadButton_Click(Object sender, EventArgs e)
    {
        try
        {
            if (ValidateImage(fileUploadcontrol))
            {
                string path = Server.MapPath(WebConfigurationManager.AppSettings["FeatureImagePath"]);

                // Display the uploaded file's details
                txtFileDetails.Text = String.Format("Uploaded file: {0}" + "File size (in bytes): {1:N0}" + "Content-type: {2}", fileUploadcontrol.FileName + "\n", fileUploadcontrol.FileBytes.Length + "\n", fileUploadcontrol.PostedFile.ContentType);

                //Save the file
                //string friendlyName = "Destacado_" + DateTime.Now.ToShortDateString().Replace("/", "-") + fileUploadcontrol.FileName.Substring(fileUploadcontrol.FileName.Length-4, 4);

                string filePath = path + fileUploadcontrol.FileName;
                 fileUploadcontrol.SaveAs(filePath);
                //System.Drawing.Image.FromFile(fileUploadcontrol.FileName).Save(Server.MapPath("~/Files2/" & fileUploadcontrol.FileName))

                UpdateFeaturedImagePath(WebConfigurationManager.AppSettings["FeatureImagePath"] + fileUploadcontrol.FileName);
            }
            else
            {

            }

        }
        catch( Exception ex)
        {
            txtFileDetails.Text = "File could not be uploaded.";
            Session["error"] = ex;
          //  Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
        }
    }

    protected bool ValidateImage(FileUpload fileUpload)
    {
        bool validationResult = false;
        if (fileUploadcontrol.HasFile == false)
        {
            // No file uploaded!
            txtFileDetails.Text = "Please first select a file to upload...";
            return validationResult;
        }
        else
        {
            string fileExtension;
            fileExtension = System.IO.Path.GetExtension(fileUploadcontrol.FileName).ToLower();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            for (int i = 0; i <= allowedExtensions.Length - 1; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    validationResult = true;
                }
            }

            if (!validationResult)
            {
                txtFileDetails.Text = "Cannot accept files of this type.";
            }

            int fileSize = fileUpload.PostedFile.ContentLength;
            int maxSizeForFeatureImage = int.Parse(WebConfigurationManager.AppSettings["FeatureImageMaxSize"]);
            int maxSizeForFeatureImageInBytes = ((maxSizeForFeatureImage * 1024) *1024);

            // Allow only files less than 2,100,000 bytes (approximately 2 MB) to be uploaded.
            if (fileSize > maxSizeForFeatureImageInBytes)
            {
                txtFileDetails.Text = "Filesize of image is too large. Maximum file size permitted is " + maxSizeForFeatureImage + "MB";
                validationResult = false;
            }

            if (validationResult)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
     }

    protected void EmptyFields()
    {
        featured_price.Text = String.Empty;
        featured_price.Text = "00,00";

        txtTituloES.Text = String.Empty;
        txtTituloCA.Text = String.Empty;
        txtTituloEN.Text = String.Empty;

        txtTextoES.Text = String.Empty;
        txtTextoCA.Text = String.Empty;
        txtTextoEN.Text = String.Empty;

        featured_link.Text = String.Empty;
        txtbox.Text = String.Empty;

        txtbox_fechaFin.Text = String.Empty;
    }
    
    protected void ApplyLayout()
    {
        try
        {
            switch (mode)
            {
                case "N":
                    btnGuardar.Visible = true;
                    btnVolver.Visible = true;

                    //featured_title.Enabled = true;

                    txtTituloES.Enabled = true;
                    txtTituloCA.Enabled = true;
                    txtTituloEN.Enabled = true;

                    txtTextoES.Enabled = true;
                    txtTextoCA.Enabled = true;
                    txtTextoEN.Enabled = true;

                    //featured_text.Enabled = true;
                    featured_price.Enabled = true;

                    timepicker_noPeriodLabels.Disabled = false;

                    featured_link.Enabled = true;
                    
                    btnSave.Disabled = false;

                    //txtbox.Enabled = true;
                    //txtbox_fechaFin.Enabled = true;
                    featured_active.Enabled = true;

                    fileUploadcontrol.Enabled = true;
                    fileUploadbutton.Enabled = true;
                    txtFileDetails.Enabled = true;

                    btnCalendar.Enabled = true;
                    btnCalendar_fechaFin.Enabled = true;

                    EmptyFields();
                
                break;

                case "E":
                    btnGuardar.Visible = true;
                    btnVolver.Visible = true;

                    //featured_title.Enabled = true;
                    txtTituloES.Enabled = true;
                    txtTituloCA.Enabled = true;
                    txtTituloEN.Enabled = true;

                    txtTextoES.Enabled = true;
                    txtTextoCA.Enabled = true;
                    txtTextoEN.Enabled = true;

                    timepicker_noPeriodLabels.Disabled = false;
                    //featured_text.Enabled = true;

                    btnSave.Disabled = false;

                    featured_price.Enabled = true;
                    featured_link.Enabled = true;
                    //txtbox.Enabled = true;
                    //txtbox_fechaFin.Enabled = true;
                    featured_active.Enabled = true;

                    fileUploadcontrol.Enabled = true;
                    fileUploadbutton.Enabled = true;
                    txtFileDetails.Enabled = true;

                    btnCalendar.Enabled = true;
                    btnCalendar_fechaFin.Enabled = true;

                    if(Id != string.Empty)
                    {
                        FillFeatured();
                    }

                break;

                case "V":
                    btnGuardar.Visible = false;
                    btnVolver.Visible = true;

                    //featured_title.Enabled = true;
                    txtTituloES.Enabled = false;
                    txtTituloCA.Enabled = false;
                    txtTituloEN.Enabled = false;

                    txtTextoES.Enabled = false;
                    txtTextoCA.Enabled = false;
                    txtTextoEN.Enabled = false;

                    //featured_text.Enabled = true;

                    timepicker_noPeriodLabels.Disabled = true;

                    btnSave.Disabled = true;

                    featured_price.Enabled = false;
                    featured_link.Enabled = false;
                    //txtbox.Enabled = false;
                    //txtbox_fechaFin.Enabled = false;
                    featured_active.Enabled = false;

                    fileUploadcontrol.Enabled = false;
                    fileUploadbutton.Enabled = false;
                    txtFileDetails.Enabled = false;

                    btnCalendar.Enabled = false;
                    btnCalendar_fechaFin.Enabled = false;

                    if (Id != null && Id != string.Empty)
                    {
                        FillFeatured();
                    }
                
                break;

                default:
                break;
            }
        }
        catch(Exception ex)
        {
            Session["error"] = ex;
          //  Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);

        }
    }
    
    protected void btnVolver_Click(object sender, EventArgs e)
    {
       // Response.Redirect(Constants.PAGE_TITLE_FeaturedList + Constants.ASP_PAGE_EXTENSION);
    }

    protected bool ValidateUserData()
    {
        bool validationResult = true;

        featured_price.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        txtTituloES.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        txtTextoES.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        featured_link.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        txtbox.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        txtbox_fechaFin.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");


        if(featured_price.Text.Trim() == String.Empty)
        {
            validationResult = false;
            featured_price.BorderColor = System.Drawing.Color.Red;
            featured_price.BorderWidth = new Unit(1);
        }

        if (txtTituloES.Text.Trim() == String.Empty)
        {
            validationResult = false;
            txtTituloES.BorderColor = System.Drawing.Color.Red;
            featured_price.BorderWidth = new Unit(1);
        }

        if (txtTextoES.Text.Trim() == String.Empty)
        {
            validationResult = false;
            txtTextoES.BorderColor = System.Drawing.Color.Red;
            featured_price.BorderWidth = new Unit(1);
        }

        if (featured_link.Text.Trim() == String.Empty)
        {
            validationResult = false;
            featured_link.BorderColor = System.Drawing.Color.Red;
            featured_price.BorderWidth = new Unit(1);
        }


        if (txtbox.Text.Trim() == String.Empty)
        {
            validationResult = false;
            txtbox.BorderColor = System.Drawing.Color.Red;
            featured_price.BorderWidth = new Unit(1);
        }

        if (txtbox_fechaFin.Text.Trim() == String.Empty)
        {
            validationResult = false;
            txtbox_fechaFin.BorderColor = System.Drawing.Color.Red;
            featured_price.BorderWidth = new Unit(1);
        }

        return validationResult;
    }

    protected bool UpdateFeaturedImagePath(string imagePath)
    {
        try
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

            string consulta = "UPDATE FEATURED SET image_url='" + imagePath + "' WHERE ID=" + Id ;

            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(consulta, cnn);
            cnn.Open();
            mc.ExecuteNonQuery();
            cnn.Close();

            return true;
        }
         catch(Exception ex)
        {
            Session["error"] = ex;
         //   Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
            return false;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if(ValidateUserData())
            {
                //Obtenemos datos del formulario
                string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

                string titulo_code = "FEATURED_TITLE_";

                //string texto = featured_text.Text;
                decimal price = decimal.Parse(featured_price.Text);
                string link = featured_link.Text;

                DateTime? fechaIni = Utils.GetDateTimeFromText(txtbox.Text, Constants.inputDateTimeFormat_ddmmaaaa, CultureInfo.CurrentCulture);
                DateTime? fechaFin = Utils.GetDateTimeFromText(txtbox_fechaFin.Text, Constants.inputDateTimeFormat_ddmmaaaa, CultureInfo.CurrentCulture);
        

                int active = 0;
                if(featured_active.Checked)
                {
                    active = 1;
                }

                string consulta = string.Empty;
                int _id = 0;
                string text_code = "FEATURED_TEXT_";
                
                string literalDescriptionES = string.Empty;
                string literalDescriptionCA = string.Empty;
                string literalDescriptionEN = string.Empty;

                //Ejecutamos acción de B.D. para la entidad ppal.
                //FEATURED
                switch (mode)
                {
                    //Nuevo
                    case "N":

                        _id = GetLastFeaturedId() + 1;
                        text_code = text_code + _id;
                        titulo_code = titulo_code + _id;
                        consulta = "INSERT INTO FEATURED(id, precio, título, texto, link, fecha_inicio, fecha_fin, active, image_url) VALUES (" + _id + "," + price.ToString().Replace(",", ".") + ",'" + titulo_code + "','" + titulo_code + "','" + link + "','" + fechaIni.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + fechaFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'," + active + "')";
                        
                        break;
                    //Editar
                    case "E":

                        _id = int.Parse(Id);
                        text_code = text_code + _id;
                        titulo_code = titulo_code + _id;
                        consulta = "UPDATE FEATURED SET precio=" + price.ToString().Replace(",", ".") + ", título='" + titulo_code + "', texto='" + titulo_code + "', link='" + link + "', fecha_inicio='" + fechaIni.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', fecha_fin='" + fechaFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', active=" + active + " WHERE ID=" + _id;
                        break;
                }

                MySqlConnection cnn = new MySqlConnection(cadenaConexion);
                MySqlCommand mc = new MySqlCommand(consulta, cnn);
                cnn.Open();
                mc.ExecuteNonQuery();
                cnn.Close();     

                //Guardamos los literales en los tres idiomas en la tabla [LITERALS]

                // FOR TEXT CODE
                //ESPAÑOL
                switch (mode)
                {
                    
                    //Nuevo Literal
                    case "N":

                        consulta = "INSERT INTO LITERALES(TEXT_CODE, DESCRIPTION, LANGUAGE_CODE) VALUES ('" + text_code + "','" + txtTituloES.Text + "','" + Constants.languageCode_ESPAÑOL + "')";
                        break;

                    //Editar Literal
                    case "E":

                        consulta = "UPDATE LITERALES SET DESCRIPTION='" + txtTituloES.Text + "' WHERE TEXT_CODE='" + text_code + "' AND LANGUAGE_CODE='" + Constants.languageCode_ESPAÑOL + "'";
                        break;
                }

                cnn = new MySqlConnection(cadenaConexion);
                mc = new MySqlCommand(consulta, cnn);
                cnn.Open();
                mc.ExecuteNonQuery();
                cnn.Close();

                //CATALAN
                switch (mode)
                {

                    //Nuevo Literal
                    case "N":

                        consulta = "INSERT INTO LITERALES(TEXT_CODE, DESCRIPTION, LANGUAGE_CODE) VALUES ('" + text_code + "','" + txtTituloCA.Text + "','" + Constants.languageCode_CATALAN + "')";
                        break;

                    //Editar Literal
                    case "E":

                        consulta = "UPDATE LITERALES SET DESCRIPTION='" + txtTituloCA.Text + "' WHERE TEXT_CODE='" + text_code + "' AND LANGUAGE_CODE='" + Constants.languageCode_CATALAN + "'";
                        break;
                }

                cnn = new MySqlConnection(cadenaConexion);
                mc = new MySqlCommand(consulta, cnn);
                cnn.Open();
                mc.ExecuteNonQuery();
                cnn.Close();

                //INGLÉS
                switch (mode)
                {

                    //Nuevo Literal
                    case "N":

                        consulta = "INSERT INTO LITERALES(TEXT_CODE, DESCRIPTION, LANGUAGE_CODE) VALUES ('" + text_code + "','" + txtTituloEN.Text + "','" + Constants.languageCode_INGLES + "')";
                        break;

                    //Editar Literal
                    case "E":

                        consulta = "UPDATE LITERALES SET DESCRIPTION='" + txtTituloEN.Text + "' WHERE TEXT_CODE='" + text_code + "' AND LANGUAGE_CODE='" + Constants.languageCode_INGLES + "'";
                        break;
                }

                cnn = new MySqlConnection(cadenaConexion);
                mc = new MySqlCommand(consulta, cnn);
                cnn.Open();
                mc.ExecuteNonQuery();
                cnn.Close();


                // FOR TITLE CODE
                //ESPAÑOL
                switch (mode)
                {

                    //Nuevo Literal
                    case "N":

                        consulta = "INSERT INTO LITERALES(TEXT_CODE, DESCRIPTION, LANGUAGE_CODE) VALUES ('" + titulo_code + "','" + txtTituloES.Text + "','" + Constants.languageCode_ESPAÑOL + "')";
                        break;

                    //Editar Literal
                    case "E":

                        consulta = "UPDATE LITERALES SET DESCRIPTION='" + txtTituloES.Text + "' WHERE TEXT_CODE='" + titulo_code + "' AND LANGUAGE_CODE='" + Constants.languageCode_ESPAÑOL + "'";
                        break;
                }

                cnn = new MySqlConnection(cadenaConexion);
                mc = new MySqlCommand(consulta, cnn);
                cnn.Open();
                mc.ExecuteNonQuery();
                cnn.Close();

                //CATALAN
                switch (mode)
                {

                    //Nuevo Literal
                    case "N":

                        consulta = "INSERT INTO LITERALES(TEXT_CODE, DESCRIPTION, LANGUAGE_CODE) VALUES ('" + titulo_code + "','" + txtTituloCA.Text + "','" + Constants.languageCode_CATALAN + "')";
                        break;

                    //Editar Literal
                    case "E":

                        consulta = "UPDATE LITERALES SET DESCRIPTION='" + txtTituloCA.Text + "' WHERE TEXT_CODE='" + titulo_code + "' AND LANGUAGE_CODE='" + Constants.languageCode_CATALAN + "'";
                        break;
                }

                cnn = new MySqlConnection(cadenaConexion);
                mc = new MySqlCommand(consulta, cnn);
                cnn.Open();
                mc.ExecuteNonQuery();
                cnn.Close();

                //INGLÉS
                switch (mode)
                {

                    //Nuevo Literal
                    case "N":

                        consulta = "INSERT INTO LITERALES(TEXT_CODE, DESCRIPTION, LANGUAGE_CODE) VALUES ('" + titulo_code + "','" + txtTituloEN.Text + "','" + Constants.languageCode_INGLES + "')";
                        break;

                    //Editar Literal
                    case "E":

                        consulta = "UPDATE LITERALES SET DESCRIPTION='" + txtTituloEN.Text + "' WHERE TEXT_CODE='" + titulo_code + "' AND LANGUAGE_CODE='" + Constants.languageCode_INGLES + "'";
                        break;
                }

                cnn = new MySqlConnection(cadenaConexion);
                mc = new MySqlCommand(consulta, cnn);
                cnn.Open();
                mc.ExecuteNonQuery();
                cnn.Close();

             //   Response.Redirect(Constants.PAGE_TITLE_FeaturedList + Constants.ASP_PAGE_EXTENSION, false);

                //Si se ha guardado correctamente mostrar un confirm/popUp 
                //y al aceptar, volver al listado (en este caso al de featured[por implementar]
            }
            else
            {
                //Marcar en rojo(border del textbox) los campos invalidos
                //Mostrar mensaje debajo de cabecera con la info para el usuario
            }
        }
        catch(Exception ex)
        {
            Session["error"] = ex;
      //      Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
        }
    } 
}
using System;
using System.Web.UI;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net;

public partial class Contact : Page
{
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

    public string Centro
    {
        get
        {
            return Session["Centro"] as string;
        }
        set
        {
            Session["Centro"] = (string)value;
        }

    }

    public string IdCurso
    {
        get
        {
            return Session["IdCurso"] as string;
        }
        set
        {
            Session["IdCurso"] = (string)value;
        }

    }

    private DataTable GetConvocation()
    {
        try
        {
            string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123;sslMode=none;";

            //CAMBIAR ESTO, METERLO COMO PROPIEDAD EN LA PAGINA BASE(O MASTER PAGE) "GetLanguageCode()
            string language_code = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString();

            string Consulta = " SELECT convocation.id, convocation.product_id, literalProductName.DESCRIPTION AS product_name, convocation.center_id, literalcenterName.DESCRIPTION AS center_name, convocation.start, convocation.days, convocation.schedule, convocation.exam, convocation.created, convocation.updated, convocation.enabled, convocation.type  FROM convocation INNER JOIN CENTER ON CENTER.id = convocation.center_id LEFT JOIN LITERALES AS literalcenterName ON literalcenterName.TEXT_CODE = CENTER.name_code INNER JOIN PRODUCT ON PRODUCT.id = convocation.product_id LEFT JOIN LITERALES AS literalProductName ON literalProductName.TEXT_CODE = PRODUCT.name_code WHERE literalProductName.LANGUAGE_CODE= '" + language_code + "' AND literalcenterName.LANGUAGE_CODE = '" + language_code + "' and convocation.id =" + Id;

            DataTable dtConvocations;
            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            dtConvocations = new DataTable();
            dtConvocations.Columns.AddRange(new DataColumn[10] { new DataColumn("ID"), new DataColumn("PRODUCT_NAME"), new DataColumn("CENTER_NAME"), new DataColumn("START_DATE"), new DataColumn("DAYS"), new DataColumn("HORARIO"), new DataColumn("FECHA_EXAMEN"), new DataColumn("ACTIVE"), new DataColumn("TYPE"), new DataColumn("chkSelect") });

            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    dtConvocations.Rows.Add(dr.GetInt32(0), dr.GetString(2), dr.GetString(4), dr.GetDateTime(5).ToShortDateString(), dr.GetString(6), dr.GetString(7), dr.GetDateTime(8).ToShortDateString(), dr.GetString(11), dr.GetString(12), false);
                }
            }
            cnn.Close();
            return dtConvocations;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            throw ex;
        } 
    }
     
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    this.Id = Request.QueryString["Id"].ToString();
                    this.contact_body.Value = CargarMotivoContactoById();

                    CargarMapa();
                }
                else if (Request.QueryString["Centro"] != null)
                {
                    Id = string.Empty;

                    if(Request.QueryString["Centro"].ToString() == "1")
                    {
                        this.Centro = "Puerto";
                    }
                    else if (Request.QueryString["Centro"].ToString() == "2")
                    {
                        this.Centro = "Escuela";
                    }
                    else if (Request.QueryString["Centro"].ToString() == "3")
                    {
                        this.Centro = "Puerto Tarragona";
                    }
                    else
                    {
                        this.Centro = String.Empty;
                    }

                    //Mostramos el mapoa punteando el centro en función del param querystring Centro
                    CargarMapa();
                }
                else if (Request.QueryString["IdCurso"] != null)
                {
                    this.IdCurso = Request.QueryString["IdCurso"].ToString();
                    this.contact_body.Value = CargarMotivoContactoByProductId();
                }
                else { Id = string.Empty; Centro = string.Empty; }
            }
            else
            {
                 
            }
        }
        catch (Exception ex)
        {
          
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        GuardarInfo();
        EnviarCorreo(); 
        LimpiarFormnulario();
    }
     
    protected bool GuardarInfo()
    {
        string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123;sslMode=none;";
        string datetime = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " 00:00:00";
        string consulta = " INSERT INTO contact (name, subject,email,phone,body,TEXT_CODE,created,updated,isNew)VALUES ('" + contact_name.Value + "', NULL,'" + contact_email.Value + "','" + contact_phone.Value + "','" + contact_body.Value + "', NULL,'" + datetime + "', NULL, 0) ";
        
        MySqlConnection cnn = new MySqlConnection(cadenaConexion);
        MySqlCommand mc = new MySqlCommand(consulta, cnn);
        cnn.Open();
        mc.ExecuteNonQuery();
        cnn.Close();

        return true;
    }

    protected bool EnviarCorreo()
    {
        try
        {
            String s = "<div id='container' style='font-family: verdana; font-size: 12px; line-height: 1.5; padding: 52px; padding-top: 15px; min-width: 500px; -moz-box-shadow: 0 4px 16px rgba(0,0,0,.2); -webkit-box-shadow: 0 4px 16px rgba(0,0,0,.2); box-shadow: 0 4px 16px rgba(0,0,0,.2); -moz-box-shadow: 0 4px 16px rgba(0,0,0,.2); -webkit-box-shadow: 0 4px 16px rgba(0,0,0,.2); box-shadow: 0 4px 16px rgba(0,0,0,.2);'> ";
            s += " <table style='width: 100%;' id='tLogo'><tr><td style='float: right;'>";
            s += " <a target='_blank' href='http://www.escuelanauticasantalo.com'> ";
            s += " <img src='http://up2web.es/EscuelaNauticaSantalo/img/logos/Logo.png' width='115px' height='100px'></a></td></tr></table>";

            //s += " Hola " + WebConfigurationManager.AppSettings["Email_To_Name"] + ", <br /> <br /> Le informamos que ha recibido una nueva solicitud de contacto a través del sitio web EscuelaNauticaSantalo.com. A continuación le indicamos los datos que se han facilitado por parte del usuario:" + "<br /><br />";
            s += " Hola, <br /> <br /> Le informamos que ha recibido una nueva solicitud de contacto a través del sitio web EscuelaNauticaSantalo.com. A continuación le indicamos los datos que se han facilitado por parte del usuario:" + "<br /><br />";

            s += "<b>Nombre de contacto:</b>" + contact_name.Value + "<br />";
            s += "<b>Correo electrónico: </b>" + contact_email.Value + "<br />";
            s += "<b>Teléfono de contacto: </b>" + contact_phone.Value + "<br />";
            s += "<b>Comentario del usuario: </b>" + contact_body.Value + "<br />";
            
            s += "<br />" + "<br />";
            s += "Atentamente," + "<br />";
            s += "Escuela Nautica Santaló</div>";

            SmtpClient smtpCliente = new SmtpClient(WebConfigurationManager.AppSettings["Email_SMTP_Address"], int.Parse(WebConfigurationManager.AppSettings["Email_Port"]));

            //ELCorreo = new MailMessage();
            MailMessage mail = new System.Net.Mail.MailMessage(WebConfigurationManager.AppSettings["Email_From"], WebConfigurationManager.AppSettings["Email_To"], "Nuevo contacto recibido a través de escuelanauticasantalo.com", s);
            mail.IsBodyHtml = true;

            NetworkCredential basicCredential = new NetworkCredential(WebConfigurationManager.AppSettings["Email_Account_User"], WebConfigurationManager.AppSettings["Email_Account_Password"]);
            smtpCliente.UseDefaultCredentials = false;
            smtpCliente.Credentials = basicCredential;

            //System.Net.Mail.Attachment att = new System.Net.Mail.Attachment(WebConfigurationManager.AppSettings["Logo"]);
            //mail.Attachments.Add(att);

            smtpCliente.Send(mail);

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarMapa()
    {
        switch (Centro.Trim())
        {
            case "Escuela":
                iframeMapa.Attributes.Add("src", "MapaRutasEscuela.html");
                break;

            case "Puerto":
                iframeMapa.Attributes.Add("src", "MapaRutasPuerto.html");
                break;

            case "":
                break;
        }
    }

    private void LimpiarFormnulario()
    {
        contact_name.Value = contact_email.Value = contact_phone.Value = contact_body.Value = string.Empty;
    } 

    private string CargarMotivoContactoByProductId()
    {
        string nombreCurso = string.Empty;
        string asunto = string.Empty;

        switch (IdCurso)
        {
            case "1":
                nombreCurso = "Patrón de Navegación Básica";
                break;

                case "2":
                nombreCurso = "Patrón de Embarcaciones de Recreo";
                break;

                case "3":
                nombreCurso = "Patrón de Yate";
                break;

                case "4":
                nombreCurso = "Capitán de Yate";
                break;

                case "5":
                nombreCurso = "Licencia de Navegación";
                break;
        }


        //nombreCurso = GetProductNameByProductId();
         
        asunto = "Me gustaría informarme sobre el curso ";
        asunto += " de ";
        asunto += nombreCurso;
        asunto += ".";
            
        return asunto;
    }

    protected string GetProductNameByProductId()
    {
        try
        {
            string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123;sslMode=none;";
           string Consulta = "SELECT  PRODUCT.id, PRODUCT.name_code, PRODUCT.description_code, PRODUCT.price1,PRODUCT.price2, PRODUCT.price3, PRODUCT.path, PRODUCT.code, PRODUCT.created, PRODUCT.updated, PRODUCT.distance_code,  PRODUCT.textdescrip_code, PRODUCT.show_price, literalName.LANGUAGE_CODE AS LANGUAGE_CODE_FOR_NAME, IFNULL(literalName.DESCRIPTION, '') AS NAME, literalName.TEXT_CODE AS TEXT_CODE_FOR_NAME, literalDescription.LANGUAGE_CODE AS LANGUAGE_CODE_FOR_DESCRIPTION, IFNULL(literalDescription.DESCRIPTION, '') AS DESCRIPTION, literalDescription.TEXT_CODE AS TEXT_CODE_FOR_DESCRIPTION, literalDistance.LANGUAGE_CODE AS LANGUAGE_CODE_FOR_DISTANCE, IFNULL(literalDistance.DESCRIPTION, '') AS DISTANCE, 	literalDistance.TEXT_CODE AS TEXT_CODE_FOR_DISTANCE, literalText.LANGUAGE_CODE AS LANGUAGE_CODE_FOR_TEXT, IFNULL(literalText.DESCRIPTION, '') AS TEXT, 	literalText.TEXT_CODE AS TEXT_CODE_FOR_TEXT  FROM PRODUCT  LEFT JOIN LITERALES AS literalName ON literalName.TEXT_CODE = PRODUCT.name_code AND PRODUCT.Id=" + Id + " LEFT JOIN LITERALES AS literalDescription ON literalDescription.TEXT_CODE = PRODUCT.description_code AND PRODUCT.Id =" + Id + " AND literalDescription.LANGUAGE_CODE = literalName.LANGUAGE_CODE  LEFT JOIN LITERALES AS literalDistance ON literalDistance.TEXT_CODE = PRODUCT.distance_code AND PRODUCT.Id =" + Id + " AND literalDistance.LANGUAGE_CODE = literalDescription.LANGUAGE_CODE  LEFT JOIN LITERALES AS literalText ON literalText.TEXT_CODE = PRODUCT.textdescrip_code AND PRODUCT.Id =" + IdCurso + " AND literalText.LANGUAGE_CODE = literalDistance.LANGUAGE_CODE  WHERE PRODUCT.Id =" + IdCurso;

           string ExamName = string.Empty;

           MySqlConnection cnn = new MySqlConnection(cadenaConexion);
           MySqlCommand mc = new MySqlCommand(Consulta, cnn);

           cnn.Open();
           MySqlDataReader dr = mc.ExecuteReader();

           if (!dr.IsClosed)
           {
                while (dr.Read())
                {
                    //ES
                    if (!dr.IsDBNull(13) && dr.GetString(13).ToString() == Constants.languageCode_ESPAÑOL)
                    {
                        //Name
                        if (!dr.IsDBNull(14))
                        {
                            ExamName = dr.GetString(14).ToString();
                        }
                       
                    }//CA
                   /* else if (!dr.IsDBNull(13) && dr.GetString(13).ToString() == Constantes.languageCode_CATALAN)
                    {
                        //Name
                        if (!dr.IsDBNull(14))
                        {
                            ExamName = dr.GetString(14).ToString();
                        }
                       
                    }//EN
                    else if (!dr.IsDBNull(13) && dr.GetString(13).ToString() == Constantes.languageCode_INGLES)
                    {
                        //Name
                        if (!dr.IsDBNull(14))
                        {
                            ExamName = dr.GetString(14).ToString();
                        }
                    }*/
                }
            }
            cnn.Close();

            return ExamName;

         }
        catch (Exception ex)
        {
            //Session["error"] = ex;
            return string.Empty;
        }
    }

    private string CargarMotivoContactoById()
    {
        string tipoCurso = string.Empty;
        string fechaCurso = string.Empty;
        string nombreCurso = string.Empty;
        string centroCurso = string.Empty;

        string asunto = string.Empty;

        if (Id == "0")
        {
            asunto = "Me gustaría recibir información sobre las actividades de verano.";
        }
        else if (Id == "-1")
        {
            asunto = "Me gustaría recibir más información sobre la escuela y las actividades que desarrolla.";
        }
        else
        {
            DataTable dt = GetConvocation();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    tipoCurso = dr[8].ToString().ToLower();
                    fechaCurso = dr[3].ToString();
                    nombreCurso = dr[1].ToString();
                    centroCurso = dr[2].ToString();

                    //
                    this.Centro = centroCurso;

                    asunto = "Me gustaría informarme sobre el curso ";
                    asunto += tipoCurso;
                    asunto += " de ";
                    asunto += nombreCurso;
                    asunto += " que inicia el día ";
                    asunto += fechaCurso;
                    asunto += " en el centro ";
                    asunto += centroCurso + ".";
                }
            }
        }
        
        return asunto;
    }
}
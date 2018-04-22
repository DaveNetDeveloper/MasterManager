using System; 
using System.Web.UI; 
using MySql.Data.MySqlClient; 
using System.Net.Mail; 
using System.Net;
using System.Configuration;
using System.Web.Configuration;

public partial class LoginGestor : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //RegisterHyperLink.NavigateUrl = "Register";
        ///OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

        //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        //if (!String.IsNullOrEmpty(returnUrl))
        //{
            //RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
        //}


        Title = "Login";
    }
    
     protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        try
        {
            if (UserName.Text.Trim() == String.Empty)
            {
                UserName.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                UserName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
                SendMailResetPassword();

                //ScriptManager.RegisterStartupScript(this, typeof(Page), "ConfirmMessage", "show();", true);
                
                myModal.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                myModalBackground.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
        }
    }

    protected void SendMailResetPassword()
    {
        NewPassword newPassword = new NewPassword();
        string nuevaPassword = newPassword.GenerarPass(6, 10);

        if (UpdateUserPassword(nuevaPassword))
        {
            String messaage = String.Empty;

            messaage += "A continuación le facilitamos su nueva contraseña para acceder al <b>Área de gestión de contenido</b> de <b>[Escuela Nautica Santaló]</b>: <br /><br />";

            messaage += "[" + nuevaPassword + "]<br /><br />";

            messaage += "Atentamente,<br />";

            messaage += "El equipo de Up2Web";

            string asunto = "Area de gestión [Escuela Nautica Santaló] - Nueva Contraseña";

            SmtpClient smtpCliente = new SmtpClient(WebConfigurationManager.AppSettings["Email_SMTP_Address"], int.Parse(WebConfigurationManager.AppSettings["Email_Port"]));

            MailMessage correo = new MailMessage(WebConfigurationManager.AppSettings["Email_From"], UserName.Text, asunto, messaage)
            {
                IsBodyHtml = true
            };

            NetworkCredential basicCredential = new NetworkCredential(WebConfigurationManager.AppSettings["Email_Account_User"], WebConfigurationManager.AppSettings["Email_Account_Password"]);

            //smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;
            smtpCliente.Credentials = basicCredential;

            //Dim att As New System.Net.Mail.Attachment("C:\Users\David\Documents\Visual Studio 2010\Projects\MyWeb\Files\almohadas_dormir.jpg")
            //ELCorreo.Attachments.Add(att)

            smtpCliente.Send(correo);
        }
        else
        {

        }
    }
     
    public class NewPassword
    {
        char[] ValueAfanumeric = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '!', '#', '$', '%', '&', '?', '¿' };
        public string GenerarPass(int LongPassMin, int LongPassMax)
        {
            Random ram = new Random();
            int LogitudPass = ram.Next(LongPassMin, LongPassMax);
            string Password = String.Empty;

            for (int i = 0; i < LogitudPass; i++)
            {
                int rm = ram.Next(0, 2);

                if (rm == 0)
                {
                    Password += ram.Next(0, 10);
                }
                else
                {
                    Password += ValueAfanumeric[ram.Next(0, 59)];
                }
            }

            return Password;
        }
    }
   
    protected bool GetIdUSerByMail()
    {
        bool existUser = false;
        string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

        string Consulta = "SELECT ID FROM USUARIO_GESTOR WHERE LOGIN='" + UserName.Text + "'";
        MySqlConnection cnn = new MySqlConnection(cadenaConexion);

        MySqlCommand mc = new MySqlCommand(Consulta, cnn);
        cnn.Open();
        MySqlDataReader dr = mc.ExecuteReader();

        if (!dr.IsClosed)
        {
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    if (dr.GetInt32(0) > 0)
                    {
                        Session["IdUser"] = dr.GetInt32(0);
                        existUser = true;
                    }
                }
            }
        }

        cnn.Close();

        return existUser;

    }

    protected bool GetIdUSerByMailAndPassword()
    {
        bool existUser = false;
        string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

        string Consulta = "SELECT ID FROM USUARIO_GESTOR WHERE LOGIN='" + UserName.Text + "' AND PASSWORD='" + Password.Text + "'";
        MySqlConnection cnn = new MySqlConnection(cadenaConexion);

        MySqlCommand mc = new MySqlCommand(Consulta, cnn);
        cnn.Open();
        MySqlDataReader dr = mc.ExecuteReader();

        if (!dr.IsClosed)
        {
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    if (dr.GetInt32(0) > 0)
                    {
                        Session["IdUser"] = dr.GetInt32(0);

                        Session["LoginUser"] = UserName.Text;

                        existUser = true;
                    }
                }
            }
        }

        cnn.Close();

        return existUser;

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (GetIdUSerByMailAndPassword())
            {
                Session["IsLoginUser"] = UserName.Text;

                //¡¡¡ Guardar / Cargar Session con el ID del usuario !!!

                //Response.Redirect(Constants.PAGE_TITLE_Inicio + Constants.ASP_PAGE_EXTENSION, false);
            }
            else
            {
                txtLiteralMessage.Text = "El usuario o la contraseña introducidos no son correctos.";
                
                myModal.Style.Add(HtmlTextWriterStyle.Visibility, "hide");
                myModalBackground.Style.Add(HtmlTextWriterStyle.Display, "hidden");

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
        }
    }

    protected bool UpdateUserPassword(string newPassword)
    {
        try
        {
            if(GetIdUSerByMail())
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

                string Consulta = "UPDATE USUARIO_GESTOR SET Password ='" + newPassword + "' WHERE ID=" + Session["IdUser"].ToString();

                MySqlConnection cnn = new MySqlConnection(cadenaConexion);
                MySqlCommand mc = new MySqlCommand(Consulta, cnn);
                cnn.Open();
                mc.ExecuteNonQuery();
                cnn.Close();

                return true;

            }
            return false;

        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            return false;
        }
    }
}
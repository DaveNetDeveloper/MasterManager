using System;
using System.Web.UI;
using MySql.Data.MySqlClient;

public partial class LoginAlumno : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Session["LoginUser"] = string.Empty;
            Session["IdUser"] = string.Empty;
        }
    }
    
    protected bool GetIdUSerByMail()
    {
        bool existUser = false;
        string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123;sslMode=none;";

        string Consulta = "SELECT ID FROM USUARIOS WHERE LOGIN='" + UserName.Text + "'";
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
        string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123;sslMode=none;";

        string Consulta = "SELECT ID FROM USER_ALUMNO WHERE user_name='" + UserName.Text + "' AND password='" + Password.Text + "'";
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
                Session["LoginUser"] = UserName.Text;
                Response.Redirect("TestList.aspx", false);
            }
            else
            {
                txtLiteralMessage.Text = "El usuario o la contraseña introducidos no son correctos.";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
        }
    }
}
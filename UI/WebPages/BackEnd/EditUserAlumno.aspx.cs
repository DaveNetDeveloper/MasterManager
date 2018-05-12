using System;
using System.Web.UI.WebControls;
using System.Configuration; 
using System.Globalization;
using MySql.Data.MySqlClient;

public partial class EditUserAlumno : BasePage, IModelEdition
{
    #region [ Properties ]

    public string Mode
    {
        get
        {
            return Session["mode"] as string;
        }
        set
        {
            Session["mode"] = value;
        }

    } 
    public string PrimaryKey
    {
        get
        {
            return Session["PrimaryKey"] as string;
        }
        set
        {
            Session["PrimaryKey"] = value;
        }

    }

    private IModel Model {
        get
        {
            if (Session["Model"] == null)
            {
                var aux = Entity.GetByPrimaryKey(Int32.Parse(PrimaryKey));
                Session["Model"] = (ModelUsuarioAlumno)aux;
            }
            return (ModelUsuarioAlumno)Session["Model"];
        }
        set
        {
            Session["Model"] = value;
        }
    }
    private IModel UIModel { get; set; }
    private IEntity Entity
    {
        get
        {
            if (Session["Entity"] == null)
            {
                var aux = EntityManager.GetEntity(EntityManager.EntityType.UsuarioAlumno).GetNextPrimaryKey();
                Session["IEntity"] = aux;
            }
            return (IEntity)Session["Entity"];
        }
        set
        {
            Session["Entity"] = value;
        }
    }

    #endregion

    #region [ Page Events ]

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetPrimaryKey();
                GetMode();
                ApplyLayout();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //((MasterPage)(this.Master)).SetLOG("ERROR", "Loading Page", "EditCenter.aspx", "Center", "Page_Init()", ex.Message, DateTime.Now, 1);
            //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "Page_Init()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
        }
    } 
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            Title = "Edición de alumno";
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
           // this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "Page_Load()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
        }
    }

    #endregion

    #region [ Methods ]

    public void GetPrimaryKey()
    {
        if (Request.QueryString["Id"] != null)
        {
            PrimaryKey = Request.QueryString["Id"].ToString();
        }
        else { PrimaryKey = string.Empty; }
    }
    public void GetMode()
    {
        if (Request.QueryString["M"] != null)
        {
            Mode = Request.QueryString["M"].ToString();
        }
        else { Mode = string.Empty; }
    }
    public void ApplyLayout()
    {
        try
        {
            switch (Mode)
            {
                case "N":
                    btnGuardar.Visible = true;
                    btnVolver.Visible = true;

                    privateUserName.Enabled = true;
                    privateUserSurname.Enabled = true;
                    privateUserMail.Enabled = true;
                    privateUserPhone.Enabled = true;
                    privateUserUserName.Enabled = true;
                    privateUserPassword.Enabled = true;
                    
                    privateUserEntered.Enabled = false;
                    privateUserCreated.Enabled = false;

                    divDateUpdated.Visible = false;
                    privateUserUpdated.Enabled = false;

                    privateUserBirthDate.Enabled = true;
                    privateUserActive.Enabled = true;

                    ResetFields();

                    break;

                case "V":
                    btnGuardar.Visible = false;
                    btnVolver.Visible = true;

                    privateUserName.Enabled = false;
                    privateUserSurname.Enabled = false;
                    privateUserMail.Enabled = false;
                    privateUserPhone.Enabled = false;
                    privateUserUserName.Enabled = false;
                    privateUserPassword.Enabled = false;
                    privateUserEntered.Enabled = false;
                    privateUserCreated.Enabled = false;
                    privateUserBirthDate.Enabled = false;
                    privateUserActive.Enabled = false;
                    privateUserUpdated.Enabled = false;

                    if (PrimaryKey != null && PrimaryKey != string.Empty)
                    {
                        FillFromModel();
                    }

                    break;
                     
                case "E":
                    btnGuardar.Visible = true;
                    btnVolver.Visible = true;

                    privateUserName.Enabled = true;
                    privateUserSurname.Enabled = true;
                    privateUserMail.Enabled = true;
                    privateUserPhone.Enabled = true;
                    privateUserUserName.Enabled = true;
                    privateUserPassword.Enabled = true;
                    privateUserEntered.Enabled = false;
                    privateUserCreated.Enabled = false;
                    privateUserUpdated.Enabled = false;
                    privateUserBirthDate.Enabled = true;
                    privateUserActive.Enabled = true;

                    if (PrimaryKey != null && PrimaryKey != string.Empty)
                    {
                        FillFromModel();
                    }

                    break;
                     
                default:
                    break;
            } 
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            // this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "ApplyLayout()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
        }
    }
    public void ResetFields()
    {
        privateUserName.Text = String.Empty;
        privateUserSurname.Text = String.Empty;
        privateUserMail.Text = String.Empty;
        privateUserPhone.Text = String.Empty;
        privateUserUserName.Text = String.Empty;
        privateUserPassword.Text = String.Empty;
        privateUserEntered.Checked = false;
        privateUserCreated.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
        privateUserBirthDate.Text = String.Empty;
        privateUserActive.Checked = false;
    }
    public void FillFromModel()
    { 
        try
        {
            var userAlumnoModel = ((ModelUsuarioAlumno)Model);

            privateUserSurname.Text = userAlumnoModel.Surname;
            privateUserBirthDate.Text = userAlumnoModel.BirthDate.ToString("dd/MM/yyyy");
            privateUserMail.Text = userAlumnoModel.Mail;
            privateUserUserName.Text = userAlumnoModel.UserName;
            privateUserPassword.Text = userAlumnoModel.Password;
            privateUserEntered.Checked = userAlumnoModel.Entered;
            privateUserPhone.Text = userAlumnoModel.Phone;

            var updateDate = string.Empty;
            var createdDate = string.Empty;

            switch (Mode)
            {
                case "N":
                    updateDate = string.Empty;
                    createdDate = DateTime.Now.ToString("dd/MM/yyyy");
                    break;
                case "E":
                    updateDate = DateTime.Now.ToString("dd/MM/yyyy"); ;
                    createdDate = userAlumnoModel.Created.ToString("dd/MM/yyyy"); ;
                    break;
                case "V":
                    updateDate = userAlumnoModel.Updated.ToString("dd/MM/yyyy"); ;
                    createdDate = userAlumnoModel.Created.ToString("dd/MM/yyyy"); ;
                    break; 
            } 
            privateUserCreated.Text = createdDate;
            privateUserUpdated.Text = updateDate;  
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "FillCenter()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
        }
    } 
    public bool IsValidModel()
    {
        try
        {
            bool validationResult = true;

            privateUserName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
           // privateUserSurname.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserMail.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserBirthDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserPhone.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserUserName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            

            if (privateUserName.Text.Trim() == String.Empty)
            {
                validationResult = false;
                privateUserName.BorderColor = System.Drawing.Color.Red;
                privateUserName.BorderWidth = new Unit(1);
            }

            /*if (privateUserSurname.Text.Trim() == String.Empty)
            {
                validationResult = false;
                privateUserSurname.BorderColor = System.Drawing.Color.Red;
                privateUserSurname.BorderWidth = new Unit(1);
            }*/

            if (privateUserMail.Text.Trim() == String.Empty)
            {
                validationResult = false;
                privateUserMail.BorderColor = System.Drawing.Color.Red;
                privateUserMail.BorderWidth = new Unit(1);
            }
             
            if (privateUserBirthDate.Text.Trim() == String.Empty)
            {
                validationResult = false;
                privateUserBirthDate.BorderColor = System.Drawing.Color.Red;
                privateUserBirthDate.BorderWidth = new Unit(1);
            }
            
            if (privateUserPhone.Text.Trim() == String.Empty)
            {
                validationResult = false;
                privateUserPhone.BorderColor = System.Drawing.Color.Red;
                privateUserPhone.BorderWidth = new Unit(1);
            }
            
            if (privateUserUserName.Text.Trim() == String.Empty)
            {
                validationResult = false;
                privateUserUserName.BorderColor = System.Drawing.Color.Red;
                privateUserUserName.BorderWidth = new Unit(1);
            }
             
            if (privateUserPassword.Text.Trim() == String.Empty)
            {
                validationResult = false;
                privateUserPassword.BorderColor = System.Drawing.Color.Red;
                privateUserPassword.BorderWidth = new Unit(1);
            }

            return validationResult;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "FillCenter()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
            return false;
        }
    }
    public IModel GetModel()
    { 
        return new ModelUsuarioAlumno();
    }
    public IModel GetModelFromForm()
    {
        return new ModelUsuarioAlumno();
    }
    public bool SaveModel(IModel model)
    {
        // TODO
        // entityUserAlumno.SaveModel(model)

        // TODO
        // Llamar a metodos UserAlumno.Insert(model) y UserAlumno.Update(model)
        //Entity.Insert(model);
        //Entity.UpdateByPrimaryKey(model);

        try
        {
           string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;
           string consulta = string.Empty;
           int _id = 0;

           int active = privateUserActive.Checked ? 1 : 0;
           DateTime dt = HelperDataTypesConversion.GetDateTimeFromText(privateUserBirthDate.Text, Constants.inputDateTimeFormat_ddmmaaaa, CultureInfo.CurrentCulture);
           
           string cadenaDateTime = dt.ToString("d", CultureInfo.CurrentCulture);
 
               switch (Mode)
               {
                   //Nuevo
                   case "N":

                       _id = Entity.GetNextPrimaryKey();
                        consulta = "INSERT INTO USER_ALUMNO(id, NAME, surname, birth_date, mail, user_name, PASSWORD, entered, active, created, updated, phone) VALUES(" + _id + ",'" + privateUserName.Text + "','" + privateUserSurname.Text + "','" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + privateUserMail.Text + "','" + privateUserUserName.Text + "','" + privateUserPassword.Text + "', 0, " + active + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', null, " + privateUserPhone.Text + ")";

                       break;
                   //Editar
                   case "E":

                       _id = int.Parse(PrimaryKey);
                       consulta = "UPDATE USER_ALUMNO SET NAME='" + privateUserName.Text + "', surname='" + privateUserSurname.Text + "', birth_date='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', mail='" + privateUserMail.Text + "', user_name='" + privateUserUserName.Text + "', PASSWORD='" + privateUserPassword.Text + "', active=" + active + ", updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', phone=" + privateUserPhone.Text + " WHERE ID=" + _id;
                       break;
               }

               MySqlConnection cnn = new MySqlConnection(cadenaConexion);
               MySqlCommand mc = new MySqlCommand(consulta, cnn);
               cnn.Open();
               mc.ExecuteNonQuery();
               cnn.Close(); 








        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "FillCenter()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
        }
        //Response.Redirect(Constantes.PAGE_TITLE_UserAlumnoList + Constantes.ASP_PAGE_EXTENSION);

        return true;
    }

    #endregion

    #region [ Button Events ]

    public void GoBackClick(object sender, EventArgs e)
    {
        //Response.Redirect(Constantes.PAGE_TITLE_UserAlumnoList + Constantes.ASP_PAGE_EXTENSION);
    }
    public void SaveModelClick(object sender, EventArgs e)
    {
        if(IsValidModel())
        { 
            UIModel = GetModelFromForm();
            SaveModel(UIModel);
        }
    }

    #endregion
}
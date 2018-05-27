using System; 
using System.Configuration; 
using System.Globalization;
using MySql.Data.MySqlClient; 

public partial class EditUserAlumno : BasePage, IModelEdition
{
    #region [ Properties ]

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

    private IModel Model {
        get
        {
            if (Session["Model"] == null)
            { 
                Session["Model"] = Entity.GetByPrimaryKey(Int32.Parse(PrimaryKey));
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
                Session["Entity"] = EntityManager.GetEntity(EntityManager.EntityType.UsuarioAlumno);
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
                Title = "Edición de alumno";
                GetPageParameters();
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

    #endregion

    #region [ Methods ]

    public void GetPageParameters()
    {
        GetPrimaryKey();
        GetViewMode();
    }

    private void GetPrimaryKey()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"])) PrimaryKey = Request.QueryString["Id"].ToString();
    }
    private void GetViewMode()
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
            } 
        } 
    }
    public void ApplyLayout()
    {
        try
        {
            var enabled = false;
            switch (Mode)
            {
                case ViewMode.Create:
                    enabled = true; 
                    ResetFields();
                    break;

                case ViewMode.View: 
                    enabled = false; 
                    if (!string.IsNullOrEmpty(PrimaryKey)) FillFromModel(); 
                    break;

                case ViewMode.Edit: 
                    enabled = true;
                    if (!string.IsNullOrEmpty(PrimaryKey)) FillFromModel();
                    break;
            }

            btnGuardar.Visible = enabled;
            btnVolver.Visible = true;

            privateUserName.Enabled = enabled;
            privateUserSurname.Enabled = enabled;
            privateUserMail.Enabled = enabled;
            privateUserPhone.Enabled = enabled;
            privateUserUserName.Enabled = enabled;
            privateUserPassword.Enabled = enabled;
            privateUserBirthDate.Enabled = enabled;
            if(!enabled) privateUserEntered.Attributes["disabled"] = "disabled";
            privateUserCreated.Enabled = false;
            privateUserUpdated.Enabled = false;
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
            privateUserName.Text = userAlumnoModel.Name;
            privateUserSurname.Text = userAlumnoModel.Surname;
            privateUserBirthDate.Text = userAlumnoModel.BirthDate.ToString("dd/MM/yyyy");
            privateUserMail.Text = userAlumnoModel.Mail;
            privateUserUserName.Text = userAlumnoModel.UserName;
            privateUserPassword.Text = userAlumnoModel.Password;
            privateUserEntered.Checked = userAlumnoModel.Entered;
            privateUserPhone.Text = userAlumnoModel.Phone.ToString();

            var updateDate = string.Empty;
            var createdDate = string.Empty; 
            switch (Mode)
            {
                case ViewMode.Create:
                    updateDate = string.Empty;
                    createdDate = DateTime.Now.ToString("dd/MM/yyyy");
                    break;
                case ViewMode.Edit:
                    updateDate = DateTime.Now.ToString("dd/MM/yyyy"); ;
                    createdDate = userAlumnoModel.Created.ToString("dd/MM/yyyy"); ;
                    break;
                case ViewMode.View:
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
            privateUserName.BorderColor = HtmlColor;
            privateUserSurname.BorderColor = HtmlColor;
            privateUserMail.BorderColor = HtmlColor;
            privateUserBirthDate.BorderColor = HtmlColor;
            privateUserPhone.BorderColor = HtmlColor;
            privateUserUserName.BorderColor = HtmlColor;
            privateUserPassword.BorderColor = HtmlColor;
             
            if (string.IsNullOrEmpty(privateUserName.Text.Trim()))
                SetControlAsInvalid(privateUserName, ref validationResult);

            if (string.IsNullOrEmpty(privateUserSurname.Text.Trim()))
                SetControlAsInvalid(privateUserSurname, ref validationResult); 

            if (string.IsNullOrEmpty(privateUserMail.Text.Trim()))
                SetControlAsInvalid(privateUserMail, ref validationResult); 
             
            if (string.IsNullOrEmpty(privateUserBirthDate.Text.Trim()))
                SetControlAsInvalid(privateUserBirthDate, ref validationResult); 
            
            if (string.IsNullOrEmpty(privateUserPhone.Text.Trim()))
                SetControlAsInvalid(privateUserSurname, ref validationResult);
            
            if (string.IsNullOrEmpty(privateUserUserName.Text.Trim()))
                SetControlAsInvalid(privateUserUserName, ref validationResult); 
             
            if (string.IsNullOrEmpty(privateUserPassword.Text.Trim()))
                SetControlAsInvalid(privateUserPassword, ref validationResult);

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
    public bool SaveModel(IModel model)
    {
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
            var dtNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string cadenaDateTime = dt.ToString("d", CultureInfo.CurrentCulture);
            switch (Mode)
            {
                //Nuevo
                case ViewMode.Create:

                    _id = Entity.GetNextPrimaryKey();
                    consulta = "INSERT INTO USER_ALUMNO(id, NAME, surname, birth_date, mail, user_name, PASSWORD, entered, active, created, updated, phone) VALUES(" + _id + ",'" + privateUserName.Text + "','" + privateUserSurname.Text + "','" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + privateUserMail.Text + "','" + privateUserUserName.Text + "','" + privateUserPassword.Text + "', 0, " + active + ",'" + dtNow + "', null, " + privateUserPhone.Text + ")";

                    break;
                //Editar
                case ViewMode.Edit:

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
            //UIModel = GetModelFromForm();
            SaveModel(UIModel);
        }
    }

    #endregion
}
using System; 
using System.Configuration; 
using System.Globalization;
using MySql.Data.MySqlClient; 

public partial class EditUserAlumno : BasePage, IModelEdition
{
    #region [ Properties ]

    public String PageTitle = "Edición de alumno";
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

    private ModelUsuarioAlumno _uiModel;
    private ModelUsuarioAlumno UIModel
    {
        get
        {
            if (_uiModel == null)
            {
                return new ModelUsuarioAlumno();
            }
            return (ModelUsuarioAlumno)_uiModel;
        }
        set
        {
            _uiModel = value;
        }
    }
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
                Title = PageTitle;
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
                    break;

                case ViewMode.Edit: 
                    enabled = true;
                    break;
            }

            if(!Mode.Equals(ViewMode.Create))
            {
                FillFromModel();
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
            ModelUsuarioAlumno auxUsuarioAlumno = new ModelUsuarioAlumno();
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
            else
                auxUsuarioAlumno.Name = privateUserName.Text;

            if (string.IsNullOrEmpty(privateUserSurname.Text.Trim()))
                SetControlAsInvalid(privateUserSurname, ref validationResult);
            else
                auxUsuarioAlumno.Surname = privateUserSurname.Text;

            if (string.IsNullOrEmpty(privateUserMail.Text.Trim()))
                SetControlAsInvalid(privateUserMail, ref validationResult);
            else
                auxUsuarioAlumno.Mail = privateUserMail.Text;

            if (string.IsNullOrEmpty(privateUserBirthDate.Text.Trim()))
                SetControlAsInvalid(privateUserBirthDate, ref validationResult);
            else 
                auxUsuarioAlumno.BirthDate = HelperDataTypesConversion.GetDateTimeFromText(privateUserBirthDate.Text, Constants.inputDateTimeFormat_ddmmaaaa, CultureInfo.CurrentCulture);

            if (string.IsNullOrEmpty(privateUserPhone.Text.Trim()))
                SetControlAsInvalid(privateUserSurname, ref validationResult);
            else
                auxUsuarioAlumno.Phone = Int32.Parse(privateUserPhone.Text);

            if (string.IsNullOrEmpty(privateUserUserName.Text.Trim()))
                SetControlAsInvalid(privateUserUserName, ref validationResult);
            else
                auxUsuarioAlumno.UserName = privateUserUserName.Text;

            if (string.IsNullOrEmpty(privateUserPassword.Text.Trim()))
                SetControlAsInvalid(privateUserPassword, ref validationResult);
            else
                auxUsuarioAlumno.Password = privateUserPassword.Text;

            auxUsuarioAlumno.Active = privateUserActive.Checked;
            auxUsuarioAlumno.Entered = privateUserEntered.Checked;
            auxUsuarioAlumno.Created = HelperDataTypesConversion.GetDateTimeFromText(privateUserCreated.Text, Constants.inputDateTimeFormat_ddmmaaaa, CultureInfo.CurrentCulture);
            auxUsuarioAlumno.Updated = HelperDataTypesConversion.GetDateTimeFromText(privateUserUpdated.Text, Constants.inputDateTimeFormat_ddmmaaaa, CultureInfo.CurrentCulture);
            //auxUsuarioAlumno.Productos = ;

            UIModel = auxUsuarioAlumno;
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
    public bool SaveModel()
    {
        try
        { 
            var consulta = string.Empty;
            int active = UIModel.Active ? 1 : 0;
            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            switch (Mode)
            {
                case ViewMode.Create:
                    UIModel.Id = Entity.GetNextPrimaryKey();
                    Entity.Insert(UIModel);
                    consulta = "INSERT INTO USER_ALUMNO(id, NAME, surname, birth_date, mail, user_name, PASSWORD, entered, active, created, updated, phone) VALUES(" + UIModel.Id + ",'" + privateUserName.Text + "','" + privateUserSurname.Text + "','" + UIModel.BirthDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + privateUserMail.Text + "','" + privateUserUserName.Text + "','" + privateUserPassword.Text + "', 0, " + active + ",'" + now + "', null, " + privateUserPhone.Text + ")";
                    break;

                case ViewMode.Edit:
                    UIModel.Id = int.Parse(PrimaryKey);
                    Entity.UpdateByPrimaryKey(UIModel);
                    consulta = "UPDATE USER_ALUMNO SET NAME='" + privateUserName.Text + "', surname='" + privateUserSurname.Text + "', birth_date='" + UIModel.BirthDate.ToString("yyyy-MM-dd HH:mm:ss") + "', mail='" + privateUserMail.Text + "', user_name='" + privateUserUserName.Text + "', PASSWORD='" + privateUserPassword.Text + "', active=" + active + ", updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', phone=" + privateUserPhone.Text + " WHERE ID=" + UIModel.Id;
                    break;
            }

            MySqlConnection cnn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString);
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
        if(IsValidModel() && SaveModel())
        {
            //Response.Redirect(Constantes.PAGE_TITLE_UserAlumnoList + Constantes.ASP_PAGE_EXTENSION);
        }
    }
    
    #endregion
}
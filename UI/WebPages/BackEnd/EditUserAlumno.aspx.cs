using System;
using System.Globalization;

public partial class EditUserAlumno : BasePage, IModelEdition
{
    #region [ properties ]
    
    public IModel Model
    {
        get {
            try {
                if (Session["Model"] == null) Session["Model"] = Entity.GetByPrimaryKey(Int32.Parse(PrimaryKey));
            }
            catch (Exception ex) { 
                var aux = ex;
            }
            return (ModelUsuarioAlumno)Session["Model"];
        }
        set {
            Session["Model"] = value;
        }
    } 

    private ModelUsuarioAlumno UIModel;

    #endregion

    #region [ page events ]

    public void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) ApplyLayout();
    }
    public void Page_Init(object sender, EventArgs e)
    {
        try {
            if (!IsPostBack)
            {
                Title = PageTitle;
                //ModelClass = typeof(ModelUsuarioAlumno);
                BussinesObject = BussinesTypedObject.BOType.UsuarioAlumno;

                // Informar del type desde el diseñador cuando cree el userControl de edicion de esta entidad ->  
                //      --> ModelClass ='<%# typeof(ModelDocumento) %>' 

                Session.RemoveAll();
                GetPageParameters();
            }
        }
        catch (Exception ex) {
            Session["error"] = ex;
            //((MasterPage)(this.Master)).SetLOG("ERROR", "Loading Page", "EditCenter.aspx", "Center", "Page_Init()", ex.Message, DateTime.Now, 1);
            //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "Page_Init()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
        }
    }

    #endregion

    #region [ methods ]

    public void GetPageParameters()
    {
        GetPrimaryKey();
        GetViewMode();
    }
    public void ApplyLayout()
    {
        try {
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
                case ViewMode.None:
                    enabled = false;
                    ResetFields();
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
            if (!enabled) privateUserActive.Attributes["disabled"] = "disabled";
            message.Disabled = ! enabled;

            privateUserCreated.Enabled = false;
            privateUserUpdated.Enabled = false;

            if (Mode.Equals(ViewMode.Edit) | Mode.Equals(ViewMode.View)) FillFromModel();
        }
        catch (Exception ex) {
            Session["error"] = ex;
            // this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "ApplyLayout()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
        }
    }
    public void ResetFields()
    {
        privateUserName.Text = string.Empty;
        privateUserSurname.Text = string.Empty;
        privateUserMail.Text = string.Empty;
        privateUserPhone.Text = string.Empty;
        privateUserUserName.Text = string.Empty;
        privateUserPassword.Text = string.Empty;
        privateUserEntered.Checked = false;
        privateUserCreated.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
        privateUserBirthDate.Text = string.Empty;
        privateUserActive.Checked = false;
        privateUserUpdated.Text = string.Empty;
        message.Value = string.Empty;
    }
    public void FillFromModel()
    { 
        try {
            //var modelType = TypedObject.ModelLayerType;
            //var userAlumnoModel2 = ((modelType.GetType())Model);

            var modelType = Type.GetType(TypedObject.ModelLayerType.Name);
            var userAlumnoModel_CustomConvert = ConvertType<IModel>(Model);
             

            var userAlumnoModel = ((ModelUsuarioAlumno)Model);

            if (TryCast(ref TypedObject.ModelLayerType, Model))
            { 
                privateUserName.Text = userAlumnoModel.Name;
                privateUserSurname.Text = userAlumnoModel.Surname;
                privateUserBirthDate.Text = userAlumnoModel.BirthDate.ToString("dd/MM/yyyy");
                privateUserMail.Text = userAlumnoModel.Mail;
                privateUserUserName.Text = userAlumnoModel.UserName;
                privateUserPassword.Text = userAlumnoModel.Password;
                privateUserEntered.Checked = userAlumnoModel.Entered;
                privateUserActive.Checked = userAlumnoModel.Active;
                privateUserPhone.Text = userAlumnoModel.Phone.ToString();
                message.Value = "more info";

                var updateDate = string.Empty;
                var createdDate = string.Empty; 
                switch (Mode) {
                    case ViewMode.Create:
                        updateDate = string.Empty;
                        createdDate = DateTime.Now.ToString("dd/MM/yyyy");
                        break;
                    case ViewMode.Edit:
                        updateDate = DateTime.Now.ToString("dd/MM/yyyy");
                        createdDate = userAlumnoModel.Created.ToString("dd/MM/yyyy");
                        break;
                    case ViewMode.View:
                        updateDate = userAlumnoModel.Updated.ToString("dd/MM/yyyy");
                        createdDate = userAlumnoModel.Created.ToString("dd/MM/yyyy");
                        break; 
                } 
                privateUserCreated.Text = createdDate;
                privateUserUpdated.Text = updateDate;

            }

        }
        catch (Exception ex) {
            
            ErrorTreatment(ex); 
        }
    }
     
    public bool TryCast<T>(ref T t, object o)
    {
        if (o == null || !typeof(T).IsAssignableFrom(o.GetType())) return false;
        else t = (T)o;
        return true;
    }

    public T ConvertType<T>(object input)
    {
        return (T)Convert.ChangeType(input, typeof(T));
    }

    public bool IsValidModel()
    {
        try {
            UIModel = new ModelUsuarioAlumno();
            bool validationResult = true;

            SetBorderToDefaultColor();

            if (string.IsNullOrEmpty(privateUserName.Text.Trim()))
                SetControlAsInvalid(privateUserName, ref validationResult);
            else
                UIModel.Name = privateUserName.Text;

            if (string.IsNullOrEmpty(privateUserSurname.Text.Trim()))
                SetControlAsInvalid(privateUserSurname, ref validationResult);
            else
                UIModel.Surname = privateUserSurname.Text;

            if (string.IsNullOrEmpty(privateUserMail.Text.Trim()))
                SetControlAsInvalid(privateUserMail, ref validationResult);
            else
                UIModel.Mail = privateUserMail.Text;

            if (string.IsNullOrEmpty(privateUserBirthDate.Text.Trim()))
                SetControlAsInvalid(privateUserBirthDate, ref validationResult);
            else
                UIModel.BirthDate = HelperDataTypesConversion.GetDateTimeFromText(privateUserBirthDate.Text, Constants.inputDateTimeFormat_ddmmaaaa, CultureInfo.CurrentCulture);

            if (string.IsNullOrEmpty(privateUserPhone.Text.Trim()))
                SetControlAsInvalid(privateUserSurname, ref validationResult);
            else
                UIModel.Phone = Int32.Parse(privateUserPhone.Text);

            if (string.IsNullOrEmpty(privateUserUserName.Text.Trim()))
                SetControlAsInvalid(privateUserUserName, ref validationResult);
            else
                UIModel.UserName = privateUserUserName.Text;

            if (string.IsNullOrEmpty(privateUserPassword.Text.Trim()))
                SetControlAsInvalid(privateUserPassword, ref validationResult);
            else
                UIModel.Password = privateUserPassword.Text;

            UIModel.Active = privateUserActive.Checked;
            UIModel.Entered = privateUserEntered.Checked;

            UIModel.Created = HelperDataTypesConversion.GetDateTimeFromText(privateUserCreated.Text, Constants.inputDateTimeFormat_ddmmaaaa, CultureInfo.CurrentCulture);
            UIModel.Updated = HelperDataTypesConversion.GetDateTimeFromText(privateUserUpdated.Text, Constants.inputDateTimeFormat_ddmmaaaa, CultureInfo.CurrentCulture);
            //UIModel.Productos = ;
             
            return validationResult;
        }
        catch (Exception ex) {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "FillCenter()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
            return false;
        }
    }
    public bool SaveModel()
    {
        try { 
            switch (Mode) {
                case ViewMode.Create:
                    Entity.Insert(UIModel);
                    break;

                case ViewMode.Edit:
                    UIModel.Id = int.Parse(PrimaryKey);
                    Entity.UpdateByPrimaryKey(UIModel);

                    //var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //int active = UIModel.Active ? 1 : 0;
                    //var consulta = "UPDATE USER_ALUMNO SET NAME='" + privateUserName.Text + "', surname='" + privateUserSurname.Text + "', birth_date='" + UIModel.BirthDate.ToString("yyyy-MM-dd HH:mm:ss") + "', mail='" + privateUserMail.Text + "', user_name='" + privateUserUserName.Text + "', PASSWORD='" + privateUserPassword.Text + "', active=" + active + ", updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', phone=" + privateUserPhone.Text + " WHERE ID=" + UIModel.Id;
                    break;
            }
        }
        catch (Exception ex) {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "FillCenter()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
        }
        return true;
    }

    private void SetBorderToDefaultColor()
    {
        privateUserName.BorderColor = GrayHtmlColor;
        privateUserSurname.BorderColor = GrayHtmlColor;
        privateUserMail.BorderColor = GrayHtmlColor;
        privateUserBirthDate.BorderColor = GrayHtmlColor;
        privateUserPhone.BorderColor = GrayHtmlColor;
        privateUserUserName.BorderColor = GrayHtmlColor;
        privateUserPassword.BorderColor = GrayHtmlColor;
    }
    
    #endregion

    #region [ button events ]

    public void GoBackClick(object sender, EventArgs e)
    {
        //Response.Redirect(Constantes.PAGE_TITLE_UserAlumnoList + Constantes.ASP_PAGE_EXTENSION);
    }
    public void SaveModelClick(object sender, EventArgs e)
    {
        if (IsValidModel() && SaveModel()) {
            //Response.Redirect("PAGE_TITLE_UserAlumnoList.aspx");
        }
        else {
            // TODO Alerta --> revisar los campos no válidos
        }
    }

    #endregion
}
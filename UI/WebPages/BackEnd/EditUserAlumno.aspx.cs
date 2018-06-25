using BussinesTypedObject;
using System; 
using System.Globalization;
using System.Reflection;
using System.Runtime.Remoting;

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
                throw ex;
            }
            return Convertion(Session["Model"], EntityManager.TypedBO.ModelLayerType);
        }
        set {
            Session["Model"] = value;
        }
    } 

    private IModel UIModel;
    
    #endregion

    #region [ events ]

    public void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            ApplyLayout();
        }
    } 
    public void Page_Init(object sender, EventArgs e)
    {
        try {
            if (!IsPostBack) {
                Title = PageTitle;
                BussinesObject = BussinesTypes.BussinesObjectTypeEnum.UsuarioAlumno;

                Session.RemoveAll();
                GetPageParameters();
                LoadPageControls();
                
                // Informar del type desde el diseñador cuando cree el userControl de edicion de esta entidad --> ModelClass ='<%# typeof(ModelDocumento) %>' 
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
        if(Request.QueryString.Count > 0) {
            GetPrimaryKey();
            GetViewMode();
        }
    }
    public void ApplyLayout()
    {
        try {
            var enabled = false;
            switch (Mode) {
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

            ActivateControls(enabled);

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
        privateUserMessage.Value = string.Empty;
    }
    public void FillFromModel()
    { 
        try {
            //Asignar valor a las propiedades por Reflexion - haciendo macth por nombre
            privateUserName.Text = ((dynamic)Model).Name;
            privateUserSurname.Text = ((dynamic)Model).Surname;
            privateUserBirthDate.Text = ((dynamic)Model).BirthDate.ToString("dd/MM/yyyy");
            privateUserMail.Text = ((dynamic)Model).Mail;
            privateUserUserName.Text = ((dynamic)Model).UserName;
            privateUserPassword.Text = ((dynamic)Model).Password;
            privateUserEntered.Checked = ((dynamic)Model).Entered;
            privateUserActive.Checked = ((dynamic)Model).Active;
            privateUserPhone.Text = ((dynamic)Model).Phone.ToString();
            privateUserMessage.Value = "more info...";

            var createdDate = string.Empty;
            var updateDate = string.Empty;
            SetCreatedUpdatedData(ref createdDate, ref updateDate);
            privateUserCreated.Text = createdDate;
            privateUserUpdated.Text = updateDate;
        }
        catch (Exception ex) {
            ErrorTreatment(ex); 
        }
    }
     
    public bool IsValidModel()
    {
        try {
            var uiModel = Convertion((IModel)CreateNewInstance(EntityManager.TypedBO.ModelLayerType), EntityManager.TypedBO.ModelLayerType);
            //Type modelType = newObject.GetType();

            bool validationResult = true;

            SetBorderToDefaultColor();

            if (string.IsNullOrEmpty(privateUserName.Text.Trim()))
                SetControlAsInvalid(privateUserName, ref validationResult);
            else
                uiModel.Name = privateUserName.Text;

            if (string.IsNullOrEmpty(privateUserSurname.Text.Trim()))
                SetControlAsInvalid(privateUserSurname, ref validationResult);
            else
                uiModel.Surname = privateUserSurname.Text;

            if (string.IsNullOrEmpty(privateUserMail.Text.Trim()))
                SetControlAsInvalid(privateUserMail, ref validationResult);
            else
                uiModel.Mail = privateUserMail.Text;

            if (string.IsNullOrEmpty(privateUserBirthDate.Text.Trim()))
                SetControlAsInvalid(privateUserBirthDate, ref validationResult);
            else
                uiModel.BirthDate = HelperDataTypesConversion.GetDateTimeFromText(privateUserBirthDate.Text, 
                                                                                  Constants.inputDateTimeFormat_ddmmaaaa, 
                                                                                  CultureInfo.CurrentCulture);

            if (string.IsNullOrEmpty(privateUserPhone.Text.Trim()))
                SetControlAsInvalid(privateUserSurname, ref validationResult);
            else
                uiModel.Phone = Int32.Parse(privateUserPhone.Text);

            if (string.IsNullOrEmpty(privateUserUserName.Text.Trim()))
                SetControlAsInvalid(privateUserUserName, ref validationResult);
            else
                uiModel.UserName = privateUserUserName.Text;

            if (string.IsNullOrEmpty(privateUserPassword.Text.Trim()))
                SetControlAsInvalid(privateUserPassword, ref validationResult);
            else
                uiModel.Password = privateUserPassword.Text;

            uiModel.Active = privateUserActive.Checked;
            uiModel.Entered = privateUserEntered.Checked;

            uiModel.Created = HelperDataTypesConversion.GetDateTimeFromText(privateUserCreated.Text, 
                                                                            Constants.inputDateTimeFormat_ddmmaaaa, 
                                                                            CultureInfo.CurrentCulture);

            uiModel.Updated = HelperDataTypesConversion.GetDateTimeFromText(privateUserUpdated.Text,
                                                                            Constants.inputDateTimeFormat_ddmmaaaa, 
                                                                            CultureInfo.CurrentCulture);
            //UIModel.Productos = ;

            UIModel = uiModel;
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

    private void SetCreatedUpdatedData(ref string createdDate, ref string updateDate)
    {
        switch (Mode)
        {
            case ViewMode.Create:
                updateDate = string.Empty;
                createdDate = DateTime.Now.ToString("dd/MM/yyyy");
                break;
            case ViewMode.Edit:
                updateDate = DateTime.Now.ToString("dd/MM/yyyy");
                createdDate = Model.Created.ToString("dd/MM/yyyy");
                break;
            case ViewMode.View:
                updateDate = Model.Updated.ToString("dd/MM/yyyy");
                createdDate = Model.Created.ToString("dd/MM/yyyy");
                break;
        }
    }
    private Object CreateNewInstance(Type type)
    {
        var bussinesAssembly = Assembly.GetAssembly(EntityManager.TypedBO.ModelLayerType);
        ObjectHandle handle = Activator.CreateInstance(bussinesAssembly.GetName().Name, EntityManager.TypedBO.ModelLayerType.Name);
        Object modelInstance = handle.Unwrap();
        return modelInstance;
    }
    private static dynamic Convertion(dynamic source, Type dest)
    {
        return Convert.ChangeType(source, dest);
    }
    private void SetBorderToDefaultColor()
    {
        // Cambiar por método polivalente(recibe accion a realizar en formato Enum) que recorra la lista de controles y setee el color del borde
        // Después de este cambio mover este metodo a BasePage

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
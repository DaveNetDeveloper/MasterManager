using BussinesTypedObject;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.Remoting;

public partial class EditUserAlumno : BasePage //, IEntityEdition
{
    #region [ properties ]

    public IModel Model
    {
        get
        {
            try
            {
                if (Session["Model"] == null) Session["Model"] = Entity.GetByPrimaryKey(Int32.Parse(PrimaryKey));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (IModel)Session["Model"];
        }
        set
        {
            Session["Model"] = value;
        }
    }

    private IModel UIModel;

    #endregion

    #region [ events ]

    public void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ApplyLayout();
            FillFromModel();
        }
    }
    public void Page_Init(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Title = PageTitle;
                BussinesObject = BussinesTypes.BussinesObjectType.Usuario_Alumno;
                UIControlPrefix = BussinesObject.ToString() + "_";

                Session.RemoveAll();
                GetPageParameters();
                LoadPageControls();

                // Informar del type desde el diseñador cuando cree el userControl de edicion de esta entidad --> ModelClass ='<%# typeof(ModelDocumento) %>' 
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

    #region [ methods ]

    public void GetPageParameters()
    {
        if (Request.QueryString.Count > 0)
        {
            GetPrimaryKey();
            GetViewMode();
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
                case ViewMode.None:
                    enabled = false;
                    ResetFields();
                    break;
            }

            btnGuardar.Visible = enabled;
            btnVolver.Visible = true;

            ActivateControls(enabled);
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
        UsuarioAlumno_Name.Text = string.Empty;
        UsuarioAlumno_Surname.Text = string.Empty;
        UsuarioAlumno_Mail.Text = string.Empty;
        UsuarioAlumno_Phone.Text = string.Empty;
        UsuarioAlumno_UserName.Text = string.Empty;
        UsuarioAlumno_Password.Text = string.Empty;
        UsuarioAlumno_Entered.Checked = false;
        UsuarioAlumno_Created.Text = DateTime.Now.ToString("dd/MM/yyyy");
        UsuarioAlumno_BirthDate.Text = string.Empty;
        UsuarioAlumno_Active.Checked = false;
        UsuarioAlumno_Updated.Text = string.Empty;
        UsuarioAlumno_Message.Value = string.Empty;
    }
    public void FillFromModel()
    {
        try
        {
            if (Mode.Equals(ViewMode.Edit) || Mode.Equals(ViewMode.View))
            {
                //llamar a nuevo método ActionToControl, que recibe el nombre del control ("" + )
                //Asignar valor a las propiedades por Reflexion - haciendo macth por nombre
                UsuarioAlumno_Name.Text = ((dynamic)Model).Name;
                UsuarioAlumno_Surname.Text = ((dynamic)Model).Surname;
                UsuarioAlumno_BirthDate.Text = ((dynamic)Model).BirthDate.ToString("dd/MM/yyyy");
                UsuarioAlumno_Mail.Text = ((dynamic)Model).Mail;
                UsuarioAlumno_UserName.Text = ((dynamic)Model).UserName;
                UsuarioAlumno_Password.Text = ((dynamic)Model).Password;
                UsuarioAlumno_Entered.Checked = ((dynamic)Model).Entered;
                UsuarioAlumno_Active.Checked = ((dynamic)Model).Active;
                UsuarioAlumno_Phone.Text = ((dynamic)Model).Phone.ToString();
                UsuarioAlumno_Message.Value = "more info...";

                var createdDate = string.Empty;
                var updateDate = string.Empty;
                SetCreatedUpdatedData(ref createdDate, ref updateDate);
                UsuarioAlumno_Created.Text = createdDate;
                UsuarioAlumno_Updated.Text = updateDate;
            }
        }
        catch (Exception ex)
        {
            ErrorTreatment(ex);
        }
    }

    public bool IsValidModel()
    {
        try
        {
            IModel uiModel = (IModel)CreateNewModelInstance();
            bool validationResult = true;

            if (string.IsNullOrEmpty(UsuarioAlumno_Name.Text.Trim()))
                SetControlAsInvalid(UsuarioAlumno_Name, ref validationResult);
            else
                ((dynamic)uiModel).Name = UsuarioAlumno_Name.Text;

            if (string.IsNullOrEmpty(UsuarioAlumno_Surname.Text.Trim()))
                SetControlAsInvalid(UsuarioAlumno_Surname, ref validationResult);
            else
                ((dynamic)uiModel).Surname = UsuarioAlumno_Surname.Text;

            if (string.IsNullOrEmpty(UsuarioAlumno_Mail.Text.Trim()))
                SetControlAsInvalid(UsuarioAlumno_Mail, ref validationResult);
            else
                ((dynamic)uiModel).Mail = UsuarioAlumno_Mail.Text;

            if (string.IsNullOrEmpty(UsuarioAlumno_BirthDate.Text.Trim()))
                SetControlAsInvalid(UsuarioAlumno_BirthDate, ref validationResult);
            else
                ((dynamic)uiModel).BirthDate = HelperDataTypesConversion.GetDateTimeFromText(UsuarioAlumno_BirthDate.Text,
                                                                                  Constants.inputDateTimeFormat_ddmmaaaa,
                                                                                  CultureInfo.CurrentCulture);

            if (string.IsNullOrEmpty(UsuarioAlumno_Phone.Text.Trim()))
                SetControlAsInvalid(UsuarioAlumno_Surname, ref validationResult);
            else
                ((dynamic)uiModel).Phone = Int32.Parse(UsuarioAlumno_Phone.Text);

            if (string.IsNullOrEmpty(UsuarioAlumno_UserName.Text.Trim()))
                SetControlAsInvalid(UsuarioAlumno_UserName, ref validationResult);
            else
                ((dynamic)uiModel).UserName = UsuarioAlumno_UserName.Text;

            if (string.IsNullOrEmpty(UsuarioAlumno_Password.Text.Trim()))
                SetControlAsInvalid(UsuarioAlumno_Password, ref validationResult);
            else
                ((dynamic)uiModel).Password = UsuarioAlumno_Password.Text;

            ((dynamic)uiModel).Active = UsuarioAlumno_Active.Checked;
            ((dynamic)uiModel).Entered = UsuarioAlumno_Entered.Checked;

            uiModel.Created = HelperDataTypesConversion.GetDateTimeFromText(UsuarioAlumno_Created.Text,
                                                                            Constants.inputDateTimeFormat_ddmmaaaa,
                                                                            CultureInfo.CurrentCulture);

            uiModel.Updated = HelperDataTypesConversion.GetDateTimeFromText(UsuarioAlumno_Updated.Text,
                                                                            Constants.inputDateTimeFormat_ddmmaaaa,
                                                                            CultureInfo.CurrentCulture);
            //UIModel.Productos = ;

            UIModel = uiModel;
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
            switch (Mode)
            {
                case ViewMode.Create:
                    Entity.Insert(UIModel);
                    break;

                case ViewMode.Edit:
                    UIModel.Id = int.Parse(PrimaryKey);
                    Entity.UpdateByPrimaryKey(UIModel);

                    //var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //int active = UIModel.Active ? 1 : 0;
                    //var consulta = "UPDATE USER_ALUMNO SET NAME='" + UsuarioAlumno_Name.Text + "', surname='" + UsuarioAlumno_Surname.Text + "', birth_date='" + UIModel.BirthDate.ToString("yyyy-MM-dd HH:mm:ss") + "', mail='" + UsuarioAlumno_Mail.Text + "', user_name='" + UsuarioAlumno_UserName.Text + "', PASSWORD='" + UsuarioAlumno_Password.Text + "', active=" + active + ", updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', phone=" + UsuarioAlumno_Phone.Text + " WHERE ID=" + UIModel.Id;
                    break;
            }
        }
        catch (Exception ex)
        {
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
    private Object CreateNewModelInstance()
    {
        var bussinesAssembly = Assembly.GetAssembly(EntityManager.TypedBO.ModelLayerType);
        ObjectHandle handle = Activator.CreateInstance(bussinesAssembly.GetName().Name, EntityManager.TypedBO.ModelLayerType.Name);
        Object modelInstance = handle.Unwrap();
        return modelInstance;
    }
    private void SetBorderToDefaultColor()
    {
        // Cambiar por método polivalente(recibe accion a realizar en formato ActionsForControl) que recorra la lista de controles y 
        // setee el color del borde 
        // Después de este cambio mover este metodo a BasePage

        UsuarioAlumno_Name.BorderColor = GrayHtmlColor;
        UsuarioAlumno_Surname.BorderColor = GrayHtmlColor;
        UsuarioAlumno_Mail.BorderColor = GrayHtmlColor;
        UsuarioAlumno_BirthDate.BorderColor = GrayHtmlColor;
        UsuarioAlumno_Phone.BorderColor = GrayHtmlColor;
        UsuarioAlumno_UserName.BorderColor = GrayHtmlColor;
        UsuarioAlumno_Password.BorderColor = GrayHtmlColor;
    }

    #endregion

    #region [ button events ]

    public void GoBackClick(object sender, EventArgs e)
    {
        //Response.Redirect(Constantes.PAGE_TITLE_UserAlumnoList + Constantes.ASP_PAGE_EXTENSION);
    }
    public void SaveModelClick(object sender, EventArgs e)
    {
        SetBorderToDefaultColor();
        if (IsValidModel() && SaveModel())
        {
            //Response.Redirect("PAGE_TITLE_UserAlumnoList.aspx");
        }
        else
        {
            // TODO Alerta --> revisar los campos no válidos
        }
    }

    #endregion
}
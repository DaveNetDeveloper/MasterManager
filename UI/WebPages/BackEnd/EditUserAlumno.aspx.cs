using System;
using System.Globalization;

public partial class EditUserAlumno : BasePage, IModelEdition
{
    #region [ Page Events ]

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack) {
                ModelClass = typeof(ModelUsuarioAlumno); // Informar del type desde el diseñador cuando cree el userControl de edicion de esta entidad ->  ModelClass='<%# typeof(ModelDocumento) %>' 
                Session.RemoveAll();
                Title = PageTitle;
                GetPageParameters();
                ApplyLayout();
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

    #region [ Methods ]

    public void GetPageParameters()
    {
        GetPrimaryKey();
        GetViewMode();
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
        catch (Exception ex)
        {
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
            privateUserActive.Checked = userAlumnoModel.Active;
            privateUserPhone.Text = userAlumnoModel.Phone.ToString();
            //message.Value = "Extra info";

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
                    //var consulta = "UPDATE USER_ALUMNO SET NAME='" + privateUserName.Text + "', surname='" + privateUserSurname.Text + "', birth_date='" + UIModel.BirthDate.ToString("yyyy-MM-dd HH:mm:ss") + "', mail='" + privateUserMail.Text + "', user_name='" + privateUserUserName.Text + "', PASSWORD='" + privateUserPassword.Text + "', active=" + active + ", updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', phone=" + privateUserPhone.Text + " WHERE ID=" + UIModel.Id;
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

    #endregion

    #region [ Button Events ]

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
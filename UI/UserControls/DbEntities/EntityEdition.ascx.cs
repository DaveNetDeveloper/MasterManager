using System;   
using System.Globalization;
using System.Reflection;
using System.Runtime.Remoting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class EntityEdition : BaseUC //, IModelEdition
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
            return (IModel)Session["Model"];
        }
        set {  
            Session["Model"] = value;
        }
    }
    private IModel UIModel;

    #endregion

    #region [ events ]

    protected override void OnLoad(EventArgs e)
    {
        if (IsPostBack) return;
        ApplyLayout();
        FillFromModel();
    }
    protected override void OnInit(EventArgs e)
    {
        try {
            if (IsPostBack) return;
            InitializeCache();
            InitializeData();
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
        if (Request.QueryString.Count > 0) {
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
        //llamar a nuevo método ActionToControl, que recibe el nombre del control y la acción de reset value
        ResetControlValues();

        //entityControl_Name.Text = string.Empty;
        //entityControl_Surname.Text = string.Empty;
        //entityControl_Mail.Text = string.Empty;
        //entityControl_Phone.Text = string.Empty;
        //entityControl_UserName.Text = string.Empty;
        //entityControl_Password.Text = string.Empty;
        //entityControl_Entered.Checked = false;
        //entityControl_Created.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //entityControl_BirthDate.Text = string.Empty;
        //entityControl_Active.Checked = false;
        //entityControl_Updated.Text = string.Empty;
        //entityControl_Message.Value = string.Empty;
    }
    public void FillFromModel()
    {
        try {
            if (Mode.Equals(ViewMode.Edit) || Mode.Equals(ViewMode.View)) {

                //llamar a nuevo método ActionToControl, que recibe el nombre del control ("" + )
                //Asignar valor a las propiedades por Reflexion - haciendo macth por nombre
                
                ActionForControl(((dynamic)Model).Name, entityControl_Name.ID);

                entityControl_Name.Text = ((dynamic)Model).Name;
                entityControl_Surname.Text = ((dynamic)Model).Surname;
                entityControl_BirthDate.Text = ((dynamic)Model).BirthDate.ToString("dd/MM/yyyy");
                entityControl_Mail.Text = ((dynamic)Model).Mail;
                entityControl_UserName.Text = ((dynamic)Model).UserName;
                entityControl_Password.Text = ((dynamic)Model).Password;
                entityControl_Entered.Checked = ((dynamic)Model).Entered;
                entityControl_Active.Checked = ((dynamic)Model).Active;
                entityControl_Phone.Text = ((dynamic)Model).Phone.ToString();
                entityControl_Message.Value = "more info...";

                var createdDate = string.Empty;
                var updateDate = string.Empty;
                SetCreatedUpdatedData(ref createdDate, ref updateDate);
                entityControl_Created.Text = createdDate;
                entityControl_Updated.Text = updateDate;
            }
        }
        catch (Exception ex) {
            ErrorTreatment(ex);
        }
    }
    public bool IsValidModel() {
        try {
            IModel uiModel = (IModel)CreateNewModelInstance();
            bool validationResult = true;

            if (string.IsNullOrEmpty(entityControl_Name.Text.Trim()))
                SetControlAsInvalid(entityControl_Name, ref validationResult);
            else
                ((dynamic)uiModel).Name = entityControl_Name.Text;

            if (string.IsNullOrEmpty(entityControl_Surname.Text.Trim()))
                SetControlAsInvalid(entityControl_Surname, ref validationResult);
            else
                ((dynamic)uiModel).Surname = entityControl_Surname.Text;

            if (string.IsNullOrEmpty(entityControl_Mail.Text.Trim()))
                SetControlAsInvalid(entityControl_Mail, ref validationResult);
            else
                ((dynamic)uiModel).Mail = entityControl_Mail.Text;

            if (string.IsNullOrEmpty(entityControl_BirthDate.Text.Trim()))
                SetControlAsInvalid(entityControl_BirthDate, ref validationResult);
            else
                ((dynamic)uiModel).BirthDate = HelperDataTypesConversion.GetDateTimeFromText(entityControl_BirthDate.Text,
                                                                                  Constants.inputDateTimeFormat_ddmmaaaa,
                                                                                  CultureInfo.CurrentCulture);

            if (string.IsNullOrEmpty(entityControl_Phone.Text.Trim()))
                SetControlAsInvalid(entityControl_Surname, ref validationResult);
            else
                ((dynamic)uiModel).Phone = Int32.Parse(entityControl_Phone.Text);

            if (string.IsNullOrEmpty(entityControl_UserName.Text.Trim()))
                SetControlAsInvalid(entityControl_UserName, ref validationResult);
            else
                ((dynamic)uiModel).UserName = entityControl_UserName.Text;

            if (string.IsNullOrEmpty(entityControl_Password.Text.Trim()))
                SetControlAsInvalid(entityControl_Password, ref validationResult);
            else
                ((dynamic)uiModel).Password = entityControl_Password.Text;

            ((dynamic)uiModel).Active = entityControl_Active.Checked;
            ((dynamic)uiModel).Entered = entityControl_Entered.Checked;

            uiModel.Created = HelperDataTypesConversion.GetDateTimeFromText(entityControl_Created.Text,
                                                                            Constants.inputDateTimeFormat_ddmmaaaa,
                                                                            CultureInfo.CurrentCulture);

            uiModel.Updated = HelperDataTypesConversion.GetDateTimeFromText(entityControl_Updated.Text,
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
    public bool SaveModel() {
        try
        {
            switch (Mode) {
                case ViewMode.Create:
                    Entity.Insert(UIModel);
                    break;

                case ViewMode.Edit:
                    UIModel.Id = int.Parse(PrimaryKey);
                    Entity.UpdateByPrimaryKey(UIModel);

                    //var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //int active = UIModel.Active ? 1 : 0;
                    //var consulta = "UPDATE USER_ALUMNO SET NAME='" + entityControl_Name.Text + "', surname='" + entityControl_Surname.Text + "', birth_date='" + UIModel.BirthDate.ToString("yyyy-MM-dd HH:mm:ss") + "', mail='" + entityControl_Mail.Text + "', user_name='" + entityControl_UserName.Text + "', PASSWORD='" + entityControl_Password.Text + "', active=" + active + ", updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', phone=" + entityControl_Phone.Text + " WHERE ID=" + UIModel.Id;
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

    //privates
    private void SetCreatedUpdatedData(ref string createdDate, ref string updateDate)
    {
        switch (Mode) {
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

        foreach (Control c in ControlList) { 
            switch (c.GetType().Name) { 
                case "TextBox":
                    ((TextBox)c).BorderColor = GrayHtmlColor;
                    break;
                case "CheckBox":
                    ((CheckBox)c).BorderColor = GrayHtmlColor;
                    break;
                case "HtmlInputCheckBox":
                    ((HtmlInputCheckBox)c).Attributes.CssStyle["bordercolor"] = GrayHtmlColor.ToString();
                    break;
                case "HtmlTextArea":
                    ((HtmlTextArea)c).Attributes.CssStyle["bordercolor"] = GrayHtmlColor.ToString();
                    break;
            }
        }

        entityControl_Name.BorderColor = GrayHtmlColor;
        entityControl_Surname.BorderColor = GrayHtmlColor;
        entityControl_Mail.BorderColor = GrayHtmlColor;
        entityControl_BirthDate.BorderColor = GrayHtmlColor;
        entityControl_Phone.BorderColor = GrayHtmlColor;
        entityControl_UserName.BorderColor = GrayHtmlColor;
        entityControl_Password.BorderColor = GrayHtmlColor;
    }
    private void InitializeData()
    {
        GetPageParameters();
        EntityManager.InitializeTypes(BussinesObject, ProyectName);
        LoadControls();
    }
    private void InitializeCache()
    {
        DisposeProperties();
        InitializeSession();
    }
    private void DisposeProperties()
    {
        EntityManager = null;
        Model = null;
        Entity = null;
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
        if (IsValidModel() && SaveModel()) {
            //Response.Redirect("PAGE_TITLE_UserAlumnoList.aspx");
        }
        else
        {
            // TODO Alerta --> revisar los campos no válidos
        }
    }

    #endregion
}
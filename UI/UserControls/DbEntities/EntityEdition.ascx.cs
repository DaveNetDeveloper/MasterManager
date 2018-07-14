using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class EntityEdition : BaseUC
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
        if (!IsPostBack) {
            ApplyLayout();
            FillFromModel();
        }
    }
    protected override void OnInit(EventArgs e)
    {
        try {
            if (!IsPostBack) {
                InitializeCache();
                GetPageParameters();
                EntityManager.InitializeTypes(BussinesObject, ProyectName);
                InitializeControls();
            }
        }
        catch (Exception ex) {
            Session["error"] = ex;
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
                foreach (var control in ControlList) {
                    var property = GetModelProperty(GetSimplyName(control.ID));
                    if(null != property) {
                        Object fieldValue = null;
                        switch (property.PropertyType.Name.ToLower()) {

                            case "string":
                                fieldValue = property.GetValue(Model);
                                ((TextBox)control).Text = (string)fieldValue;
                                break;

                            case "datetime":
                                if(IsAuditField(property.Name.ToLower())){
                                    fieldValue = GetAuditFieldValue(property);
                                    ((TextBox)control).Enabled = false;
                                    ((TextBox)control).ReadOnly = true;
                                }
                                else fieldValue = property.GetValue(Model);
                                ((TextBox)control).Text = fieldValue.ToString();
                                break;

                            case "boolean":
                                fieldValue = property.GetValue(Model);
                                ((HtmlInputCheckBox)control).Checked = ((bool)fieldValue) ? true : false;
                                break;
                            
                            case "int32":
                            case "decimal":

                                if(IsSpecialField(property.Name.ToLower())) {
                                    ((TextBox)control).Enabled = false;
                                    ((TextBox)control).ReadOnly = true;
                                }

                                fieldValue = property.GetValue(Model);
                                ((TextBox)control).Text = ((Int32)fieldValue).ToString();
                                break; 

                            default:
                                fieldValue = null;
                                break;
                        }
                    }
                }
                //TODO: entityControl_Message.Value = "more info...";
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

            //if (string.IsNullOrEmpty(entityControl_Name.Text.Trim()))
            //    SetControlAsInvalid(entityControl_Name, ref validationResult);
           // else
            //    ((dynamic)uiModel).Name = entityControl_Name.Text;

            //if (string.IsNullOrEmpty(entityControl_Surname.Text.Trim()))
            //    SetControlAsInvalid(entityControl_Surname, ref validationResult);
            //else
            //    ((dynamic)uiModel).Surname = entityControl_Surname.Text;

            //if (string.IsNullOrEmpty(entityControl_Mail.Text.Trim()))
            //    SetControlAsInvalid(entityControl_Mail, ref validationResult);
            //else
            //    ((dynamic)uiModel).Mail = entityControl_Mail.Text;

            //if (string.IsNullOrEmpty(entityControl_BirthDate.Text.Trim()))
            //    SetControlAsInvalid(entityControl_BirthDate, ref validationResult);
            //else
            //    ((dynamic)uiModel).BirthDate = HelperDataTypesConversion.GetDateTimeFromText(entityControl_BirthDate.Text,
            //                                                                      Constants.inputDateTimeFormat_ddmmaaaa,
            //                                                                      CultureInfo.CurrentCulture);

            //if (string.IsNullOrEmpty(entityControl_Phone.Text.Trim()))
            //    SetControlAsInvalid(entityControl_Surname, ref validationResult);
            //else
            //    ((dynamic)uiModel).Phone = Int32.Parse(entityControl_Phone.Text);

            //if (string.IsNullOrEmpty(entityControl_UserName.Text.Trim()))
            //    SetControlAsInvalid(entityControl_UserName, ref validationResult);
            //else
            //    ((dynamic)uiModel).UserName = entityControl_UserName.Text;

            //if (string.IsNullOrEmpty(entityControl_Password.Text.Trim()))
            //    SetControlAsInvalid(entityControl_Password, ref validationResult);
            //else
            //    ((dynamic)uiModel).Password = entityControl_Password.Text;

            //((dynamic)uiModel).Active = entityControl_Active.Checked;
            //((dynamic)uiModel).Entered = entityControl_Entered.Checked;

            //uiModel.Created = HelperDataTypesConversion.GetDateTimeFromText(entityControl_Created.Text,
            //                                                                Constants.inputDateTimeFormat_ddmmaaaa,
            //                                                                CultureInfo.CurrentCulture);

            //uiModel.Updated = HelperDataTypesConversion.GetDateTimeFromText(entityControl_Updated.Text,
            //                                                                Constants.inputDateTimeFormat_ddmmaaaa,
            //                                                                CultureInfo.CurrentCulture);
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

    private bool IsSpecialField(string propertyLowerName)
    {
        return propertyLowerName.Equals("id") || (IsForeingKeyField(propertyLowerName));
    }
    private bool IsForeingKeyField(string propertyLowerName)
    {
        foreach (var item in Model.FkRelationsList) {
            if (item.ColumnName.Equals(propertyLowerName)) return true;
        }
        return false;
    }
    private void InitializeControls()
    {
        CreateControls();
        AddControlsToHtmlForm();
    }
    private PropertyInfo GetModelProperty(string propertyName)
    {
        foreach (var property in Model.GetType().GetProperties()) {
            if (propertyName.ToLower().Equals(property.Name.ToLower())) return property; 
        }
        return null;
    }
    private Object CreateNewModelInstance()
    {
        var bussinesAssembly = Assembly.GetAssembly(EntityManager.TypedBO.ModelLayerType);
        ObjectHandle handle = Activator.CreateInstance(bussinesAssembly.GetName().Name, EntityManager.TypedBO.ModelLayerType.Name);
        Object modelInstance = handle.Unwrap();
        return modelInstance;
    }
    private void CreateControls()
    {
        short tabIndex = 0;
        var ModelClass = EntityManager.TypedBO.ModelLayerType;
        foreach (PropertyInfo property in ModelClass.GetProperties()) {
            tabIndex++;
            var propertyName = UIControlPrefix + property.Name;
            Control control = null;
            bool addControl = false;

            switch (property.PropertyType.Name.ToLower()) {

                case "string":
                    control = new TextBox();
                    ((TextBox)control).CssClass = "form-lname form-element large";
                    ((TextBox)control).Attributes["placeholder"] = property.Name;
                    ((TextBox)control).Attributes["required"] = "required";
                    ((TextBox)control).Attributes["name"] = propertyName;
                    ((TextBox)control).TabIndex = tabIndex;
                    control.ID = propertyName;
                    addControl = true;
                    break;

                case "boolean":
                    control = new HtmlInputCheckBox();
                    ((HtmlInputCheckBox)control).Attributes["placeholder"] = property.Name;
                    ((HtmlInputCheckBox)control).Attributes["required"] = "required";
                    ((HtmlInputCheckBox)control).Attributes["class"] = "form-element checkbox";
                    ((HtmlInputCheckBox)control).Attributes["name"] = propertyName;
                    control.ID = propertyName;
                    addControl = true;
                    break;

                case "datetime":
                    control = new TextBox();
                    ((TextBox)control).CssClass = "form-lname form-element large";
                    ((TextBox)control).Attributes["placeholder"] = property.Name;
                    ((TextBox)control).Attributes["required"] = "required";
                    ((TextBox)control).TabIndex = tabIndex;
                    control.ID = propertyName;
                    addControl = true;
                    break;

                case "int32":
                    control = new TextBox();
                    ((TextBox)control).CssClass = "form-lname form-element large";
                    ((TextBox)control).Attributes["placeholder"] = property.Name;
                    ((TextBox)control).Attributes["required"] = "required";
                    ((TextBox)control).Attributes["name"] = propertyName;
                    ((TextBox)control).TabIndex = tabIndex;
                    control.ID = propertyName;
                    addControl = true;
                    break;
            }
            if (addControl) ControlList.Add(control);
        }
    }
    private void AddControlsToHtmlForm()
    {
        Control myPlaceHolder = FindControl("form");
        HtmlControl divContaiunerPpal = (HtmlControl)myPlaceHolder.FindControl("entityControlsContainer");
        foreach (var control in ControlList) {
            HtmlGenericControl divContainer = new HtmlGenericControl("div");
            divContainer.Attributes.Add("class", "column width-6");

            switch (control.GetType().Name) {

                case "HtmlInputCheckBox":
                case "CheckBox":

                    var divWrapperForCheckBox = new HtmlGenericControl("div");
                    divWrapperForCheckBox.Attributes.Add("class", "field-wrapper pt-10 pb-10");
                    divWrapperForCheckBox.Controls.Add(control);
                    divWrapperForCheckBox.Controls.Add(GetAdditionalLabelControlForCheckBox(control.ID));
                    divContainer.Controls.Add(divWrapperForCheckBox);
                    break;

                default:
                    divContainer.Controls.Add(control);
                    break;
                //case "HtmlTextArea":
                //  ((HtmlTextArea)control).Disabled = !enabled;
                //  break;
            }
            divContaiunerPpal.Controls.Add(divContainer);
        }
    }
    private Control GetAdditionalLabelControlForCheckBox(string controlId)
    {
        var labelForCheckBox = new HtmlGenericControl("label");
        labelForCheckBox.Attributes.Add("class", "checkbox-label");
        labelForCheckBox.Attributes.Add("for", UIControlPrefix + GetSimplyName(controlId));
        labelForCheckBox.InnerHtml = GetSimplyName(controlId) + "?";
        return labelForCheckBox;
    } 
    private string GetSimplyName(string controlId)
    {
        return controlId.Substring(controlId.LastIndexOf("_") + 1, controlId.Length - controlId.LastIndexOf("_") - 1);
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

           // entityControl_Name.BorderColor = GrayHtmlColor;
            //entityControl_Surname.BorderColor = GrayHtmlColor;
            //entityControl_Mail.BorderColor = GrayHtmlColor;
            //entityControl_BirthDate.BorderColor = GrayHtmlColor;
            //entityControl_Phone.BorderColor = GrayHtmlColor;
            //entityControl_UserName.BorderColor = GrayHtmlColor;
            //entityControl_Password.BorderColor = GrayHtmlColor;
        }
    private bool IsAuditField(string propertyName)
    {
        return (propertyName.Equals("updated") || propertyName.Equals("created"));
    }
    private string GetAuditFieldValue(PropertyInfo property)
    {
        var createdDate = string.Empty;
        var updateDate = string.Empty;

        FillCreatedUpdatedData(ref createdDate, ref updateDate, property);
        switch (property.Name.ToLower())
        {
            case "created":
                return createdDate;
            case "updated":
                return updateDate;
            default:
                return string.Empty;
        }
    }
    private void FillCreatedUpdatedData(ref string createdDate, ref string updateDate, PropertyInfo property)
    {
        switch (Mode) {
            case ViewMode.Create:
                updateDate = string.Empty;
                createdDate = DateTime.Now.ToString("dd/MM/yyyy");
                break;
            case ViewMode.Edit:

                if(property.Name.ToLower().Equals("created")) {
                    createdDate = property.GetValue(Model).ToString();
                }
                else if(property.Name.ToLower().Equals("updated")) {
                    updateDate = DateTime.Now.ToString("dd/MM/yyyy");
                }
                break;
            case ViewMode.View:

                if (property.Name.ToLower().Equals("created")) {
                    createdDate = (property.GetValue(Model)).ToString();
                }
                else if (property.Name.ToLower().Equals("updated")) {
                    createdDate = (property.GetValue(Model)).ToString();
                }
                break;
        }
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

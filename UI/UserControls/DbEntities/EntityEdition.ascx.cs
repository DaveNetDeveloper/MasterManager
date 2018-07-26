using System;
using System.Collections;
using System.Collections.Generic;
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
        //if(EntityManager.HasEntityRelations((IModelRelations)Model)) {

        //    foreach (var modelTypesList in EntityManager.GetModelTypesFromRelationalEntityList((IModelRelations)Model)) {

        //        // P.E: Si IModel actual es "Alumno" -> su entitdadRelacionada es "ModelAlumnoProducto"
        //        // Tratamiento de los modelos con los que tiene relación el [IModel] actual
        //    }
        //}

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
                                if(IsAuditField(property.Name.ToLower())) {
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

                                fieldValue = property.GetValue(Model);
                                ((TextBox)control).Text = ((Int32)fieldValue).ToString();

                                if (IsPrimaryField(property.Name.ToLower())) {
                                    ((TextBox)control).Enabled = false;
                                    ((TextBox)control).ReadOnly = true;
                                }
                                else if (IsForeingKeyField(property.Name.ToLower())) {
                                    ((TextBox)control).Visible = false;
                                }
                                break;

                            case "list`1":

                                var fieldValueList = (IList)property.GetValue(Model);
                                if(null != fieldValueList && fieldValueList.Count > 0) {
                                    foreach (var field in fieldValueList) {

                                        if (field.GetType().Name.ToLower().Equals("list`1")) {
                                            CreateControlsForRelationalEntityListData(field, control);
                                        }
                                        else {
                                            CreateControlForForeingKeysList(field, control);
                                        }
                                                                            }
                                    if (((HtmlSelect)control).Items.Count > 0) ((HtmlSelect)control).Items[0].Selected = true;
                                } 
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

    private void CreateControlForForeingKeysList(object field, Control control)
    {
        var model = Helpers.HelperModel.CreateNewModelInstanceByType(field.GetType());
        if (null != model) {
            var item = new ListItem();
            item.Value = model.GetType().GetProperties()[1].GetValue(field).ToString();
            item.Text = model.GetType().GetProperties()[2].GetValue(field).ToString();
            item.Selected = false;
            ((HtmlSelect)control).Items.Add(item);
        }
    }

    private void CreateControlsForRelationalEntityListData(object field, Control control)
    {
        foreach (var fieldData in (IEnumerable)field) {
            var model = Helpers.HelperModel.CreateNewModelInstanceByType(fieldData.GetType());
            if (null != model) {
                var item = new ListItem();
                item.Value = model.GetType().GetProperties()[0].GetValue(fieldData).ToString() + " - " + model.GetType().GetProperties()[1].GetValue(fieldData).ToString();
                item.Text = model.GetType().GetProperties()[1].Name + " - " + model.GetType().GetProperties()[2].Name;
                item.Selected = false;
                ((HtmlSelect)control).Items.Add(item);
            }
        }
    }

    public bool IsValidModel() {
        try {
            IModel uiModel = (IModel)CreateNewModelInstance();
            bool validationResult = true;

            foreach (Control c in ControlList) {
                switch (c.GetType().Name) {

                    case "TextBox":

                        if (string.IsNullOrEmpty(((TextBox)c).Text.Trim())) SetControlAsInvalid(((TextBox)c), ref validationResult);
                        else SetPropertyValueIntoInternalModel(((TextBox)c).Text, GetSimplyName(((TextBox)c).ID), uiModel);
                         

                        //if (string.IsNullOrEmpty(entityControl_Phone.Text.Trim()))
                        //    SetControlAsInvalid(entityControl_Surname, ref validationResult);
                        //else
                        //    ((dynamic)uiModel).Phone = Int32.Parse(entityControl_Phone.Text);



                        //if (string.IsNullOrEmpty(entityControl_BirthDate.Text.Trim()))
                        //    SetControlAsInvalid(entityControl_BirthDate, ref validationResult);
                        //else
                        //    ((dynamic)uiModel).BirthDate = HelperDataTypesConversion.GetDateTimeFromText(entityControl_BirthDate.Text,
                        //                                                                      Constants.inputDateTimeFormat_ddmmaaaa,
                        //                                                                      CultureInfo.CurrentCulture);

                         
                        break;
                    case "CheckBox":

                        if (string.IsNullOrEmpty(((TextBox)c).Text.Trim())) SetControlAsInvalid(((TextBox)c), ref validationResult);
                        //else // Asignar valor del control a la propiedad del modelo [uiModel]
                        ((CheckBox)c).BorderColor = GrayHtmlColor;

                        //((dynamic)uiModel).Active = entityControl_Active.Checked;
                        //((dynamic)uiModel).Entered = entityControl_Entered.Checked; 

                        break;
                    case "HtmlInputCheckBox":
                        ((HtmlInputCheckBox)c).Attributes.CssStyle["bordercolor"] = GrayHtmlColor.ToString();

                        //((dynamic)uiModel).Active = entityControl_Active.Checked;
                        //((dynamic)uiModel).Entered = entityControl_Entered.Checked; 

                        break;
                    case "HtmlTextArea":
                        //if (string.IsNullOrEmpty(((HtmlTextArea)c).Value.Trim())) SetControlAsInvalid(((HtmlTextArea)c), ref validationResult);
                        //else SetPropertyValueIntoInternalModel(((HtmlTextArea)c).Value, GetSimplyName(((HtmlTextArea)c).ID), uiModel);
                        break;
                }
            }
            
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
                    //var consulta = "UPDATE USER_ALUMNO SET NAME='" + entityControl_Name.Text + "', surname='" + entityControl_Surname.Text + "', birth_date='" + UIModel.BirthDate.ToString("yyyy-MM-dd HH:mm:ss") + "', mail='" + entityControl_Mail.Text + "', user_name='" + entityControl_UserName.Text + "', PASSWORD='" + entityControl_Password.Text + "', active=" + active + ", updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', phone=" + entityControl_Phone.Text + " WHERE ID=" + UIModel.Id;
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

    private void SetPropertyValueIntoInternalModel(object value, string propertyName, IModel internalUiModel)
    {
        foreach (var modelProperty in internalUiModel.GetType().GetProperties()) {

            if (propertyName.ToLower().Equals(modelProperty.Name.ToLower())) {
                modelProperty.SetValue(internalUiModel, value);
            }
        }
    }
    private bool IsPrimaryField(string propertyLowerName)
    {
        return propertyLowerName.Equals("id");
    }
    private bool IsForeingKeyField(string propertyLowerName)
    {
        foreach (var item in Model.FkInputRelationsList) {
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
        foreach (var modelProperty in Model.GetType().GetProperties()) {
            if (propertyName.ToLower().Equals(modelProperty.Name.ToLower())) return modelProperty; 
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
    private Object CreateNewModelInstanceByType(Type _type)
    {
        var bussinesAssembly = Assembly.GetAssembly(_type);
        ObjectHandle handle = Activator.CreateInstance(bussinesAssembly.GetName().Name, _type.Name);
        Object modelInstance = handle.Unwrap();
        return modelInstance;
    }
    private void CreateControls()
    {
        short tabIndex = 0; 
        foreach (PropertyInfo property in EntityManager.TypedBO.ModelLayerType.GetProperties()) {
            
            string type = property.PropertyType.Name.ToLower();
            var interfacesImplemented = ((TypeInfo)property.PropertyType).ImplementedInterfaces;
            foreach (var implementedInterface in ((TypeInfo)property.PropertyType).ImplementedInterfaces) {

                if (implementedInterface.Name.Equals(typeof(IModel).Name)) {
                    type = typeof(IModel).Name;
                    break;
                }
                if (implementedInterface.Name.Equals(typeof(IList).Name)) {
                    // TODO: pendiente determinar el tipo de la colección, para descartar las listas que no seas colecciones de entidades reales
                    //       Excluir la lista de claves foraneas? (no crear control)
                    var listFKType = new List<ModelDataBaseFKRelation>().GetType().Name; 
                    if (property.PropertyType.Name.Equals(listFKType)) {
                        type = typeof(IList).Name;
                        break;
                    } 
                }
            }

            Control control = null;
            bool addControl = false;
            var propertyName = UIControlPrefix + property.Name;
            tabIndex++;

            switch (type) {
                case "string":
                    control = new TextBox { ID = propertyName };
                    ((TextBox)control).CssClass = "form-lname form-element large";
                    ((TextBox)control).Attributes["placeholder"] = property.Name;
                    ((TextBox)control).Attributes["required"] = "required";
                    ((TextBox)control).Attributes["name"] = propertyName;
                    ((TextBox)control).TabIndex = tabIndex;
                    SetSpecialTextBoxMode(property, control); 
                    addControl = true;
                    break;

                case "boolean":
                    control = new HtmlInputCheckBox { ID = propertyName }; 
                    ((HtmlInputCheckBox)control).Attributes["placeholder"] = property.Name;
                    ((HtmlInputCheckBox)control).Attributes["required"] = "required";
                    ((HtmlInputCheckBox)control).Attributes["class"] = "form-element checkbox";
                    ((HtmlInputCheckBox)control).Attributes["name"] = propertyName; 
                    addControl = true;
                    break;

                case "datetime":
                    control = new TextBox { ID = propertyName };
                    ((TextBox)control).CssClass = "form-lname form-element large";
                    ((TextBox)control).Attributes["placeholder"] = property.Name;
                    ((TextBox)control).Attributes["required"] = "required";
                    ((TextBox)control).TabIndex = tabIndex;
                    ((TextBox)control).TextMode = TextBoxMode.DateTime;
                    SetSpecialTextBoxMode(property, control); 
                    addControl = true;
                    break;

                case "int32":
                    control = new TextBox { ID = propertyName };
                    ((TextBox)control).CssClass = "form-lname form-element large";
                    ((TextBox)control).Attributes["placeholder"] = property.Name;
                    ((TextBox)control).Attributes["required"] = "required";
                    ((TextBox)control).Attributes["name"] = propertyName;
                    ((TextBox)control).TabIndex = tabIndex;
                    
                    addControl = true;
                    break;

                case "IModel": 
                    //TODO
                    break;
                    
                case "IList":

                    control = new HtmlSelect { ID = propertyName };
                    ((HtmlSelect)control).Name = propertyName;
                    ((HtmlSelect)control).Attributes["class"] = "form-aux";
                    ((HtmlSelect)control).Attributes["data-label"] = "Options";
                    addControl = true;
                    break;
            }
            if (addControl) ControlList.Add(control);
        }
    }

    private static void SetSpecialTextBoxMode(PropertyInfo property, Control control)
    {
        //if (property.Name.ToLower().Contains("password")) ((TextBox)control).TextMode = TextBoxMode.Password;
        if (property.Name.ToLower().Contains("mail")) ((TextBox)control).TextMode = TextBoxMode.Email;
        if (property.Name.ToLower().Contains("phone")) ((TextBox)control).TextMode = TextBoxMode.Phone;
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

                case "HtmlSelect":
                    var divWrapperForSelectOptions = new HtmlGenericControl("div");
                    divWrapperForSelectOptions.Attributes.Add("class", "form-select form-element large");
                    divWrapperForSelectOptions.Controls.Add(control);
                    divContainer.Controls.Add(divWrapperForSelectOptions);
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

        FillAuditFieldData(ref createdDate, ref updateDate, property);
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
    private void FillAuditFieldData(ref string createdDate, ref string updateDate, PropertyInfo property)
    {
        switch (Mode) {
            case ViewMode.Create:
                updateDate = string.Empty;
                createdDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                break;
            case ViewMode.Edit:

                if(property.Name.ToLower().Equals("created")) {
                    createdDate = ((DateTime)property.GetValue(Model)).ToString("MM/dd/yyyy HH:mm:ss");
                }
                else if(property.Name.ToLower().Equals("updated")) {
                    updateDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                }
                break;
            case ViewMode.View:

                if (property.Name.ToLower().Equals("created")) {
                    createdDate = ((DateTime)(property.GetValue(Model))).ToString("MM/dd/yyyy HH:mm:ss");
                }
                else if (property.Name.ToLower().Equals("updated")) {
                    createdDate = ((DateTime)(property.GetValue(Model))).ToString("MM/dd/yyyy HH:mm:ss");
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
        else {
            // TODO Alerta --> revisar los campos no válidos
        }
    }

    #endregion
}

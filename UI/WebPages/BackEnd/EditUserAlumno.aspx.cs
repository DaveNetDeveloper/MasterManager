﻿using System;
using System.Web.UI.WebControls;
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
                var aux = EntityManager.GetEntity(EntityManager.EntityType.UsuarioAlumno);
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
                Title = "Edición de alumno";
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

    #endregion

    #region [ Methods ]

    public void GetPrimaryKey()
    {
        if (Request.QueryString["Id"] != null)
        {
            PrimaryKey = Request.QueryString["Id"].ToString();
        } 
    }
    public void GetMode()
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
            privateUserActive.Enabled = enabled;

            privateUserEntered.Enabled = false;
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
            privateUserName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
           // privateUserSurname.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserMail.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserBirthDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserPhone.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserUserName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            privateUserPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
            

            if (string.IsNullOrEmpty(privateUserName.Text.Trim()))
            {
                validationResult = false;
                privateUserName.BorderColor = System.Drawing.Color.Red;
                privateUserName.BorderWidth = new Unit(1);
            }

            /*if (string.IsNullOrEmpty(privateUserSurname.Text.Trim()))
            {
                validationResult = false;
                privateUserSurname.BorderColor = System.Drawing.Color.Red;
                privateUserSurname.BorderWidth = new Unit(1);
            }*/

            if (string.IsNullOrEmpty(privateUserMail.Text.Trim()))
            {
                validationResult = false;
                privateUserMail.BorderColor = System.Drawing.Color.Red;
                privateUserMail.BorderWidth = new Unit(1);
            }
             
            if (string.IsNullOrEmpty(privateUserBirthDate.Text.Trim()))
            {
                validationResult = false;
                privateUserBirthDate.BorderColor = System.Drawing.Color.Red;
                privateUserBirthDate.BorderWidth = new Unit(1);
            }
            
            if (string.IsNullOrEmpty(privateUserPhone.Text.Trim()))
            {
                validationResult = false;
                privateUserPhone.BorderColor = System.Drawing.Color.Red;
                privateUserPhone.BorderWidth = new Unit(1);
            }
            
            if (string.IsNullOrEmpty(privateUserUserName.Text.Trim()))
            {
                validationResult = false;
                privateUserUserName.BorderColor = System.Drawing.Color.Red;
                privateUserUserName.BorderWidth = new Unit(1);
            }
             
            if (string.IsNullOrEmpty(privateUserPassword.Text.Trim()))
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
    //public IModel GetModel()
    //{ 
    //    return new ModelUsuarioAlumno();
    //}
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
                case ViewMode.Create:

                    _id = Entity.GetNextPrimaryKey();
                    consulta = "INSERT INTO USER_ALUMNO(id, NAME, surname, birth_date, mail, user_name, PASSWORD, entered, active, created, updated, phone) VALUES(" + _id + ",'" + privateUserName.Text + "','" + privateUserSurname.Text + "','" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + privateUserMail.Text + "','" + privateUserUserName.Text + "','" + privateUserPassword.Text + "', 0, " + active + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', null, " + privateUserPhone.Text + ")";

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
            UIModel = GetModelFromForm();
            SaveModel(UIModel);
        }
    }

    #endregion
}
using System;
using System.Web.UI;

public class BaseUC : UserControl
{
    #region [ public properties ]

    public EntityManager EntityManager
    {
        get {
            try {
                if (Session["EntityManager"] == null) Session["EntityManager"] = new EntityManager();
                return (EntityManager)Session["EntityManager"];
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }

    public IEntity Entity
    {
        get {
            try {
                if (Session["Entity"] == null) Session["Entity"] = EntityManager.GetEntity();
                return (IEntity)Session["Entity"];
            }
            catch (Exception ex) {
                throw ex;
            }
        } 
        set {
            Session["Entity"] = value;
        }
    }
    public BussinesTypedObject.BussinesObjectTypeEnum BussinesObject { get; set; }

    #endregion

    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack) EntityManager.InitializeTypes(BussinesObject);
    }

    protected void ErrorTreatment(Exception ex)
    {
        Session["error"] = ex;
        //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "FillCenter()", ex.Message, DateTime.Now, 1);
        //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
    }
}
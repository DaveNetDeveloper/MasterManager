using BussinesTypedObject;
using System;
using System.Web.UI;

public class BaseUC : UserControl
{
    #region [ public properties ]

    public BussinesTypes.BussinesObjectTypeEnum BussinesObject { get; set; }
    public BussinesTypes.ProyectNameEnum ProyectName;

    public EntityManager EntityManager
    {
        get {
            try {
                if (Session["EntityManager"] == null) Session["EntityManager"] = new EntityManager(ProyectName);
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

    #endregion

    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack) EntityManager.InitializeTypes(BussinesObject, ProyectName);
    }

    protected void ErrorTreatment(Exception ex)
    {
        Session["error"] = ex;
        //this.SetLOG("ERROR", "Loading Page", "EditUserContact.aspx", "Center", "FillCenter()", ex.Message, DateTime.Now, 1);
        //Response.Redirect(Constantes.PAGE_TITLE_ERROR_PAGE + Constantes.ASP_PAGE_EXTENSION);
    }
}
using System;
using System.Collections.Generic;
using System.Web.Services;
  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(true)]
[System.Web.Script.Services.ScriptService] 
public class wsVisitante : WebService 
{ 
    [WebMethod(EnableSession = true)]
    public IModel GetById(ModelVisitante pArea)
    {
        IModel visitante = null; 
        try
        {
             if(null != pArea)
             {
                IEntity eVisitante = new EntityVisitante();
                visitante = eVisitante.GetById(pArea.Id);
             }
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return visitante;
    }

    [WebMethod(EnableSession = true)]
    public IEnumerable<IModel> GetAllAreas()
    { 
        IEnumerable<IModel> listVisitantes = null;
        try
        {
            IEntity eVisitante = new EntityVisitante();
            listVisitantes = eVisitante.GetList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return listVisitantes;
    }

    [WebMethod(EnableSession = true)]
    public bool EliminarAreaById(int idArea)
    {
        try
        {
            IEntity eVisitante = new EntityVisitante();
            return eVisitante.RemoveById(idArea);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        } 
    }   

    [WebMethod(EnableSession = true)]
    public bool InsertarArea(string nombreArea)
    {
        try
        {
            IEntity eVisitante = new EntityVisitante();
            return eVisitante.Insert(nombreArea);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public bool UpdateAreaById(int idArea, string nombreArea)
    {
        try
        {
            IEntity eVisitante = new EntityVisitante();
            return eVisitante.UpdateById(idArea, nombreArea);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}

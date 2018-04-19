using System;
using System.Collections.Generic;
using System.Web.Services;
  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(true)]
[System.Web.Script.Services.ScriptService] 
public class wsAreas : WebService 
{
    IEntity entityAreas = new EntityArea();
     
    [WebMethod(EnableSession = true)]
    public IModel GetById(ModelArea pArea)
    {
        try
        {
            return entityAreas.GetById(pArea.Id);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        } 
    }

    [WebMethod(EnableSession = true)]
    public IEnumerable<IModel> GetAllAreas()
    { 
        try
        {
            return entityAreas.GetList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public bool EliminarAreaById(int idArea)
    {
        try
        {
            return entityAreas.RemoveById(idArea);
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
            return entityAreas.Insert(nombreArea);
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
            return entityAreas.UpdateById(idArea, nombreArea);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

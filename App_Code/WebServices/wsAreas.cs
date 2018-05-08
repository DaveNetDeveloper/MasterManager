using System;
using System.Collections.Generic;
using System.Web.Services;
  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(true)]
[System.Web.Script.Services.ScriptService] 
public class WsAreas : WebService, IWsEntity
{
    IEntity entityAreas = new EntityArea();
     
    [WebMethod(EnableSession = true)]
    //public IModel GetById(IModel pModel)
    public IModel GetById(ModelArea pModel)
    {
        try
        {
            return entityAreas.GetById(pModel.Id);
        }
        catch(Exception)
        {
            throw;
        } 
    }

    [WebMethod(EnableSession = true)]
    public IEnumerable<IModel> GetAll()
    { 
        try
        {
            return entityAreas.GetList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public bool EliminarById(int pKValue)
    {
        try
        {
            return entityAreas.RemoveById(pKValue);
        }
        catch (Exception)
        {
            throw;
        }
    }   

    [WebMethod(EnableSession = true)]
    public bool Insertar(string nombre)
    {
        try
        {
            return entityAreas.Insert(nombre);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public bool UpdateById(int pKValue, string nombre)
    {
        try
        {
            return entityAreas.UpdateById(pKValue, nombre);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
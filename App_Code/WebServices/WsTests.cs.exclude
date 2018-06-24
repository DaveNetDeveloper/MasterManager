using System;
using System.Collections.Generic;
using System.Web.Services;
  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(true)]
[System.Web.Script.Services.ScriptService] 
public class WsTests : WebService, IWsEntity
{
    IEntity entityTests = new EntityTest();
     
    [WebMethod(EnableSession = true)]
    public IModel GetByPrimaryKey(IModel pModel)
    {
        try
        {
            return entityTests.GetByPrimaryKey(pModel.Id);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        } 
    }

    [WebMethod(EnableSession = true)]
    public IEnumerable<IModel> GetAll()
    { 
        try
        {
            return entityTests.GetList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public bool EliminarById(int pKValue)
    {
        try
        {
            return entityTests.RemoveByPrimaryKey(pKValue);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        } 
    }

    [WebMethod(EnableSession = true)]
    public bool Insertar(string nombre)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public bool UpdateById(int pKValue, string nombre)
    {
        try
        {
            return entityTests.UpdateByPrimaryKey(pKValue, nombre);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
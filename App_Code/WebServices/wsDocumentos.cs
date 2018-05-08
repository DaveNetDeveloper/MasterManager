using System;
using System.Collections.Generic;
using System.Web.Services;
  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(true)]
[System.Web.Script.Services.ScriptService] 
public class WsDocumentos : WebService , IWsEntity
{
    IEntity entityDocumentos = new EntityDocumento();
     
    [WebMethod(EnableSession = true)]
    public IModel GetById(IModel pModel)
    {
        try
        {
            return entityDocumentos.GetById(pModel.Id);
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
            return entityDocumentos.GetList();
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
            return entityDocumentos.RemoveById(pKValue);
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
            return entityDocumentos.Insert(nombre);
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
            return entityDocumentos.UpdateById(pKValue, nombre);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
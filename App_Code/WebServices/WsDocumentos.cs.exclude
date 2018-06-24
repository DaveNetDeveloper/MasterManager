using System;
using System.Collections.Generic;
using System.Web.Services;
  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(true)]
[System.Web.Script.Services.ScriptService] 
public class WsDocumentos : WebService , IWsEntity
{
    IEntity entityDocumentos = new EntityDocumento(typeof(ModelUsuarioAlumno));
     
    [WebMethod(EnableSession = true)]
    public IModel GetByPrimaryKey(IModel pModel)
    {
        try
        {
            return entityDocumentos.GetByPrimaryKey(pModel.Id);
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
            return entityDocumentos.RemoveByPrimaryKey(pKValue);
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
            return entityDocumentos.UpdateByPrimaryKey(pKValue, nombre);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
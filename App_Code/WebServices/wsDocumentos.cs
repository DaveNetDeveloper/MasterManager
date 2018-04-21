using System;
using System.Collections.Generic;
using System.Web.Services;
  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(true)]
[System.Web.Script.Services.ScriptService] 
public class wsDocumentos : WebService 
{
    IEntity entityDocumentos = new EntityDocumento();
     
    [WebMethod(EnableSession = true)]
    public IModel GetById(ModelDocumento pDocumento)
    {
        try
        {
            return entityDocumentos.GetById(pDocumento.Id);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        } 
    }

    [WebMethod(EnableSession = true)]
    public IEnumerable<IModel> GetAllDocumentos()
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
    public bool EliminarDocumentoById(int idDocumento)
    {
        try
        {
            return entityDocumentos.RemoveById(idDocumento);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        } 
    }   

    [WebMethod(EnableSession = true)]
    public bool InsertarDocumento(string nombreDocumento)
    {
        try
        {
            return entityDocumentos.Insert(nombreDocumento);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public bool UpdateDocumentoById(int idDocumento, string nombreDocumento)
    {
        try
        {
            return entityDocumentos.UpdateById(idDocumento, nombreDocumento);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
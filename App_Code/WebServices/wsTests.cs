using System;
using System.Collections.Generic;
using System.Web.Services;
  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(true)]
[System.Web.Script.Services.ScriptService] 
public class wsTests : WebService
{
    IEntity entityTests = new EntityTest();
     
    [WebMethod(EnableSession = true)]
    public IModel GetById(ModelTest pTest)
    {
        try
        {
            return entityTests.GetById(pTest.Id);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        } 
    }

    [WebMethod(EnableSession = true)]
    public IEnumerable<IModel> GetAllTests()
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
    public bool EliminarTestById(int idTest)
    {
        try
        {
            return entityTests.RemoveById(idTest);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        } 
    }   

    [WebMethod(EnableSession = true)]
    public bool InsertarTest(string nombreTest)
    {
        try
        {
            return entityTests.Insert(nombreTest);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public bool UpdateTestById(int idTest, string nombreTest)
    {
        try
        {
            return entityTests.UpdateById(idTest, nombreTest);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
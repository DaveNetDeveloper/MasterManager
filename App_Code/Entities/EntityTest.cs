using System.Collections.Generic;

public class EntityTest : IEntity
{
    private DAOTests _daoTests;

    public EntityTest()
    {
        _daoTests = new DAOTests();
    }

    public IModel GetById(int id)
    {   
        return _daoTests.GetById(id); 
    }

    public IEnumerable<IModel> GetList()
    {
        return _daoTests.GetList();
    }

    public bool RemoveById(int id)
    {
        return _daoTests.RemoveById(id);
    }

    public bool Insert(string nombre)
    {
        return _daoTests.Insert(nombre);
    }

    public bool UpdateById(int id, string nombre)
    {
        return _daoTests.UpdateById(id, nombre);
    }
}
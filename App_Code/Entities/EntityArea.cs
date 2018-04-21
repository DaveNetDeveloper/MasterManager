using System.Collections.Generic;

public class EntityArea : IEntity
{
    private DAOAreas _daoAreas;

    public EntityArea()
    {
        _daoAreas = new DAOAreas();
    }

    public IModel GetById(int id)
    {   
        return _daoAreas.GetById(id); 
    }

    public IEnumerable<IModel> GetList()
    {
        return _daoAreas.GetList();
    }

    public bool RemoveById(int id)
    {
        return _daoAreas.RemoveById(id);
    }
 
    public bool Insert(string nombre)
    {
        return _daoAreas.Insert(nombre);
    }

    public bool UpdateById(int id, string nombre)
    {
        return _daoAreas.UpdateById(id, nombre);
    }
}
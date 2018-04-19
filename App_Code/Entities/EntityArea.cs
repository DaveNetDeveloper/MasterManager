using System.Collections.Generic;

public class EntityArea : IEntity
{
    private DAAreas _dalAreas;

    public EntityArea()
    {
        _dalAreas = new DAAreas();
    }

    public IModel GetById(int id)
    {   
        return _dalAreas.GetById(id); 
    }

    public IEnumerable<IModel> GetList()
    {
        return _dalAreas.GetList();
    }

    public bool RemoveById(int id)
    {
        return _dalAreas.RemoveById(id);
    }
 
    public bool Insert(string nombre)
    {
        return _dalAreas.Insert(nombre);
    }

    public bool UpdateById(int id, string nombre)
    {
        return _dalAreas.UpdateById(id, nombre);
    }
}
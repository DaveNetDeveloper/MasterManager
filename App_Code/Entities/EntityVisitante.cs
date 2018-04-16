using System.Collections.Generic;

public class EntityVisitante : IEntity
{
    private DALVisitante _dalVisitante;

    public EntityVisitante()
    {
        _dalVisitante = new DALVisitante();
    }

    public IModel GetById(int idArea)
    {   
        return _dalVisitante.GetVisitante(idArea); 
    }

    public IEnumerable<IModel> GetList()
    {
        return _dalVisitante.GetList();
    }

    public bool RemoveById(int idArea)
    {
        return _dalVisitante.RemoveById(idArea);
    }
 
    public bool Insert(string nombreArea)
    {
        return _dalVisitante.Insert(nombreArea);
    }

    public bool UpdateById(int idArea, string nombreArea)
    {
        return _dalVisitante.UpdateById(idArea, nombreArea);
    }
}
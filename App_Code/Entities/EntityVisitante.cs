using System.Collections.Generic;

public class EntityVisitante : IEntity
{
    private DALVisitante _dalVisitante;

    public EntityVisitante()
    {
        _dalVisitante = new DALVisitante();
    }

    public IModel GetById(int Id)
    {   
        return _dalVisitante.GetVisitante(Id); 
    }

    public IEnumerable<IModel> GetList()
    {
        return _dalVisitante.GetList();
    }

    public bool RemoveById(int Id)
    {
        return _dalVisitante.RemoveById(Id);
    }
 
    public bool InsertarArea(string nombreArea)
    {
        return _dalVisitante.InsertarArea(nombreArea);
    }
}
using System.Collections.Generic; 

public interface IEntity
{
    IModel GetById(int id);
    IEnumerable<IModel> GetList();
    bool RemoveById(int id);
    bool InsertarArea(string nombreArea);
}
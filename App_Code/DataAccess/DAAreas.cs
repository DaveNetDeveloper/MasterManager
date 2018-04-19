using System;
using System.Collections.Generic; 

public class DAAreas : DbAccess
{ 
    public IModel GetById(int Id)
    {
        IModel area = null;
        QuerySql = String.Format("SELECT * FROM AREA WHERE ID = {0} ", Id);
        DbConnection = ExecuteDataReader();
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                area = new ModelArea(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
            }
        }
        DbConnection.Close();
        return area;
    }

    public IEnumerable<IModel> GetList()
    { 
        List<IModel> areasList = null;

        QuerySql = " SELECT * FROM AREA ORDER BY ID ";
        DbConnection = ExecuteDataReader();
         
        if (!DrData.IsClosed)
        {
            areasList = new List<IModel>();
            while (DrData.Read())
            {
                IModel area = new ModelArea(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                areasList.Add(area);
            }
        }
        DbConnection.Close();
        return areasList; 
    }

    public bool RemoveById(int Id)
    {
        QuerySql = String.Format("DELETE FROM AREA WHERE ID = {0}", Id);
        return ExecuteNonQuery().Equals(1);
    }

    public bool Insert(string nombreArea)
    {
        QuerySql = String.Format("INSERT INTO AREA (Nombre, Descripción, Responsable) VALUES('{0}', '{1}', '{2}')", nombreArea, "Descripción del area", "xxxx@biosystems.es");
        return ExecuteNonQuery().Equals(1);
    }

    public bool UpdateById(int Id, string nombreArea)
    {
        QuerySql = String.Format("UPDATE AREA SET Nombre = '{0}' WHERE ID = {1}", nombreArea, Id);
        return ExecuteNonQuery().Equals(1);
    }
}


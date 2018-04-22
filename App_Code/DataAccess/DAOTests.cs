using System;
using System.Collections.Generic; 

public class DAOTests : DbAccess
{ 
    public IModel GetById(int Id)
    {
        IModel test = null;
        QuerySql = String.Format("SELECT * FROM TEST WHERE ID = {0} ", Id);
        DbConnection = ExecuteDataReader();
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                //test = new ModelTest(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                test = new ModelTest();
            }
        }
        DbConnection.Close();
        return test;
    }

    public IEnumerable<IModel> GetList()
    { 
        List<IModel> testsList = null;

        QuerySql = " SELECT * FROM TEST ORDER BY ID ";
        DbConnection = ExecuteDataReader();
         
        if (!DrData.IsClosed)
        {
            testsList = new List<IModel>();
            while (DrData.Read())
            {
                IModel test = new ModelTest();// DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                testsList.Add(test);
            }
        }
        DbConnection.Close();
        return testsList; 
    }

    public bool RemoveById(int Id)
    {
        QuerySql = String.Format("DELETE FROM TEST WHERE ID = {0}", Id);
        return ExecuteNonQuery();
    }

    public bool Insert(string nombreTest)
    {
        QuerySql = String.Format("INSERT INTO TEST (Nombre, Descripción, Responsable) VALUES('{0}', '{1}', '{2}')", nombreTest, "Descripción del test", "xxxx@biosystems.es");
        return ExecuteNonQuery();
    }

    public bool UpdateById(int Id, string nombreTest)
    {
        QuerySql = String.Format("UPDATE TEST SET Nombre = '{0}' WHERE ID = {1}", nombreTest, Id);
        return ExecuteNonQuery();
    }
}


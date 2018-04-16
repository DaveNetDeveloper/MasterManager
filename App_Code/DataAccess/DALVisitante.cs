using System;
using System.Collections.Generic; 
using MySql.Data.MySqlClient; 

public class DALVisitante : DbAccess
{
    MySqlDataReader drVisitantes = null;
    MySqlConnection mySqlConnection = null;
     
    public IModel GetById(int Id)
    {
        IModel visitante = null;
        string querySql = String.Format("SELECT * FROM AREA WHERE ID = {0} ", Id);
        mySqlConnection = base.ExecuteDataReader(querySql, ref drVisitantes);
        if (!drVisitantes.IsClosed)
        {
            while (drVisitantes.Read())
            {
                visitante = new ModelVisitante(drVisitantes.GetInt32(0), drVisitantes.GetString(1), (drVisitantes.IsDBNull(2)) ? string.Empty : drVisitantes.GetString(2), drVisitantes.GetString(3));
            }
        }
        mySqlConnection.Close();
        return visitante;
    }

    public IEnumerable<IModel> GetList()
    {
        IModel visitante;
        List<IModel> visitantesList = null;

        string querySql = " SELECT * FROM AREA ORDER BY ID ";
        mySqlConnection = base.ExecuteDataReader(querySql, ref drVisitantes);
         
        if (!drVisitantes.IsClosed)
        {
            visitantesList = new List<IModel>();
            while (drVisitantes.Read())
            {
                visitante = new ModelVisitante(drVisitantes.GetInt32(0), drVisitantes.GetString(1), (drVisitantes.IsDBNull(2)) ? string.Empty : drVisitantes.GetString(2), drVisitantes.GetString(3));
                visitantesList.Add(visitante);
            }
        }
        mySqlConnection.Close();
        return visitantesList; 
    }

    public bool RemoveById(int Id)
    {
        string querySql = String.Format("DELETE FROM AREA WHERE ID = {0}", Id);
        return base.ExecuteNonQuery(querySql) == 1;
    }

    public bool Insert(string nombreArea)
    {
        string querySql = String.Format("INSERT INTO AREA (Nombre, Descripción, Responsable) VALUES('{0}', '{1}', '{2}')", nombreArea, "Descripción del area", "xxxx@biosystems.es");
        return base.ExecuteNonQuery(querySql) == 1;
    }

    public bool UpdateById(int Id, string nombreArea)
    {
        string querySql = String.Format("UPDATE AREA SET Nombre = '{0}' WHERE ID = {1}", nombreArea, Id);
        return base.ExecuteNonQuery(querySql) == 1;
    }
    
}


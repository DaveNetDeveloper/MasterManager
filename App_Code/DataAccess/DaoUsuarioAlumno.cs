﻿using System.Collections.Generic; 

public class DaoUsuarioAlumno : DbAccess, IDaoEntity
{
    public DaoUsuarioAlumno()
    {
        TableName = "user_alumno";
    }
     
    public IModel GetById(int id)
    {
        QuerySql = "SELECT * FROM @TableName WHERE ID = @Id";
        AddNewParameter("Id", id);
        AddNewParameter("TableName", TableName);

        DbConnection = ExecuteDataReader();
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                Model = new ModelArea(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
            }
        }
        DbConnection.Close();
        MySqlParametersList.Clear();
        return Model;
    }
    public IEnumerable<IModel> GetList()
    { 
        QuerySql = "SELECT * FROM @TableName ORDER BY ID";
        AddNewParameter("TableName", TableName);

        DbConnection = ExecuteDataReader();
        if (!DrData.IsClosed)
        {
            ModelList = new List<IModel>();
            while (DrData.Read())
            {
                IModel area = new ModelArea(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                ModelList.Add(area);
            }
        }
        DbConnection.Close();
        return ModelList; 
    }
    public bool RemoveById(int id)
    {
        QuerySql = "DELETE FROM @TableName WHERE ID = @Id";
        AddNewParameter("Id", id);
        AddNewParameter("TableName", TableName);

        return ExecuteNonQuery();
    }
    public bool Insert(string nombre, string texto2, string texto3)
    {
        QuerySql = "INSERT INTO @TableName (Nombre, Descripción, Responsable) VALUES( @NombreArea, @Descripción, @Responsable)";
        AddNewParameter("NombreArea", nombre);
        AddNewParameter("Descripción", texto2);
        AddNewParameter("Responsable", texto3);
        AddNewParameter("TableName", TableName);

        return ExecuteNonQuery();
    }
    public bool UpdateById(int id, string nombre)
    {
        QuerySql = "UPDATE @TableName SET Nombre = @NombreArea WHERE ID = @Id";
        AddNewParameter("Id", id);
        AddNewParameter("NombreArea", nombre);
        AddNewParameter("TableName", TableName);

        return ExecuteNonQuery();
    }
}
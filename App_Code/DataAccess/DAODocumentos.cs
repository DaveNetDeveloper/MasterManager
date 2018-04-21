﻿using System;
using System.Collections.Generic; 

public class DAODocumentos : DbAccess
{ 
    public IModel GetById(int id)
    {
        IModel documento = null;
        QuerySql = String.Format("SELECT * FROM DOCUMENTO WHERE ID = {0} ", id);
        DbConnection = ExecuteDataReader();
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                documento = new ModelDocumento(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3), DrData.GetString(7));
            }
        }
        DbConnection.Close();
        return documento;
    }

    public IEnumerable<IModel> GetList()
    { 
        List<IModel> documentosList = null;

        QuerySql = " SELECT * FROM DOCUMENTO ORDER BY ID ";
        DbConnection = ExecuteDataReader();
         
        if (!DrData.IsClosed)
        {
            documentosList = new List<IModel>();
            while (DrData.Read())
            {
                IModel documento = new ModelDocumento(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3), DrData.GetString(7));
                documentosList.Add(documento);
            }
        }
        DbConnection.Close();
        return documentosList; 
    }

    public bool RemoveById(int id)
    {
        QuerySql = String.Format("DELETE FROM DOCUMENTO WHERE ID = {0}", id);
        return ExecuteNonQuery();
    }

    public bool Insert(string nombreDocumento)
    {
        QuerySql = String.Format("INSERT INTO DOCUMENTO (Nombre, Descripción, Responsable) VALUES('{0}', '{1}', '{2}')", nombreDocumento, "Descripción del documento", " ");
        return ExecuteNonQuery();
    }

    public bool UpdateById(int id, string nombreDocumento)
    {
        QuerySql = String.Format("UPDATE DOCUMENTO SET Nombre = '{0}' WHERE ID = {1}", nombreDocumento, id);
        return ExecuteNonQuery();
    }
}


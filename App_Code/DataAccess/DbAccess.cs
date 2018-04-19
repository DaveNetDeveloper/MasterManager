using MySql.Data.MySqlClient;
using System;
using System.Configuration;

public class DbAccess : IDbAccess
{
    public String QuerySql { get; set; }
    public MySqlDataReader DrData { get; set; }
    public MySqlConnection DbConnection { get; set; }

    private MySqlCommand Command { get; set; }
    private string ConnectionString
    {
        get
        {
            return string.Empty;
        }
    }
    private string Connection_biointranet
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["Connection_biointranet"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;
        }
    }

    public MySqlConnection ExecuteDataReader()
    {
        DbConnection = new MySqlConnection(Connection_biointranet);
        Command = new MySqlCommand(QuerySql, DbConnection);

        DbConnection.Open();
        DrData = Command.ExecuteReader();
        return (DrData != null) ? DbConnection : null;
    }

    public bool ExecuteNonQuery()
    {
        DbConnection = new MySqlConnection(Connection_biointranet);
        Command = new MySqlCommand(QuerySql, DbConnection);

        DbConnection.Open();
        int affectedRecords = Command.ExecuteNonQuery();
        DbConnection.Close();
        return affectedRecords > 0; ;
    }
}
using MySql.Data.MySqlClient;
using System.Configuration;

public class DbAccess : IDbAccess
{
    public string Connection_biointranet
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["Connection_biointranet"].ConnectionString;
        }
    }

    public string Connection_qsg265
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;
        }
    }

    public MySqlConnection ExecuteDataReader(string querySql, ref MySqlDataReader mySqlDataReader)
    { 
        MySqlConnection connection = new MySqlConnection(Connection_biointranet);
        MySqlCommand command = new MySqlCommand(querySql, connection); 

        connection.Open();
        mySqlDataReader = command.ExecuteReader();
        return connection;
    }

    public int ExecuteNonQuery(string querySql)
    { 
        MySqlConnection connection = new MySqlConnection(Connection_biointranet);
        MySqlCommand command = new MySqlCommand(querySql, connection);

        connection.Open();
        int returnValue = command.ExecuteNonQuery();
        connection.Close();
        return returnValue;
    }
}
using MySql.Data.MySqlClient;

public interface IDbAccess
{  
    string ConnectionString { get; }
    MySqlConnection ExecuteDataReader(string querySql, ref MySqlDataReader mySqlDataReader);
}
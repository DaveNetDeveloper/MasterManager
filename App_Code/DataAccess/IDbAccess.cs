using MySql.Data.MySqlClient;

public interface IDbAccess
{ 
    string Connection_biointranet { get; }
    string Connection_qsg265 { get; }
    MySqlConnection ExecuteDataReader(string querySql, ref MySqlDataReader mySqlDataReader);
}
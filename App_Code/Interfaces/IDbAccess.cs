using MySql.Data.MySqlClient;
using System;

public interface IDbAccess
{  
    String QuerySql { get; set; }
    MySqlDataReader DrData { get; set; }
    MySqlConnection DbConnection { get; set; }

    MySqlConnection ExecuteDataReader();
    bool ExecuteNonQuery();
}
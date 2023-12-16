using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
namespace test
{
    public class Connection
    {
       
        
            public static NpgsqlConnection connection;

            public static void Connectt(string host, string port, string user, string dbName, string password)
            {
                string con = string.Format($"Server={host}; Port={port}; UserId={user}; DataBase={dbName}; Password={password}");
                connection = new NpgsqlConnection(con);
                connection.Open();
            }
            public static NpgsqlCommand GetCommand(string sql)
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                return cmd;
            }
        


    }

}

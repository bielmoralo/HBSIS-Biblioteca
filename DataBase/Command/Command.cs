using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using DataBase.Connection;

namespace DataBase.Command
{
    class Command
    {
        public List<Parameter> parameters = null;

        public static void ExecuteNonQuery(SqlCommand sqlCommand, SqlConnection connection)
        {
            sqlCommand.Connection = connection;

            using (var command = sqlCommand)
            {
                int rowsAffected = command.ExecuteNonQuery();
            }

        }

        public static void ExecuteNonQuery(SqlCommand sqlCommand)
        {
            using (var connection = CoreConnection.GetConnection())
            {
                connection.Open();

                using (var command = sqlCommand)
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        public static DataSet ExecuteReader(string tsql, SqlConnection connection, string srcTable = "Query")
        {

            using (SqlDataAdapter adapter = new SqlDataAdapter(tsql, connection))
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, srcTable);
                return dataSet;
            }

        }
    }
}
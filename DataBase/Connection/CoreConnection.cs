using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DataBase.Connection
{
    public static class CoreConnection
    {
        public static SqlConnection GetConnection()
        {
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = @"(LocalDB)\v11.0";
            cb.AttachDBFilename = @"C:\Users\jaggcost\Downloads\HBSIS2-Biblioteca\HBSIS-Biblioteca\SQL DATABASE\hbsisdb.mdf";
            cb.IntegratedSecurity = true;

            var toReturn = new SqlConnection(cb.ConnectionString);
            toReturn.Open();
            return toReturn;
        }
    }
}
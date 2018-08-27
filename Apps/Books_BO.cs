using Dapper;
using DataBase.Connection;
using DataBase.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Books
{
    public class Books_BO
    {
        public dynamic message;


        public List<Books_DTO> GetAll()
        {
            using (var sqlConnection = CoreConnection.GetConnection())
            {
                return sqlConnection.Query<Books_DTO>("Select *  from Books order by name").ToList();
            }
        }
        public long Create(Books_DTO obj)
        {
            using (var sqlConnection = CoreConnection.GetConnection())
            {
                long toReturn = 0;

                try
                {
                    toReturn = sqlConnection.Execute("Insert into books (name, pages, create_date, update_date,author, quantity) values (@name, @pages, (select getdate()),(select getdate()),@author,@quantity  )", obj);
                }
                catch (Exception ex)
                {
                    message = CoreException.GetMessage(ex.Message);
                }


                if (toReturn > 0)
                {
                    message = "Cadastro realizado com sucesso";
                }

                return toReturn;
            }
        }


        public long Delete(long id)
        {
            using (var sqlConnection = CoreConnection.GetConnection())
            {
                return sqlConnection.Execute("delete from books where id = @id", new { id = id });
            }
        }

        public Books_DTO Get(long id)
        {
            using (var sqlConnection = CoreConnection.GetConnection())
            {
                return sqlConnection.Query<Books_DTO>("Select * from books where id = @id", new { id = id }).SingleOrDefault();
            }

        }

        public long Update(Books_DTO obj)
        {
            long toReturn = 0;

            using (var sqlConnection = CoreConnection.GetConnection())
            {
                try
                {
                    toReturn = sqlConnection.Execute("update books set name = @name, pages = @pages, quantity = @quantity, update_date = (select getdate()) where id = @id", obj);
                }
                catch (Exception ex)
                {
                    message = CoreException.GetMessage(ex.Message);
                }


                if (toReturn > 0)
                {
                    message = "Cadastro realizado com sucesso";
                }

                return toReturn;
            }


        }
    }
}

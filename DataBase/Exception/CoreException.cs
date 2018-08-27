using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataBase.Exception
{

    public class CoreException
    {
        public static string GetMessage(string message)
        {
            string toReturn = "Atenção! ocorreu um erro: " + message;

            if (message.Contains("duplicate key"))
            {
                toReturn = "Atenção! Cadastro já existe, verificar...";
            }

            return toReturn;
        }

    }

}
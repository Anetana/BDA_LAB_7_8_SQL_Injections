using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDA_LAB_7_8_SQL_Injections.Connection_helper
{
    internal class Connection
    {
            public static string GetConnectionString()
            {
                SqlConnectionStringBuilder cnn = new SqlConnectionStringBuilder
                {
                    DataSource = "",
                    InitialCatalog = "",
                    UserID = "",
                    Password = "",
                    TrustServerCertificate = true
                };

                return cnn.ToString();

            }
        }
}

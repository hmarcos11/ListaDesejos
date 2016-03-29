using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Controller
{
    public sealed class ADODBConnection
    {
        private static volatile SqlConnection instance;

        private ADODBConnection()
        {

        }

        public static SqlConnection Connection()
        {
            if (instance == null)
            {
                instance = new SqlConnection("Data Source=(local);Initial Catalog=dblistadesejos;Persist Security Info=True;User ID=sa;Password=lauto99$");
            }
            return instance;
        }


    }
}

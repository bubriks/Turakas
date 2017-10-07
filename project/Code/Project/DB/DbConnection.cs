using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class DbConnection
    {
        private static DbConnection instance;
        private SqlConnection con;
        private SqlTransaction trans = null;
        public static DbConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DbConnection();
            }
            return instance;
        }

        private DbConnection()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-GOARNTN\MSSQLEXPRESS2014;Initial Catalog=ProjectDb;Integrated Security=True");
            con.Open();
        }

        public SqlConnection GetConnection()
        {
            return con;
        }

        public void CloseConnection()
        {
            con.Close();
            instance = null;
        }

        public void StartTransaction()
        {
            if(trans==null)
                trans = con.BeginTransaction();
        }

        public void Commmit()
        {
            trans.Commit();
            trans = null;
        }

        public void RollBack()
        {
            trans.Rollback();
            trans = null;
        }
    }
}

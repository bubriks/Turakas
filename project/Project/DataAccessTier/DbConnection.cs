﻿using System;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DbConnection
    {
        private static DbConnection instance;
        private SqlConnection con;
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
            //the comented out code is for local server
            //con = new SqlConnection(@"Data Source=DESKTOP-GOARNTN\MSSQLEXPRESS2014;Initial Catalog=ProjectDb;Integrated Security=True");
            con = new SqlConnection("Server=kraka.ucn.dk; database=dmaj0916_197331; UID=dmaj0916_197331; password=Password1!");
            con.Open();
        }

        #region Connection
        public SqlConnection GetConnection()
        {
            return con;
        }

        public bool CloseConnection()
        {
            try
            {
                con.Close();
                instance = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
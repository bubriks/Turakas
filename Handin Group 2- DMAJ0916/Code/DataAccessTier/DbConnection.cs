﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DbConnection
    {
        private static DbConnection instance;
        private SqlConnection con = null;
        private SqlTransaction transaction = null;
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
            //con = new SqlConnection(@"Data Source=localhost\MSSQLEXPRESS2014;Initial Catalog=dmaj0916_197331;Integrated Security=True");
            con = new SqlConnection("Server=kraka.ucn.dk; database=dmaj0916_197331; UID=dmaj0916_197331; password=Password1!; MultipleActiveResultSets=True");
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

        #region Transaction
        public SqlTransaction BeginTransaction()
        {
            transaction = con.BeginTransaction(IsolationLevel.RepeatableRead);
            return transaction;
        }

        public SqlTransaction GetTransaction()
        {
            return transaction;
        }
        #endregion
    }
}
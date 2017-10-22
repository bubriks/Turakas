﻿using System;
using System.Data.SqlClient;

namespace DataTier
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
        public bool StartTransaction()
        {
            try
            {
                trans = con.BeginTransaction();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
}

        public bool Commmit()
        {
            try
            {
                trans.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RollBack()
        {
            try
            {
                trans.Rollback();
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
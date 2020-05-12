using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BATMAN.Classes
{
    public class DAL : IDisposable
    {
        SqlConnection sqlConn = null;
        public bool IsConnected { get; private set; }

        public DAL()
        {
            sqlConn = new SqlConnection();

            //replace this with your own connection string
            sqlConn.ConnectionString = @"Server=.\SQLEXPRESS; Integrated Security = True; Database = batmanDB";

            IsConnected = false;
            try
            {
                sqlConn.Open();
                IsConnected = true;
            }
            catch (Exception)
            {
                //report for an occurrence of an error
                throw;
            }
        }

        void IDisposable.Dispose()
        {
            sqlConn.Close();
        }


        //for running stored procs with SELECT statements ( or queries with result set)
        public DataSet ExecuteQuery(string spName, SqlParameter[] param = null)
        {
            using (SqlCommand cmd = new SqlCommand(spName, sqlConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                    cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
        }
        //for only one result
        public object ExecuteQueryScalar(string spName, SqlParameter[] param = null)
        {
            using (SqlCommand cmd = new SqlCommand(spName, sqlConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                    cmd.Parameters.AddRange(param);

                return cmd.ExecuteScalar();
            }
        }


        //for running stored procs with INSERT/UPDATE/DELETE statements (or queries without result set)
        public void ExecuteNonQuery(string spName, SqlParameter[] param = null)
        {
            using (SqlCommand cmd = new SqlCommand(spName, sqlConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                    cmd.Parameters.AddRange(param);

                cmd.ExecuteNonQuery();
            }
        }


    }
}

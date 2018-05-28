using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace askAnything.Models
{
    public static class DAL
    {
        public static DataTable ExecSP(string spName, List<SqlParameter> sqlParams = null)
        {
            string strconnect = "Server=DayaInduMaa-PC\\SQLEXPRESS;Database=askAnything;Trusted_Connection=True;";

            SqlConnection conn = new SqlConnection();

            DataTable dt = new DataTable();

            try
            {
                // Connection to the database
                conn = new SqlConnection(strconnect);
                conn.Open();

                // Build an sql command /query
                SqlCommand cmd = new SqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParams.ToArray());

                // Execute command
                SqlCommand command = conn.CreateCommand();
                SqlDataReader dr = cmd.ExecuteReader();

                // Fill datatable with the results           
                dt.Load(dr);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //No matters what happens this will run
                conn.Close();
            }

            return dt;
        }

    }
}
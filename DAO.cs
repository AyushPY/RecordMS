using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DAO
/// </summary>
public class DAO
{
    public static SqlConnection GetConnection()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["RecordConnection"].ConnectionString);
        if (con.State != System.Data.ConnectionState.Open)
        {
            con.Open();

        }
        return con;
    }
    public static int IUD(string sql, SqlParameter[] param, CommandType cmdType)
    {
        try
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public static DataTable GetTable(string sql, SqlParameter[] param, CommandType cmdType)
    {

        DataTable dt = new DataTable();
        using (SqlConnection con = GetConnection())
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = cmdType;
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
    }
}
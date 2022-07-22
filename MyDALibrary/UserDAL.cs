using Microsoft.Data.SqlClient;
using ModelsLibrary;
using System;
using System.Data;

namespace MyDALibrary
{
    public class UserDAL
    {
        readonly SqlConnection conn;
        public UserDAL()
        {
            conn = Connection.GetConnection().conn;
        }
        public User Login(User user)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("proc_Loginq", conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@username", user.Username);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@password", user.Password);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            DataRow dr = ds.Tables[0].Rows[0];
            return new User()
            {
                Username = dr[0].ToString(),
                Phone = dr[2].ToString(),
                FullName = dr[1].ToString()
            };
        }
    }
}
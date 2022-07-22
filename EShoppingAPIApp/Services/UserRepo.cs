using EShoppingAPIApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EShoppingAPIApp.Services
{
    public class UserRepo 
    {
        SqlConnection conn;
        public UserRepo(IConfiguration configuration)
        {
            string strCon = configuration.GetConnectionString("conn");
            conn = new SqlConnection(strCon);
        }
        public User Register(User item)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", item.Name);
            cmd.Parameters.AddWithValue("@upass", item.Password);
            cmd.Parameters.AddWithValue("@urole", item.Role);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            try
            {
                conn.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result > 0)
                    return item;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public User DeleteUser(string key)
        {
            throw new NotImplementedException();
        }

        public User Login(User item)
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_LoginCheck", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@uname", item.Name);
            da.SelectCommand.Parameters.AddWithValue("@upass", item.Password);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string role = ds.Tables[0].Rows[0][0].ToString();
                item.Role = role;
                return item;
            }
            return null;
        }

        public User UpdatePassword(User item)
        {
            throw new NotImplementedException();
        }
    }
}

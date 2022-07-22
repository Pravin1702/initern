using PizzaApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace PizzaApplication.Services
{
    public class UserRepo
    {
        SqlConnection conn;
        public UserRepo()
        {

        }
        public UserRepo(IConfiguration configuration)
        {
            string strCon = configuration.GetConnectionString("conn");
            conn = new SqlConnection(strCon);
        }

        public User Register(User item)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertUser", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", item.Username);
            cmd.Parameters.AddWithValue("@upass", item.Password);
            cmd.Parameters.AddWithValue("@urole", item.Role);
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
                return item;
            else
                return null;
        }
        public User Login(User user)
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_LoginCheck", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@uname", user.Username);
            da.SelectCommand.Parameters.AddWithValue("@upass", user.Password);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string role = ds.Tables[0].Rows[0][0].ToString();
                user.Role = role;
                return user;
            }
            return null;
        }

    }
}

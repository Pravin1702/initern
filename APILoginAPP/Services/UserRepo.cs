using APILoginAPP.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace APILoginAPP.Services
{
    public class UserRepo : IRepo<string, User>
    {
        SqlConnection conn;
        public UserRepo(IConfiguration configuration)
        {
            string strCon = configuration.GetConnectionString("conn");
            conn = new SqlConnection(strCon);
        }
        public User Add(User item)
        {
            SqlCommand cmd = new SqlCommand("proc_CreateEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ename", item.Name);
            cmd.Parameters.AddWithValue("@epass", item.Password);
            cmd.Parameters.AddWithValue("@erole", item.Role);
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

        public User Delete(string key)
        {
            throw new NotImplementedException();
        }

        public User Get(User item)
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_LoginEmployee", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ename", item.Name);
            da.SelectCommand.Parameters.AddWithValue("@epass", item.Password);
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

        public User Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}

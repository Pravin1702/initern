using MoreADOLibrary;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MoreADODALibrary
{
    public class UserDAL
    {
        SqlConnection conn;
        public UserDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }

        public string Login(User user)
        {
            string role = null;
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "proc_LoginCheck";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.Add("@uname", SqlDbType.VarChar, 20);
            cmdLogin.Parameters.Add("@pass", SqlDbType.VarChar, 20);
            cmdLogin.Parameters.Add("@urole", SqlDbType.VarChar, 20);
            cmdLogin.Parameters[0].Value = user.Username;
            cmdLogin.Parameters[1].Value = user.Password;
            cmdLogin.Parameters[2].Direction = ParameterDirection.Output;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            cmdLogin.ExecuteScalar();
            role = cmdLogin.Parameters[2].Value.ToString();
            conn.Close();
            return role;
        }
        public String DisplayData()
        {
            SqlCommand cmdLogin = new SqlCommand("proc_GetAllProducts");
            cmdLogin.Connection = conn;
            conn.Open();
            SqlDataReader dr = cmdLogin.ExecuteReader();
            while(dr.Read())
            {
                Console.WriteLine("Prodect ID " + dr[0].ToString());
                Console.WriteLine("Prodect Name " + dr[1].ToString());
                Console.WriteLine("QuantityPerUnit " + dr[2].ToString());
                Console.WriteLine("UnitPrice " + dr[3].ToString());
                Console.WriteLine("UnitsInStack " + dr[4].ToString());
                Console.WriteLine();

            }
            conn.Close();
            return null;
        }
    }
}
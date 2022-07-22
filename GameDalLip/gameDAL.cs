using System;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using GameUSerClass;

namespace GameDalLip
{
    public class gamedal
    {
        User u = new User();
        SqlConnection conn;
        public gamedal()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }

        public void InsertUserToTable()
        {
            string word = "noword";
            Console.WriteLine("=====================================================");
            Console.WriteLine("Enter the name ");
            u.Name = Console.ReadLine();
            bool containsInt = u.Name.Any(char.IsDigit);
            if (containsInt)
            {
                Console.WriteLine("Your UserName should not have Numeric characters");
                u.Name = "";
                InsertUserToTable();
            }
            Console.WriteLine("Enter your age ");
            try
            {
                u.Age = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Given Age is Must be number");
                InsertUserToTable();
            }
            u.Password = u.Name + "" + u.Age;
            u.Id = 101 + Loginid();
            Console.WriteLine("Welcome your password is your name and age together (" + u.Password +")");
            Console.WriteLine("your id is " + u.Id);
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "proc_getuser";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.AddWithValue("@uid", u.Id);
            cmdLogin.Parameters.AddWithValue("@uname", u.Name);
            cmdLogin.Parameters.AddWithValue("@uage", u.Age);
            cmdLogin.Parameters.AddWithValue("@upass", u.Password);
            cmdLogin.Parameters.AddWithValue("@uword", word);
            conn.Open();
            int result = cmdLogin.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("User created");
                Console.WriteLine("=====================================================");
            }
            conn.Close();

        }

        public int Loginid()
        {
            int temp;
            SqlCommand cmd = new SqlCommand("proc_idfind");
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            temp = Int32.Parse(dr[0].ToString());
            conn.Close();
            return temp;
        }

        public string Login(User user)
        {
            string name = null;
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "LoginCheck";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.Add("@uid", SqlDbType.Int);
            cmdLogin.Parameters.Add("@upass", SqlDbType.VarChar, 20);
            cmdLogin.Parameters.Add("@ustatus", SqlDbType.VarChar, 20);
            cmdLogin.Parameters[0].Value = user.Id;
            cmdLogin.Parameters[1].Value = user.Password;
            cmdLogin.Parameters[2].Direction = ParameterDirection.Output;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            cmdLogin.ExecuteScalar();
            name = cmdLogin.Parameters[2].Value.ToString();
            conn.Close();
            return name;
        }

        public void Addword()
        {
            SqlCommand cmd = new SqlCommand("proc_giveword");
            cmd.Connection = conn;
            Console.WriteLine("Enter the Four letter word");
            u.word = Console.ReadLine();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@uword", SqlDbType.VarChar, 10);
            cmd.Parameters[0].Value = u.word;
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("Word Insert successfully");
            conn.Close();
        }

        public string Guess()
        {
            SqlCommand cmd = new SqlCommand("proc_gessword");
            string word = "";
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uword", word);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            word = dr[0].ToString();
            conn.Close();
            u.word = word;
            return word;
        }

        public void Delete(string str)
        {
            SqlCommand cmd = new SqlCommand("proc_delword");
            string word = str;
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("uword", word);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("You Find the word Sucessfully ");
            conn.Close();
        }

        public int checkword()
        {
            int temp;
            SqlCommand cmd = new SqlCommand("proc_checkword");
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            temp = Int32.Parse(dr[0].ToString());
            conn.Close();
            return temp;
        }

        public void AddLasrword(int id,string word)
        {
            SqlCommand cmd = new SqlCommand("proc_lastword");
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("uword",word);
            cmd.Parameters.AddWithValue("uid",id);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("");
            conn.Close();
        }

        public string checklastword(int id)
        {
            string word = "";
            User user = new User();
            SqlCommand cmd = new SqlCommand("proc_checklastword");
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("uid", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            word=user.word = dr[0].ToString();
            conn.Close();
            return word;
        }
    }
}
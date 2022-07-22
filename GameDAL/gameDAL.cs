using gamelib;
using System;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace GameDAL
{
    public class gameDAL
    {
        SqlConnection conn;
        Lastword Lword;

        public gameDAL()
        {
            Lword = new Lastword();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        public int Register()
        {
            gameDAL d = new gameDAL();
            User u = new User();
            string lastword = "";
            Console.WriteLine("Enter the name ");
            u.name = Console.ReadLine();
            bool containsInt = u.name.Any(char.IsDigit);
            if (containsInt)
            {
                Console.WriteLine("Your UserName should not have Numeric characters");
                return 0;
            }
            Console.WriteLine("Enter your age ");
            try
            {
                u.Age = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Given word is Must number");
                return 0;

            }
            u.Password = u.name + "" + u.Age;
            u.id = 101 + d.loginid();
            Console.WriteLine("your password is (" + u.Password + ") ");
            Console.WriteLine("your id is " + u.id);
            Lword.Id = u.id;
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "proc_getuser";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.AddWithValue("@uid", u.id);
            cmdLogin.Parameters.AddWithValue("@uname", u.name);
            cmdLogin.Parameters.AddWithValue("@uage", u.Age);
            cmdLogin.Parameters.AddWithValue("@upass", u.Password);
            cmdLogin.Parameters.AddWithValue("@uword", lastword);
            conn.Open();
            int result = cmdLogin.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("USer created");
            conn.Close();
            return result;

        }

        public User Login(User user)
        {
            string login = null;
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            conn.Open();
            cmdLogin.CommandText = "proc_gamelogincheck";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.AddWithValue("@uid", user.id);
            Lword.Id = user.id;
            cmdLogin.Parameters.AddWithValue("@upass", user.Password);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            SqlDataReader dr = cmdLogin.ExecuteReader();
            dr.Read();
            login = dr[0].ToString();
            conn.Close();
            user.login = login;
            return user; ;
        }
        public void gword(User user)
        {
            SqlCommand cmd = new SqlCommand("proc_giveword");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@uword", SqlDbType.VarChar, 10);
            cmd.Parameters[0].Value = user.word;
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("Word insert successfully");
            conn.Close();
        }
        public User gessword(User user)
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
            Console.WriteLine(user.id);
            Lword.LastWord = word;
            user.word = word;
            return user;
        }
        public void delword(User user)
        {
            SqlCommand cmd = new SqlCommand("proc_delword");
            string word = user.word;
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
        public void lastword()
        {
            SqlCommand cmd = new SqlCommand("proc_lastword");
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            Console.WriteLine(Lword.Id);
            Console.WriteLine(Lword.LastWord);
            cmd.Parameters.AddWithValue("uid", Lword.Id);
            cmd.Parameters.AddWithValue("uword", Lword.LastWord);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("Last find word is stored ");
            conn.Close();
            
        }
        public User checklastword(User user)
        {
            SqlCommand cmd = new SqlCommand("proc_checklastword");
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("uid", user.id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            user.word = dr[0].ToString();
            conn.Close();
            return user;
        }
        public int loginid()
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
    }
}

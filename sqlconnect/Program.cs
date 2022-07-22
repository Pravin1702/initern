using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace sqlconnect
{
    class Program
    {

        SqlConnection conn;

        public Program()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            Console.WriteLine("connected");
        }
        //connected arch
        void FetchProductData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Products");
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.Write("Product ID " + dr[0].ToString());
                Console.Write("\tProduct Name " + dr[1].ToString());
                Console.Write("\tProduct quantity pre unit " + dr[4].ToString());
                Console.WriteLine();
            }
            conn.Close();

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.FetchProductData();
            Console.ReadKey();
        }
    }
   
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace game1
{
    class Program
    {
       /* public Program()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            Console.WriteLine("connected");
        }*/
        public void Display()
        {
            Console.WriteLine("Welcome to the Game");
            Console.WriteLine("1) Register \n2) Login");
            int key=Convert.ToInt32(Console.ReadLine());
            if (key == 1)
            {
                Register reg = new Register();
                reg.register();
            }
            else if (key == 2)
            {
                Login log = new Login();
                log.login();
            }
            else
                Console.WriteLine("Wrong input");
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Display();
            Console.ReadKey();
            
        }
    }
}
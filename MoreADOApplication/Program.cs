using System;
using MoreADOLibrary;
using ADBLLibrary;
using MoreADODALibrary;

    namespace MoreADOApplication
{
    class Program
    {
        UserBL userBL;
        public Program()
        {
            userBL = new UserBL();
        }
        void UserLoginCheck()
        {
            User user = GetLoginData();
            user = userBL.CheckLogin(user);
            Console.WriteLine(user.Username);
            if (user == null)
                Console.WriteLine("Invalid username or password");
            else
            {
                Console.WriteLine("Welcome " + user.Username + " you are a " + user.Role);
                if(user.Role == "admin")
                {
                    UserDAL dal = new UserDAL();
                    dal.DisplayData();
                }
                else
                {
                    Console.WriteLine("User login success but not enough rights to view data");
                }
            }
        }

        private User GetLoginData()
        {
            User user = new User();
            Console.WriteLine("Please enter your username");
            user.Username = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            user.Password = Console.ReadLine();
            return user;
        }

        static void Main(string[] args)
        {
            new Program().UserLoginCheck();
            Console.ReadKey();
        }
    }
}
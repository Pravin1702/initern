using System;
using UserBal;
using GameUSerClass;
using GameDalLip;

namespace CowAndBull2
{
    public class Program
    {
        userBal userBal;
        public Program()
        {
            userBal = new userBal();
        }

        void GameDisplay()
        {
            int n;
            Console.WriteLine("=====================================================");
            Console.WriteLine("Welcome to the GameManu ");
            Console.WriteLine("1) Register \n2) Login ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Choose an option ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {
                    userBal.Register();
                    userBal.Word();
                }
                else if (n == 2)
                {
                    User user = GetLogin();
                    user = userBal.CheckLogin(user);
                    if (user == null)
                        Console.WriteLine("Invalid username or password");
                    else
                    {
                        Console.WriteLine("=====================================================");
                        Console.WriteLine("login successful");
                        Console.WriteLine("=====================================================");
                        userBal.Word();
                    }

                }
                else
                {
                    Console.Write("Given input is wrong ");
                    GameDisplay();

                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Given input is Must to provide number");
                GameDisplay();
            }

        }
        private User GetLogin()
        {
            User user = new User();
            Console.WriteLine("=====================================================");
            Console.WriteLine("Enter the id number ");
            try
            {
                user.Id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Given input is Must number");
                GameDisplay();
            }
            Console.WriteLine("Enter the password ");
            user.Password = Console.ReadLine();
            Console.WriteLine("=====================================================");
            return user;
        }

        public static void Main(String[] arg)
        {
            Program program = new Program();
            program.GameDisplay();
            Console.ReadKey();

        }
    }
}
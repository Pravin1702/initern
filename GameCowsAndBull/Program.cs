using System;
using gamelib;
using GameDAL;
using Game;

namespace GameCowsAndBull
{
    class Program
    {
        User user;
        public Program()
        {
            user = new User();
        }
        
        public void GameDis()
        {
            int n;
            Console.WriteLine("Welcome to the GameManu ");
            Console.WriteLine("1) Register \n2) Login ");
            Console.WriteLine("Choose an option ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {

                    game g = new game();
                    Lastword Lword = new Lastword();
                    gameDAL dal = new gameDAL();
                    int regester = dal.Register();
                    if (regester == 0)
                    {
                        Console.Write("Given Input is Wrong \n");
                        GameDis();
                    }
                    else if(regester > 0)
                    {
                        g.GameManu(Lword);
                    }

                }
                else if (n == 2)
                {
                    int login;
                    Lastword Lword = new Lastword();
                    gameDAL dal = new gameDAL();
                    user = Getlogin();
                    user = dal.Login(user);
                    Console.WriteLine(user.id);
                    Lword.Id = user.id;
                    if (user.login == "invalid")
                    {
                        Console.WriteLine("Invalid username or password");
                        GameDis();
                    }
                    else
                    {
                        game g = new game();
                        user = dal.checklastword(user);
                        if (user.word != "noword")
                        {
                            Console.WriteLine("your Last find word is (" + user.word + ")");
                            g.GameManu(Lword);
                        }
                        else
                        {
                            Console.WriteLine("First find one word to success");
                            g.GameManu(Lword);
                        }
                    }

                }
                else
                {
                    Console.Write("Given input is wrong ");
                    GameDis();

                }
            }
            catch(FormatException fe)
            {
                Console.WriteLine("Given input is Must to provide number");
                GameDis();
            }
        }
        private User Getlogin()
        {
           // User user = new User();
            Console.WriteLine("Enter the id number ");
            try
            {
                user.id = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException fe)
            {
                Console.WriteLine("Given input is Must number");
                GameDis();
            }
            Console.WriteLine("Enter the password ");
            user.Password = Console.ReadLine();
            return user;
        }
        public static void Main(String[] arg )
        {
            new Program().GameDis();
            Console.ReadKey();
        }
    }
}
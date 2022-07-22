using System;
using System.Linq;
using GameDAL;
using gamelib;


namespace Game
{
    public class game
    {
        Lastword Lword;
        public game()
        {
            Lword = new Lastword();
        }
        public void GameManu(Lastword Lword)
        {
            int n;
            try
            {
                do
                {
                    Console.WriteLine("Welcome to the game");
                    Console.WriteLine("1) Give Word");
                    Console.WriteLine("2) Guess word");
                    Console.WriteLine("3) Exit");
                    Console.WriteLine("Choose an option");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n == 1)
                    {
                        game p = new game();
                        p.fword();
                    }

                    else if (n == 2)
                    {
                        game p = new game();
                        p.gessword();

                    }
                    else if (n == 3)
                    {
                        Console.WriteLine("Bye...Tata.....!");
                    }
                    else
                    {
                        Console.WriteLine("Given input is wrong");
                        game p = new game();
                        p.GameManu(Lword);
                    }
                } while (n != 3);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("OOPS.... Given value is Must Number");
                GameManu(Lword);
            }
        }

        public void fword()
        {
            game g = new game();
            User user = new User();
            gameDAL dal = new gameDAL();
            Console.WriteLine("Please Enter The Four Letter Word ");
            user.word = Console.ReadLine();
            if(user.word.Length != 4)
            {
                Console.WriteLine("The Word Should have Four Letter ");
                fword();
            }
            bool containsNum = user.word.Any(char.IsDigit);
            if (containsNum)
            {
                Console.WriteLine("Words should not have Numerical Values");
                fword();
            }
            dal.gword(user);
            g.GameManu(Lword);
            
        }

        public void gessword()
        {
            User user = new User();
            gameDAL dal = new gameDAL();
            int Cows = 0, Bulls = 0, flag = 0;
            int checkword;
            checkword = dal.checkword();
            if (checkword > 0)
            {
                user = dal.gessword(user);
                Console.WriteLine(Lword.Id);
                string str1 = user.word;
                int len = str1.Length;
                if (len == 4)
                {

                    str1 = str1.ToLower();
                    Console.WriteLine("Enter the Gess Word ");
                    do
                    {
                        String str2 = Console.ReadLine().ToLower();
                        Cows = 0;
                        Bulls = 0;
                        flag = 0;
                        for (int i = 0; i < len; i++)
                        {
                            if (str1[i] == str2[i])
                            {
                                Cows++;
                                flag++;
                                if (flag == len)
                                {
                                    Console.WriteLine("goo......");
                                    dal.lastword();
                                    Console.WriteLine("goo 2......");
                                    dal.delword(user);
                                    str1 = null;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < len; j++)
                                {
                                    if (str1[i] == str2[j])
                                    {
                                        Bulls++;
                                        break;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("cows - " + Cows + "  bull - " + Bulls);
                    } while (Cows != len);
                }
            }
            else if(checkword == 0)
            {
                Console.WriteLine("There are not word to find \n First give word");
                GameManu(Lword);

            }

        }

    }
}
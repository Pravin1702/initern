using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    internal class GameManu
    {
        
        public void game()
        {
            int n;
            Console.WriteLine("Welcome to the game");
            Console.WriteLine("1) Give Word");
            Console.WriteLine("2) Guess word");
            Console.WriteLine("3) Exit");
            Console.WriteLine("Choose an option");
            n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                GameManu g = new GameManu();
                g.Getword();
            }
            else if (n == 2)
            {
                GameManu g = new GameManu();
                g.Guessword();
            }
            else if (n == 3)
            {
                Console.Write("bye.....!!!");
            }
            else
            {
                Console.WriteLine("Wrong Input");
                game();
            }
                
        }

        void Getword()
        {
            String gword;
            Console.WriteLine("Please enter the word");
            gword = Console.ReadLine();


        }

        void Guessword()
        {
            int Cows = 0, Bulls = 0,flag=0;
            String str1 = "what";
            int len = str1.Length;
            str1 = str1.ToLower();
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
                        if(flag == len)
                        {
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
                } Console.WriteLine("cows - " + Cows + "  bull - " + Bulls);
            } while (Cows != len) ;

        }
    }
}

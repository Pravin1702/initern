using UserBal;
using GameDalLip;
using GameUSerClass;

namespace UserBal

{
    public class userBal
    {
        public static int id;
        gamedal gamedl;
        public userBal()
        {
            gamedl = new gamedal();
        }

        public void Register()
        {
            gamedl.InsertUserToTable();
        }

        public User CheckLogin(User user)
        {
            if (user.Id != 0 && user.Password != null)
            {
                id = user.Id;
                string result = gamedl.Login(user);
                if (result == "invalid")
                {
                    return null;
                }

                else
                {
                    return user;
                }
            }
            return null;
        }

        public void Word()
        {
            string check=gamedl.checklastword(id);
            if (check == "noword")
            {
                Console.WriteLine("=====================================================");
                Console.WriteLine("Find one word to success");
                Console.WriteLine("=====================================================");
            }
            else
            {
                Console.WriteLine("=====================================================");
                Console.WriteLine("Your last find word is (" + check + ")");
                Console.WriteLine("=====================================================");
            }
            int n;
            try
            {
                do
                {
                Console.WriteLine("=====================================================");
                    Console.WriteLine("Welcome to the game");
                    Console.WriteLine("1) Give Word");
                    Console.WriteLine("2) Guess word");
                    Console.WriteLine("3) Exit");
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("Choose an option");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n == 1)
                    {
                        gamedl.Addword(); 
                    }

                    else if (n == 2)
                    {
                        userBal userbal = new userBal();
                        userbal.game();

                    }
                    else if (n == 3)
                    {
                        Console.WriteLine("=====================================================");
                        Console.WriteLine("Bye...Tata.....!");
                        Console.WriteLine("=====================================================");
                    }
                    else
                    {
                        Console.WriteLine("Given input is wrong");
                        Word();
                    }
                } while (n != 3);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("=====================================================");
                Console.WriteLine("OOPS.... Given value is Must Number");
                Console.WriteLine("=====================================================");
                Word();
            }

        }

        public void game()
        {
            int Cows = 0, Bulls = 0, flag = 0;
            int checkword;
            checkword = gamedl.checkword();
            if (checkword > 0)
            {
                string word = gamedl.Guess();
                string str1 = word;
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
                                    gamedl.AddLasrword(id,str1);
                                    gamedl.Delete(str1);
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
            else if (checkword == 0)
            {
                Console.WriteLine("=====================================================");
                Console.WriteLine("There are not word to find \nFirst give word");
                Console.WriteLine("=====================================================");
                Word();

            }
            
        }


    }
}
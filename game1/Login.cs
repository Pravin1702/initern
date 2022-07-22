using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    internal class Login
    {
        public void login()
        {
            int id = 101,id2;
            String password = "tim22",password2;
            Console.WriteLine("Please enter your id");
            id2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your password");
            password2 = Console.ReadLine();
            if(id==id2 && password==password2)
            {
                GameManu g1 = new GameManu();
                g1.game();
            }
            else
            {
                Console.WriteLine("Increate passord or id");
            }
            
        }
    }
}

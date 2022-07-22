using System;
using System.Collections.Generic;
using System.Linq;

namespace UnderStandingLINQApp
{
    class User //: IComparable<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //public int CompareTo(User other)
        //{
        //    return this.Username.CompareTo(other.Username);
        //}
        public override string ToString()
        {
            return Username + "  " + Password;
        }
    }
    class Program
    {
        void UnderstandLINQ()
        {
            //Create a list of users and print them sorted by username in ascending order
            List<User> users = new List<User>
             {
                 new User{Username="Tim",Password="hello"},
                 new User{Username="Jim",Password="hello"},
                 new User{Username="Lim",Password="done"},
                 new User{Username="Pim",Password="apple"}
             };
            //users.Sort();
            var sortedUsers = users.OrderByDescending(u => u.Password).ThenBy(u => u.Username);
            foreach (var item in sortedUsers)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.UnderstandLINQ();
            Console.ReadKey();
        }
    }
}
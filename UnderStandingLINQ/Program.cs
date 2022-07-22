using System;
using System.Collections.Generic;
using System.Linq;

namespace UnderStandingLINQ
{
    class Customer
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }
    class User //: IComparable<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

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
                 new User{Username="Tim",Password="hello",Role="Admin"},
                 new User{Username="Jim",Password="hello",Role="User"},
                 new User{Username="Lim",Password="done",Role="User"},
                 new User{Username="Pim",Password="apple",Role="Admin"}
             };
            List<Customer> customers = new List<Customer>
            {
                new Customer{Fullname="Tim T",Username="Tim",Age=23,Phone="1234567890"},
                new Customer{Fullname="Jim J",Username="Jim",Age=36,Phone="9876543210"},
                new Customer{Fullname="Lim Lim",Username="Lim",Age=80,Phone="5566443322"},
                new Customer{Fullname="Pim P",Username="Pim",Age=23,Phone="6677889900"}
            };
            Console.WriteLine("Users sorted by password and then by username");
            var sortedUsers = users.OrderByDescending(u => u.Password)
                .ThenBy(u => u.Username)
                .Select(u => new { Uname = u.Username, Urole = u.Role });
            foreach (var item in sortedUsers)
            {
                Console.WriteLine(item.Uname + " " + item.Urole);
            }
            //Username,Fullname,PHone and role
            Console.WriteLine("Joining the user and the customer table");
            var customerData = customers.Join(users, c => c.Username, u => u.Username, (c, u) => new
            {
                username = u.Username,
                phone = c.Phone,
                fullname = c.Fullname,
                role = u.Role
            });
            foreach (var item in customerData)
            {
                Console.WriteLine(item.fullname + " " + item.phone + " " + item.role + " " + item.username);
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
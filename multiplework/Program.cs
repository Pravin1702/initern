using System;
using CustomerManage;

namespace multiplework
{
    class Program
    {
        void PrintMenu()
        {
            Console.WriteLine("Choose from option");
            Console.WriteLine("1. Add Customers");
            Console.WriteLine("2. Print Customers");
            Console.WriteLine("3. Print one Customer");
            Console.WriteLine("4. Edit customer phone");
            Console.WriteLine("5. Edit customer age");
            Console.WriteLine("6. Delete customer");
            Console.WriteLine("7. Exit");
            Console.WriteLine("8. Sort and print");
        }
        void InteractWithCustomers()
        {
            CustomerManage manage = new CustomerManage();
            int choice = 7;
            do
            {
                PrintMenu();
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid entry. Please try again");
                }
                switch (choice)
                {
                    case 1:
                        manage.AddCustomers();
                        break;
                    case 2:
                        manage.PrintAllCustomers();
                        break;
                    case 3:
                        manage.PrintCustomerById();
                        break;
                    case 4:
                        manage.UpdateCustomerPhone();
                        break;
                    case 5:
                        manage.UpdateCustomerAge();
                        break;
                    case 6:
                        manage.RemoveCustomer();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    case 8:
                        manage.SortCustomerByAge();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 7);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.InteractWithCustomers();
           
        }
    }
}
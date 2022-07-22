namespace game1
{
    class Register
    {
        public void register()
        {
            String name, password;
            int age, id = 100;
            Console.WriteLine("Please enter your name ");
            name = Console.ReadLine();
            Console.WriteLine("Please enter your age ");
            age = Convert.ToInt32(Console.ReadLine());
            password = name + "" + age;
            Console.WriteLine("Welcome- your password is your name and age together(" + password + ")");
            id = id + 1;
            Console.WriteLine("your id is " + id);
            GameManu g1 = new GameManu();
            g1.game();
        }
    }
}   

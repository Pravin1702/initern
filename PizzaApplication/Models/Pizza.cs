namespace PizzaApplication.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Pic { get; set; }
        public string IsVeg { get; set; }

    }
}

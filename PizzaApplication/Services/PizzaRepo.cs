using PizzaApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace PizzaApplication.Services
{
    public class PizzaRepo : IRepo<int, Pizza>
    {
        SqlConnection conn;
       
        public PizzaRepo(IConfiguration configuration)
        {
            string strCon = configuration.GetConnectionString("conn");
            conn = new SqlConnection(strCon);
        }
        public Pizza Add(Pizza item)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertPizza", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pname", item.Name);
            cmd.Parameters.AddWithValue("@pprice", item.Price);
            cmd.Parameters.AddWithValue("@pdesc", item.Description);
            cmd.Parameters.AddWithValue("@ppic", item.Pic);
            cmd.Parameters.AddWithValue("@pveg", item.IsVeg);
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
                return item;
            else
                return null;
        }
        public Pizza Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Pizza Get(int id)
        {
            var pizza = GetAll().SingleOrDefault(c => c.Id == id);
            return pizza;
        }
        public IEnumerable<Pizza> GetAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_GetAllPizza", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Pizza> pizzas = new List<Pizza>();
            Pizza pizza;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                pizza = new Pizza();
                pizza.Id = Convert.ToInt32(item[0].ToString());
                pizza.Name = item[1].ToString();
                pizza.Price = Convert.ToInt32(item[2].ToString());
                pizza.Description = item[3].ToString();
                pizza.Pic = item[4].ToString();
                pizza.IsVeg = item[5].ToString();
                pizzas.Add(pizza);
            }
            return pizzas;
        }
        public Pizza Update(Pizza item)
        {
            throw new NotImplementedException();
        }
    }
}

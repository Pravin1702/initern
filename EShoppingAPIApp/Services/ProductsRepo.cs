using EShoppingAPIApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace EShoppingAPIApp.Services
{
    public class ProductsRepo : IRepo<int, Products>
    {
        SqlConnection conn;

        public ProductsRepo(IConfiguration configuration)
        {
            string strCon = configuration.GetConnectionString("conn");
            conn = new SqlConnection(strCon);
        }
        public Products Add(Products item)
        {
            SqlCommand cmd = new SqlCommand("proc_AddProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pname", item.Name);
            cmd.Parameters.AddWithValue("@pprice", item.Price);
            cmd.Parameters.AddWithValue("@pdesc", item.Description);
            cmd.Parameters.AddWithValue("@ppic", item.Pic);
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

        public Products Delete(Products item)
        {
            SqlCommand cmd = new SqlCommand("proc_AddProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", item.Id);
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

       

        public Products Get(int id)
        {
            var product = GetAll().SingleOrDefault(c => c.Id == id);
            return product;
        }

        public IEnumerable<Products> GetAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_GetAllProducts", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Products> productss = new List<Products>();
            Products product;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                product = new Products();
                product.Id = Convert.ToInt32(item[0].ToString());
                product.Name = item[1].ToString();
                product.Price = Convert.ToInt32(item[2].ToString());
                product.Description = item[3].ToString();
                product.Pic = item[4].ToString();
                productss.Add(product);
            }
            return productss;
        }

        public Products Update(Products item)
        {
            SqlCommand cmd = new SqlCommand("proc_AddProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", item.Id);
            cmd.Parameters.AddWithValue("@ppic", item.Pic);
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

        public Products AddCart(Products item)
        {
            SqlCommand cmd = new SqlCommand("proc_AddCart", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pname", item.UserName);
            cmd.Parameters.AddWithValue("@pid", item.Id);
            cmd.Parameters.AddWithValue("@pnames", item.Name);
            cmd.Parameters.AddWithValue("@pprice", item.Price);
            cmd.Parameters.AddWithValue("@pdesc", item.Description);
            cmd.Parameters.AddWithValue("@pcount", item.Count);
            cmd.Parameters.AddWithValue("@ppic", item.Pic);
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

        public IEnumerable<Products> GetAllCart()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_GetAllCart", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Products> cartss = new List<Products>();
            Products cart;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                cart = new Products();
                cart.UserName = item[0].ToString();
                cart.Id = Convert.ToInt32(item[1].ToString());
                cart.Name = item[2].ToString();
                cart.Price = Convert.ToInt32(item[3].ToString());
                cart.Description = item[4].ToString();
                cart.Count = Convert.ToInt32(item[5].ToString());
                cart.Pic = item[6].ToString();
                cartss.Add(cart);
            }
            return cartss;
        }

        public Products DeleteProductCart(Products item)
        {
            SqlCommand cmd = new SqlCommand("proc_deleteById", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", item.UserName);
            cmd.Parameters.AddWithValue("@uid", item.Id);
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

        public Products AddSameProduct(Products item)
        {
            SqlCommand cmd = new SqlCommand("proc_CountAdd", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", item.UserName);
            cmd.Parameters.AddWithValue("@uid", item.Id);
            cmd.Parameters.AddWithValue("@ucount", item.Count);
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

        public Products DeleteSameProduct(Products item)
        {
            SqlCommand cmd = new SqlCommand("proc_CountDelete", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", item.UserName);
            cmd.Parameters.AddWithValue("@uid", item.Id);
            cmd.Parameters.AddWithValue("@ucount", item.Count);
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


    }
}

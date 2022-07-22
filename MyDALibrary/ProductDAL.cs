using Microsoft.Data.SqlClient;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDALibrary
{
    public class ProductDAL
    {
        readonly SqlConnection conn;
        public ProductDAL()
        {
            conn = Connection.GetConnection().conn;
        }
        public ICollection<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            SqlCommand cmd = new SqlCommand("proc_GetAllProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product product = new Product();
                product.Name = dr[0].ToString();
                product.Price = float.Parse(dr[1].ToString());
                product.UnitsInStock = Convert.ToInt32(dr[2].ToString());
                products.Add(product);
            }
            conn.Close();
            return products;
        }
    }
}
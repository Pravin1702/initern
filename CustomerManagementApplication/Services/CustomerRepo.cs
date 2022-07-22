using CustomerManagementApplication.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementApplication.Services
{
    public class CustomerRepo : IRepo<int, Customer>
    {
        SqlConnection conn;
        public CustomerRepo()
        {

        }
        public CustomerRepo(IConfiguration configuration)
        {
            string strCon = configuration.GetConnectionString("conn");
            conn = new SqlConnection(strCon);
        }
        public Customer Add(Customer item)
        {
            SqlCommand cmd = new SqlCommand("pro_InsertCustomer", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cname", item.Name);
            cmd.Parameters.AddWithValue("@cage", item.Age);
            cmd.Parameters.AddWithValue("@cpic", item.Pic);
            cmd.Parameters.AddWithValue("@cphone", item.Phone);
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

        public Customer Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            var customer = GetAll().SingleOrDefault(c => c.Id == id);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_GetAllCustomers", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Customer> customers = new List<Customer>();
            Customer customer;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                customer = new Customer();
                customer.Id = Convert.ToInt32(item[0].ToString());
                customer.Name = item[1].ToString();
                customer.Age = Convert.ToInt32(item[2].ToString());
                customer.Phone = item[3].ToString();
                customer.Pic = item[4].ToString();
                customers.Add(customer);
            }
            return customers;
        }

        public Customer Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}

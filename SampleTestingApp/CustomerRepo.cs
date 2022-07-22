using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestingApp
{
    public class CustomerRepo :IRepo
    {
        public List<Customer> Customers { get; set; }
        public Customer Add(Customer item)
        {
            foreach (var customer in Customers)
            {
                if (item.Id == customer.Id)
                {
                    return null;
                }
            }
            Customers.Add(item);
            return item;
        }

        public ICollection<Customer> GetAll()
        {
            return Customers;
        }

        public Customer Remove(int id)
        {
            Customer customer = Customers.FirstOrDefault(cust => cust.Id == id);
            int idx = Customers.IndexOf(customer);
            if (idx > -1)
            {
                Customers.RemoveAt(idx);
                return customer;
            }
            return null;

        }
    }
}

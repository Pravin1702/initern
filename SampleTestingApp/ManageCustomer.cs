using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestingApp
{
    public class ManageCustomer
    {
        private readonly IRepo _repo;

        public ManageCustomer(IRepo repo)
        {
            _repo = repo;
        }
        public int GetCustomerID(int num)
        {
            return num + 10;
        }
        public bool AddCustomer(Customer customer)
        {
            var res = _repo.Add(customer);
            if (res == null)
                return false;
            return true;

        }
    }
}

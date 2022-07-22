using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestingApp
{
    public interface IRepo
    {
        Customer Add(Customer item);
        Customer Remove(int id);
        ICollection<Customer> GetAll();
    }
}

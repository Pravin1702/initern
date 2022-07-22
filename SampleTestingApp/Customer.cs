using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestingApp
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return ((Customer)(obj)).Id.Equals(this.Id);
        }
    }
}

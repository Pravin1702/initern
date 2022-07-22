using System;
using NUnit.Framework;
using SampleTestingApp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTest
{
    public class TestManageCustomer
    {
        CustomerRepo _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new CustomerRepo();
            _repo.Customers = new List<Customer>()
            {
                new Customer(){Id=101,Name="Ramu"},
                new Customer(){Id=102,Name="Somu"}
            };
        }
        [Test]
        [TestCase(101, "Jimu")]
        [TestCase(102, "Limu")]
        public void TestAddCustomerForFail(int id, string name)
        {
            //Arrange
            ManageCustomer manage = new ManageCustomer(_repo);
            //Act
            Customer customer = new Customer() { Id = id, Name = name };
            var result = manage.AddCustomer(customer);
            //Assert
            Assert.IsTrue(result);

        }
        [Test]
        [TestCase(103, "Jimu")]
        [TestCase(104, "Limu")]
        public void TestAddCustomerForPass(int id, string name)
        {
            //Arrange
            ManageCustomer manage = new ManageCustomer(_repo);
            //Act
            Customer customer = new Customer() { Id = id, Name = name };
            var result = manage.AddCustomer(customer);
            //Assert
            Assert.IsTrue(result);
        }
    }
}

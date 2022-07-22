using NUnit.Framework;
using SampleTestingApp;

namespace SampleTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(25)]
        [TestCase(20)]
        public void TestGetCustomerID(int res)
        {
            //Arrange
            ManageCustomer manage = new ManageCustomer();
            //Act
            var result = manage.GetCustomerID(10);
            //Assert
            Assert.AreEqual(res, result);
        }

    }
}
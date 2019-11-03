using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Tests
{
    internal class CustomerMock : ICustomer
    {
        private readonly int _expectedAge;

        public CustomerMock(int expectedAge)
        {
            _expectedAge = expectedAge;
        }

        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int GetAge() => _expectedAge;
        
    }
}

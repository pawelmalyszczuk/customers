﻿using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Tests
{
    class CustomerRepositoryTests
    {
        [Test]
        public void WhenTryingToAddCustomerThatIsNotValidated_ThenCustomerIsNotAdded()
        {
            var customerValidatorMock = Mock.Of<ICustomerValidator>(validator => validator.Validate(It.IsAny<ICustomer>()) == false);

            var customerRepository = new CustomerRepository(customerValidatorMock);

            customerRepository.Add(It.IsAny<ICustomer>());

            customerRepository.AllCustomers.Should().BeEmpty();
        }

        [Test]
        public void WhenTryingToAddMultipleCustomers_ThenOnlyValidatedOnesAreAdded()
        {
            var customerValidatorMock = Mock.Of<ICustomerValidator>(validator => validator.Validate(It.Is<ICustomer>(customer => customer.FirstName == "John")) == true);

            var customerRepository = new CustomerRepository(customerValidatorMock);

            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));

            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "Paul"));

            customerRepository.AllCustomers.Should().HaveCount(1).And.OnlyContain(customer => customer.FirstName == "John");
        }
    }
}

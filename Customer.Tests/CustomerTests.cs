using NUnit.Framework;
using System;
using FluentAssertions;
using Moq;

namespace Customer.Tests
{
    public class CustomerTests
    {
        [Test]
        public void WhenCustomerIsNull_ThenArgumentNullExceptionIsThrown()
        {
            var validator = new CustomerValidator();

            Action action = () => validator.Validate(null);

            action.Should().Throw<ArgumentNullException>();
        }  

        [Test]
        public void WhenCustomerHasAgeLessThan18_ThenValidationFails()
        {
            var validator = new CustomerValidator();
            var customer = new CustomerMock(16);

            bool validate = validator.Validate(customer);

            validate.Should().BeFalse();
        }

        // Use Mock: Functional (kod funkcyjny)
        [Test]
        public void MF_WhenCustomerHasAgeLessThan18_ThenValidationFails()
        {
            var validator = new CustomerValidator();

            var customerMock = Mock.Of<ICustomer>(x => x.GetAge() == 16);


            bool validate = validator.Validate(customerMock);

            validate.Should().BeFalse();
        }

        // Use Mock: Introduction (kod imperaktywny)
        [Test]
        public void MI_WhenCustomerHasAgeLessThan18_ThenValidationFails()
        {
            var validator = new CustomerValidator();

            var customerMock = new Mock<ICustomer>();
            customerMock.Setup(x => x.GetAge()).Returns(16);

            bool validate = validator.Validate(customerMock.Object);

            validate.Should().BeFalse();
        }

        [Test]
        public void WhenCustomerHasAgeGreaterThanOrEquealTo18_ThenValidationTrue(
            [Values(18, 19)] int expectedAge)
        {
            var validator = new CustomerValidator();
            var customer = new CustomerMock(expectedAge: expectedAge);

            bool validate = validator.Validate(customer);

            validate.Should().BeTrue();
        }

        // Use Mock: Functional (kod funkcyjny)
        [Test]
        public void MF_WhenCustomerHasAgeGreaterThanOrEquealTo18_ThenValidationTrue(
            [Values(18, 19)] int expectedAge)
        {
            var validator = new CustomerValidator();

            var customer = Mock.Of<ICustomer>(x => x.GetAge() == expectedAge);

            bool validate = validator.Validate(customer);

            validate.Should().BeTrue();
        }

        // Use Mock: Introduction (kod imperaktywny)
        [Test]
        public void MI_WhenCustomerHasAgeGreaterThanOrEquealTo18_ThenValidationTrue(
            [Values(18, 19)] int expectedAge)
        {
            var validator = new CustomerValidator();

            var customer = new Mock<ICustomer>();
            customer.Setup(x => x.GetAge()).Returns(expectedAge);

            var validate = validator.Validate(customer.Object);

            validate.Should().BeTrue();
        }

    }
}

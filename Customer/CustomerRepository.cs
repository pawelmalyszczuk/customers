
using System.Collections.Generic;

namespace Customer
{
    public class CustomerRepository: ICustomerRepository, ICustomerValidator
    {
        ICustomerValidator validator;

        List<ICustomer> allCustomers = new List<ICustomer>();

        public CustomerRepository(ICustomerValidator customerValidator)
        {
            validator = customerValidator;
        }

        public IReadOnlyList<ICustomer> AllCustomers => allCustomers;

        public bool Add(ICustomer customer)
        {
            if (Validate(customer))
            {
                if (allCustomers == null) allCustomers = new List<ICustomer>();

                allCustomers.Add(customer);

                return true;
            }

            return false;
        }

        public bool Validate(ICustomer customer)
        {
            return validator.Validate(customer);
        }
    }
}

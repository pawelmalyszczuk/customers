using System.Collections.Generic;

namespace Customer
{
    public interface ICustomerRepository
    {
        IReadOnlyList<ICustomer>AllCustomers { get; }

        bool Add(ICustomer customer);
    }
}

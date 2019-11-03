namespace Customer
{
    public interface ICustomerValidator
    {
        bool Validate(ICustomer customer);
    }
}
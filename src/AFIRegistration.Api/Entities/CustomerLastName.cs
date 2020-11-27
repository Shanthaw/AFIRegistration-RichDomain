using AFIRegistration.Api.Helpers;
using System;

namespace AFIRegistration.Api.Entities
{
    public class CustomerLastName : ValueObject<CustomerLastName>
    {
        public string Value { get; }
        private CustomerLastName(string value)
        {
            Value = value;
        }
        protected CustomerLastName()
        {

        }
        public static Result<CustomerLastName> Create(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
                return Result.Fail<CustomerLastName>(Constants.LastNameRequired);
            if (customerName.Length < 3)
                return Result.Fail<CustomerLastName>(Constants.LastNameMinLength);
            if (customerName.Length > 50)
                return Result.Fail<CustomerLastName>(Constants.LastNameMaxLength);
            return Result.Ok(new CustomerLastName(customerName));
           
        }
        protected override bool EqualsCore(CustomerLastName other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}

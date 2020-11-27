using AFIRegistration.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIRegistration.Api.Entities
{
    public class CustomerFirstName : ValueObject<CustomerFirstName>
    {
        public string Value { get; }
        private CustomerFirstName(string value)
        {
            Value = value;
        }
        protected CustomerFirstName()
        {
        
        }
        public static Result<CustomerFirstName> Create(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
                return Result.Fail<CustomerFirstName>(Constants.FirstNameRequired);
            if (customerName.Length < 3)
                return Result.Fail<CustomerFirstName>(Constants.FirstNameMinLength);
            if (customerName.Length > 50)
                return Result.Fail<CustomerFirstName>(Constants.FirstNameMaxLength);
            return Result.Ok(new CustomerFirstName(customerName));
        }

        protected override bool EqualsCore(CustomerFirstName other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
  
}

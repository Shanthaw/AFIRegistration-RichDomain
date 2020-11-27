using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIRegistration.Api.Entities
{
    public class CustomerDateOfBirth : ValueObject<CustomerDateOfBirth>
    {
        public DateTimeOffset Value { get; }
        private CustomerDateOfBirth(DateTimeOffset value)
        {
            Value = value;
        }
        protected CustomerDateOfBirth()
        {

        }
        public static Result<CustomerDateOfBirth> Create(DateTimeOffset dob)
        {
            return Result.Ok(new CustomerDateOfBirth(dob));
        }
        protected override bool EqualsCore(CustomerDateOfBirth other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}

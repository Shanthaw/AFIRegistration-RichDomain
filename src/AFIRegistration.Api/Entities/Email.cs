using System;

namespace AFIRegistration.Api.Entities
{
    public class Email : ValueObject<Email>
    {
        public string Value { get; }
        private Email(string value)
        {
            Value = value;
        }
        protected Email()
        {

        }
        public static Result<Email> Create(string email)
        {
            return Result.Ok(new Email(email));
        }
        protected override bool EqualsCore(Email other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}

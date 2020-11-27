using AFIRegistration.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AFIRegistration.Api.Entities
{
    public class PolicyReferenceNumber : ValueObject<PolicyReferenceNumber>
    {
        public string Value { get; }
        private PolicyReferenceNumber(string value)
        {
            Value = value;
        }
        protected PolicyReferenceNumber()
        {

        }
        public static Result<PolicyReferenceNumber> Create(string policyReferenceNumber)
        {
            string policyReferenceNumberPattern = @"[A-Z]{2}-[0-9]{6}";
            var policyReferenceNumberMatched = Regex.Match(policyReferenceNumber, policyReferenceNumberPattern);
            if (string.IsNullOrEmpty(policyReferenceNumber))
                return Result.Fail<PolicyReferenceNumber>(Constants.PolicyNumberRequired);
            if (!policyReferenceNumberMatched.Success)
            {
                return Result.Fail<PolicyReferenceNumber>(Constants.PolicyReferenceNumberFormat);
            }
            return Result.Ok(new PolicyReferenceNumber(policyReferenceNumber));
        }
        protected override bool EqualsCore(PolicyReferenceNumber other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}

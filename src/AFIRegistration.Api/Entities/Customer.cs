using AFIRegistration.Api.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace AFIRegistration.Api.Entities
{
    public class Customer : BaseEntity
    {
        private string _firstName;
        public CustomerFirstName FirstName 
        {
            get => CustomerFirstName.Create(_firstName).Value;
            set => _firstName = value.Value;
        }
        private string _lastName;
        public CustomerLastName LastName
        {
            get => CustomerLastName.Create(_lastName).Value;
            set => _lastName = value.Value;
        }

        private string _policyReferenceNumber;
        public PolicyReferenceNumber PolicyReferenceNumber
        {
            get => PolicyReferenceNumber.Create(_policyReferenceNumber).Value;
            set => _policyReferenceNumber = value.Value;
        }

        private DateTimeOffset _dateOfBirth;
        public CustomerDateOfBirth DateOfBirth
        {
            get => CustomerDateOfBirth.Create(_dateOfBirth).Value;
            set => _dateOfBirth = value.Value;
        }
        private string _email;
        public Email Email
        {
            get => Email.Create(_email).Value;
            set => _email = value.Value;
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    string policyReferenceNumberPattern = @"[A-Z]{2}-[0-9]{6}";
        //    string emailPattern = @"[a-zA-Z0-9]{4,50}@[a-zA-Z0-9]{2,50}.(com|co.uk)";
        //    if (DateOfBirth == DateTime.MinValue && string.IsNullOrEmpty(Email))
        //    {
        //        yield return new ValidationResult(Constants.DateOfBirthOrEmailRequired, new string[] { nameof(DateOfBirth), nameof(Email) });
        //    }
        //    if (DateOfBirth != null && DateOfBirth.GetCurrentAge() < 18)
        //    {
        //        yield return new ValidationResult(Constants.DateOfBirthMinAgeConstrain, new string[] { nameof(DateOfBirth) });
        //    }
        //    var policyReferenceNumberMatched = Regex.Match(PolicyReferenceNumber, policyReferenceNumberPattern);
        //    if (!policyReferenceNumberMatched.Success)
        //    {
        //        yield return new ValidationResult(Constants.PolicyReferenceNumberFormat,
        //            new string[] { nameof(PolicyReferenceNumber) });
        //    }

        //    if (!string.IsNullOrEmpty(Email))
        //    {
        //        var emailMatched = Regex.Match(Email, emailPattern);
        //        if (!emailMatched.Success)
        //        {
        //            yield return new ValidationResult(Constants.EmailFormat,
        //                new string[] { nameof(Email) });
        //        }
        //    }
        //}
    }
}

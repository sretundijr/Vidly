using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    //custom validation attribute ensure that the customer is older then 18 to purchase a membership
    public class MustBe18ForMembership : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.BirthDate == null)
            {
                return new ValidationResult("Birthday is Required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age > 18) 
                ? ValidationResult.Success : new ValidationResult("Customer must be atleast 18 years old to purchase a membership");
        }
    }
}
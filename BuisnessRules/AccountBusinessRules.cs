using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;

namespace Verdant.Zero.Erp.Api.BuisnessRules
{
    public class AccountBusinessRules<T> : ValidationRules<T>
    {
        public T _entity;

        IAccountManagementDataService _accountDataService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userDataService"></param>
        public AccountBusinessRules(T entity, IAccountManagementDataService accountDataService) : base(entity)
        {
            _accountDataService = accountDataService;
            _entity = entity;

        }
        /// <summary>
        /// Validate
        /// </summary>
        /// <returns></returns>
        public async Task<ValidationResult> Validate()
        {
            ValidateRequired("FirstName", "First Name");
            ValidateRequired("LastName", "Last Name");
            ValidateRequired("CompanyName", "Company Name");

            ValidateRequired("Password", "Password");
            ValidateMatchString("Password", "PasswordConfirmation", "Password", "Confirm Password");

            ValidateRequired("EmailAddress", "Email Address");
            ValidateEmailAddress("EmailAddress", "Email Address");

            await ValidateUniqueEmailAddress("EmailAddress");

            return ValidationResult;
        }
        /// <summary>
        /// Validate Unique Email Address
        /// </summary>
        /// <param name="emailAddress"></param>
        private async Task ValidateUniqueEmailAddress(string emailAddress)
        {
            object valueOf = GetPropertyValue(emailAddress);
            User user = await _accountDataService.GetUserByEmailAddress(valueOf.ToString());
            if (user != null)
            {
                AddValidationError(emailAddress, "Email Address already exists.");
            }

        }
    }
}

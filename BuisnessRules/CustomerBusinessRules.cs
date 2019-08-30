using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;

namespace Verdant.Zero.Erp.Api.Data.BusinessRules
{
    public class CustomerBusinessRules<T> : ValidationRules<T>
    {
        public T _entity;

        ICustomerManagementDataService _customerManagementDataService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userDataService"></param>
        public CustomerBusinessRules(T entity, ICustomerManagementDataService salesOrderManagementDataService) : base(entity)
        {
            _customerManagementDataService = salesOrderManagementDataService;
            _entity = entity;

        }

        public async Task<ValidationResult> Validate()
        {
            ValidateRequired("CustomerName", "Customer Name");
            ValidateRequired("AddressLine1", "Address Line 1");
            ValidateRequired("City", "City");
            ValidateRequired("Region", "State/Region");
            ValidateRequired("PostalCode", "Postal Code");

            await ValidateUniqueCustomerName("CustomerId", "CustomerName", "AccountId");

            return ValidationResult;
        }
        /// <summary>
        /// Validate Unique Customer Name
        /// </summary>
        /// <param name="emailAddress"></param>
        private async Task ValidateUniqueCustomerName(string customerId, string customerName, string accountId)
        {
            object valueOfCustomerName = GetPropertyValue(customerName);
            object valueOfAccountId = GetPropertyValue(accountId);
            object valueOfCustomerId = GetPropertyValue(customerId);

            Customer customer = await _customerManagementDataService.GetCustomerInformationByCustomerName(valueOfCustomerName.ToString(), (int)valueOfAccountId);

            if (customer != null && (int)valueOfCustomerId == 0)
            {
                AddValidationError(customerName, "Customer Name already exists.");
                return;
            }

            if (customer != null && customer.CustomerId != (int)valueOfCustomerId)
            {
                AddValidationError(customerName, "Customer Name already exists.");
            }

        }
    }
}

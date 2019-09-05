using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;

namespace Verdant.Zero.Erp.Api.Data.BusinessRules
{
    public class ContactBusinessRules<T> : ValidationRules<T>
    {
        public T _entity;

        IContactManagementDataService _contactManagementDataService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userDataService"></param>
        public ContactBusinessRules(T entity, IContactManagementDataService salesOrderManagementDataService) : base(entity)
        {
            _contactManagementDataService = salesOrderManagementDataService;
            _entity = entity;

        }

        public async Task<ValidationResult> Validate()
        {
            ValidateRequired("first_name", "First Name");
            //ValidateRequired("AddressLine1", "Address Line 1");
            //ValidateRequired("City", "City");
            //ValidateRequired("Region", "State/Region");
            //ValidateRequired("PostalCode", "Postal Code");

            //await ValidateUniqueContactName("first_name", "ContactName", "AccountId");

            return ValidationResult;
        }
        /// <summary>
        /// Validate Unique Contact Name
        /// </summary>
        /// <param name="emailAddress"></param>
        private async Task ValidateUniqueContactName(string contactId, string contactName, string accountId)
        {
            object valueOfContactName = GetPropertyValue(contactName);
            object valueOfAccountId = GetPropertyValue(accountId);
            object valueOfContactId = GetPropertyValue(contactId);

            Contact contact = await _contactManagementDataService.GetContactInformationByContactName(valueOfContactName.ToString(), (int)valueOfAccountId);

            if (contact != null && (int)valueOfContactId == 0)
            {
                AddValidationError(contactName, "Contact Name already exists.");
                return;
            }

            if (contact != null && contact.ContactId != (int)valueOfContactId)
            {
                AddValidationError(contactName, "Contact Name already exists.");
            }

        }
    }
}

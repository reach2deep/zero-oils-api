using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;

namespace Verdant.Zero.Erp.Api.Data.EntityFramework
{
    public class ZeroErpManagementDataService : EntityFrameworkRepository, IContactManagementDataService
    {
       
        /// <summary>
        /// Create Contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task CreateContact(Contact contact)
        {
            DateTime dateCreated = DateTime.UtcNow;
            contact.UpdatedAt = dateCreated;
            contact.CreatedAt = dateCreated;
            if (contact.BillingAddress != null)
                contact.BillingAddress.CreatedAt = dateCreated;
            if (contact.ShippingAddress != null)
                contact.ShippingAddress.CreatedAt = dateCreated;

            await dbConnection.Contacts.AddAsync(contact);

        }

        public async Task UpdateContact(Contact contact)
        {
            await Task.Delay(0);
            DateTime dateUpdated = DateTime.UtcNow;
            contact.UpdatedAt = dateUpdated;

            if (contact.BillingAddress != null)
                contact.BillingAddress.UpdatedAt = dateUpdated;
            if (contact.ShippingAddress != null)
                contact.ShippingAddress.UpdatedAt = dateUpdated;
            
        }

        public Task<List<Contact>> ContactInquiry(int accountId, string contactName, DataGridPagingInformation paging)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get Contact Information
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<Contact> GetContactInformation(int accountId, int contactId)
        {
            Contact contact = await dbConnection.Contacts.Where(x => x.ContactId == contactId).FirstOrDefaultAsync();
            return contact;
        }

        public async Task<Contact> GetContactInformationByContactName(string contactName, int accountId)
        {
            Contact contact = await dbConnection.Contacts.Where(x => x.FirstName == contactName).FirstOrDefaultAsync();
            return contact;
        }

        public async Task<List<Contact>> GetContacts(int accountId, string contactName, DataGridPagingInformation paging)
        {
            string sortExpression = paging.SortExpression;
            string sortDirection = paging.SortDirection;

            if (string.IsNullOrEmpty(sortExpression))
            {
                sortExpression = "FirstName";
            }

            if (paging.SortDirection != string.Empty)
                sortExpression = sortExpression + " " + paging.SortDirection;

            int numberOfRows = 0;

            var query = dbConnection.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(contactName) && contactName.Trim().Length > 0 )
            {
                query = query.Where(p => p.FirstName.Contains(contactName));
            }

            //query = query.Where(p => p.AccountId == accountId);

            var contactResults = from p in query select p;

            numberOfRows = await contactResults.CountAsync();

            List<Contact> contacts = await contactResults.Skip((paging.CurrentPageNumber - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync();

            paging.TotalRows = numberOfRows;
            paging.TotalPages = Utilities.Functions.CalculateTotalPages(numberOfRows, paging.PageSize);

            return contacts;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;

namespace Verdant.Zero.Erp.Api.Data.EntityFramework
{
    public class ZeroErpManagementDataService : EntityFrameworkRepository, ICustomerManagementDataService
    {
       
        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task CreateCustomer(Customer customer)
        {
            DateTime dateCreated = DateTime.UtcNow;
            customer.DateCreated = dateCreated;
            customer.DateUpdated = dateCreated;

            await dbConnection.Customers.AddAsync(customer);

        }

        public Task<List<Customer>> CustomerInquiry(int accountId, string customerName, DataGridPagingInformation paging)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get Customer Information
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomerInformation(int accountId, int customerId)
        {
            Customer customer = await dbConnection.Customers.Where(x => x.CustomerId == customerId && x.AccountId == accountId).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<Customer> GetCustomerInformationByCustomerName(string customerName, int accountId)
        {
            Customer customer = await dbConnection.Customers.Where(x => x.Name == customerName && x.AccountId == accountId).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<List<Customer>> GetCustomers(int accountId, string customerName, DataGridPagingInformation paging)
        {
            string sortExpression = paging.SortExpression;
            string sortDirection = paging.SortDirection;

            if (string.IsNullOrEmpty(sortExpression))
            {
                sortExpression = "Name";
            }

            if (paging.SortDirection != string.Empty)
                sortExpression = sortExpression + " " + paging.SortDirection;

            int numberOfRows = 0;

            var query = dbConnection.Customers.AsQueryable();

            if (customerName.Trim().Length > 0)
            {
                query = query.Where(p => p.Name.Contains(customerName));
            }

            //query = query.Where(p => p.AccountId == accountId);

            var customerResults = from p in query select p;

            numberOfRows = await customerResults.CountAsync();

            List<Customer> customers = await customerResults.Skip((paging.CurrentPageNumber - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync();

            paging.TotalRows = numberOfRows;
            paging.TotalPages = Utilities.Functions.CalculateTotalPages(numberOfRows, paging.PageSize);

            return customers;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Data.EntityFramework;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;

namespace Verdant.Zero.Erp.Api.EntityFramework
{
    public class ProductManagementDataService : EntityFrameworkRepository, IProductManagementDataService
    {       
        public async Task CreateProduct(Product account)
        {
            DateTime dateCreated = DateTime.UtcNow;
            account.CreatedAt = dateCreated;
            account.UpdatedAt = dateCreated;

            await dbConnection.Products.AddAsync(account);
        }
        
        public async Task UpdateProduct(Product account)
        {
            await Task.Delay(0);
            account.UpdatedAt = DateTime.UtcNow;
        }
        
        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProducts(string status, string name, DataGridPagingInformation paging)
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

            var query = dbConnection.Products.AsQueryable();

            if (name.Trim().Length > 0)
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            //query = query.Where(p => p.AccountId == accountId);

            var resultsList = from p in query select p;

            numberOfRows = await resultsList.CountAsync();

            List<Product> products = await resultsList.Skip((paging.CurrentPageNumber - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync();

            paging.TotalRows = numberOfRows;
            paging.TotalPages = Utilities.Functions.CalculateTotalPages(numberOfRows, paging.PageSize);

            return products;
        }

        public async Task<Product> GetProductByName(string name)
        {
            Product product = await dbConnection.Products.Where(x => x.Name == name).FirstOrDefaultAsync();
            return product;
        }

        public async Task<Product> GetProductBySku(string sku)
        {
            Product product = await dbConnection.Products.Where(x => x.Sku == sku).FirstOrDefaultAsync();
            return product;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Data.Interfaces;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Transformation;

namespace Verdant.Zero.Erp.Api.Interfaces
{
    public interface IProductManagementDataService : IDataRepository,IDisposable
    {
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);        
        Task<List<Product>> GetProducts(string status, string name, DataGridPagingInformation paging);
        Task<Product> GetProductByName(string name);
        Task<Product> GetProductBySku(string sku);

    }
}

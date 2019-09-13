using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Transformations;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Transformation;

namespace Verdant.Zero.Erp.Api.Interfaces
{
    public interface IProductManagementBusinessService : IDisposable
    {        
        Task<ResponseModel<ProductDataTransformation>> CreateProduct(ProductDataTransformation productDataTransformation);
        Task<ResponseModel<ProductDataTransformation>> UpdateProduct(ProductDataTransformation productDataTransformation);
        Task<ResponseModel<ProductDataTransformation>> DeleteProduct(int id);
        Task<ResponseModel<List<ProductDataTransformation>>> GetProduct(string searchText, int currentPageNumber, int pageSize, string sortExpression, string sortDirection);

    }
}

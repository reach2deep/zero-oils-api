using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Transformation;
using Verdant.Zero.Erp.Api.Data.BusinessRules;
using Verdant.Zero.Erp.Api.DataModel.Transformations;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using AutoMapper;

namespace Verdant.Zero.Erp.Api.Data.Buisness
{
    public class ProductManagementBusinessService : IProductManagementBusinessService
    {
        private readonly IProductManagementDataService _productManagementDataService;
        private readonly ConnectionStrings _connectionStrings;
        private readonly IMapper _mapper;
        public IConfiguration configuration { get; }

        public ProductManagementBusinessService(IProductManagementDataService productManagementDataService, 
            ConnectionStrings connectionStrings, IMapper mapper)
        {
            _productManagementDataService = productManagementDataService;
            _connectionStrings = connectionStrings;
            _mapper = mapper;
        }


        public async Task<ResponseModel<ProductDataTransformation>> CreateProduct(ProductDataTransformation productDataTransformation)
        {

            ResponseModel<ProductDataTransformation> returnResponse = new ResponseModel<ProductDataTransformation>();

            Product product = new Product();

            try
            {
                _productManagementDataService.OpenConnection(_connectionStrings.PrimaryDatabaseConnectionString);
                _productManagementDataService.BeginTransaction((int)IsolationLevel.Serializable);

                ProductBusinessRules<ProductDataTransformation> productBusinessRules = new ProductBusinessRules<ProductDataTransformation>(productDataTransformation, _productManagementDataService);
                ValidationResult validationResult = await productBusinessRules.Validate();
                if (validationResult.ValidationStatus == false)
                {
                    _productManagementDataService.RollbackTransaction();

                    returnResponse.ReturnMessage = validationResult.ValidationMessages;
                    returnResponse.ReturnStatus = validationResult.ValidationStatus;

                    return returnResponse;
                }

                product = _mapper.Map<Product>(productDataTransformation);
                product.Dimension = _mapper.Map<Dimension>(productDataTransformation);
                product.SalesInformation = _mapper.Map<SalesInformation>(productDataTransformation);
                product.PurchaseInformation = _mapper.Map<PurchaseInformation>(productDataTransformation);
                product.InventoryAccount = _mapper.Map<InventoryAccount>(productDataTransformation);

                await _productManagementDataService.CreateProduct(product);

                await _productManagementDataService.UpdateDatabase();

                _productManagementDataService.CommitTransaction();

                returnResponse.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                _productManagementDataService.RollbackTransaction();
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
            }
            finally
            {
                _productManagementDataService.CloseConnection();
            }

            returnResponse.Entity = productDataTransformation;

            return returnResponse;

        }
              

        public async Task<ResponseModel<ProductDataTransformation>> UpdateProduct(ProductDataTransformation productDataTransformation)
        {
            ResponseModel<ProductDataTransformation> returnResponse = new ResponseModel<ProductDataTransformation>();

            Product product = new Product();

            try
            {
                _productManagementDataService.OpenConnection(_connectionStrings.PrimaryDatabaseConnectionString);
                _productManagementDataService.BeginTransaction((int)IsolationLevel.Serializable);

                ProductBusinessRules<ProductDataTransformation> productBusinessRules = new ProductBusinessRules<ProductDataTransformation>(productDataTransformation, _productManagementDataService);
                ValidationResult validationResult = await productBusinessRules.Validate();
                if (validationResult.ValidationStatus == false)
                {
                    _productManagementDataService.RollbackTransaction();

                    returnResponse.ReturnMessage = validationResult.ValidationMessages;
                    returnResponse.ReturnStatus = validationResult.ValidationStatus;

                    return returnResponse;
                }

                product = _mapper.Map<Product>(productDataTransformation);
                product.Dimension = _mapper.Map<Dimension>(productDataTransformation);
                product.SalesInformation = _mapper.Map<SalesInformation>(productDataTransformation);
                product.PurchaseInformation = _mapper.Map<PurchaseInformation>(productDataTransformation);
                product.InventoryAccount = _mapper.Map<InventoryAccount>(productDataTransformation);

                await _productManagementDataService.UpdateProduct(product);

                await _productManagementDataService.UpdateDatabase();

                _productManagementDataService.CommitTransaction();

                returnResponse.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                _productManagementDataService.RollbackTransaction();
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
            }
            finally
            {
                _productManagementDataService.CloseConnection();
            }

            returnResponse.Entity = productDataTransformation;

            return returnResponse;

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ProductDataTransformation>> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductDataTransformation>>> GetProduct(string searchText, int currentPageNumber, int pageSize, string sortExpression, string sortDirection)
        {
            ResponseModel<List<ProductDataTransformation>> returnResponse = new ResponseModel<List<ProductDataTransformation>>();

            List<ProductDataTransformation> salesOrders = new List<ProductDataTransformation>();

            try
            {
                _productManagementDataService.OpenConnection(_connectionStrings.PrimaryDatabaseConnectionString);

                DataGridPagingInformation dataGridPagingInformation = new DataGridPagingInformation();
                dataGridPagingInformation.CurrentPageNumber = currentPageNumber;
                dataGridPagingInformation.PageSize = pageSize;
                dataGridPagingInformation.SortDirection = sortDirection;
                dataGridPagingInformation.SortExpression = sortExpression;

                List<Product> productsList = await _productManagementDataService.GetProducts(searchText, searchText, dataGridPagingInformation);
                foreach (Product product in productsList)
                {
                    ProductDataTransformation productDataTransformation = new ProductDataTransformation();
                    productDataTransformation = _mapper.Map<ProductDataTransformation>(product);
                    salesOrders.Add(productDataTransformation);
                }

                returnResponse.Entity = salesOrders;
                returnResponse.TotalRows = dataGridPagingInformation.TotalRows;
                returnResponse.TotalPages = dataGridPagingInformation.TotalPages;

                returnResponse.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                _productManagementDataService.RollbackTransaction();
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
            }
            finally
            {
                _productManagementDataService.CloseConnection();
            }

            return returnResponse;
        }
    }
}

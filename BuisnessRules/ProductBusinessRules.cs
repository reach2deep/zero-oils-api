using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;

namespace Verdant.Zero.Erp.Api.Data.BusinessRules
{
    public class ProductBusinessRules<T> : ValidationRules<T>
    {
        public T _entity;

        IProductManagementDataService _productManagementDataService;

        public ProductBusinessRules(T entity, IProductManagementDataService productManagementDataService) : base(entity)
        {
            _productManagementDataService = productManagementDataService;
            _entity = entity;

        }

        public async Task<ValidationResult> Validate()
        {
            ValidateRequired("name", "Name");
            ValidateRequired("sku", "Sku");

            await ValidateUniqueProductName("name");
            await ValidateUniqueSku("sku");


            return ValidationResult;
        }
       
        private async Task ValidateUniqueProductName(string productName)
        {
            object valueOfProductName = GetPropertyValue(productName);        

            Product product = await _productManagementDataService.GetProductByName(valueOfProductName.ToString());

            if (product != null && product.Name == valueOfProductName.ToString())
            {
                AddValidationError(productName, "Product Name already exists.");
                return;
            }
        }
        private async Task ValidateUniqueSku(string sku)
        {
            object valueOfSku = GetPropertyValue(sku);

            Product product = await _productManagementDataService.GetProductBySku(valueOfSku.ToString());

            if (product != null && product.Sku == valueOfSku.ToString())
            {
                AddValidationError(sku, "SKU already exists.");
                return;
            }
        }
    }
}

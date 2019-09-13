using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Verdant.Zero.Erp.Api.DataModel.Transformations;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Shared.Models;
using Verdant.Zero.Erp.Api.Transformation;

namespace Verdant.Zero.Erp.Api.Controllers
{
    //[ServiceFilter(typeof(SecurityFilter))]
    //[Authorize]
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductManagementBusinessService _productManagementBusinessService;

        public IConfiguration configuration { get; }

        public ProductController(IProductManagementBusinessService productManagementBusinessService)
        {
            _productManagementBusinessService = productManagementBusinessService;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDataTransformation productDataTransformation)
        {

            //SecurityModel securityModel = (SecurityModel)(HttpContext.Items["SecurityModel"]);

            //int accountId = securityModel.AccountId;

            // productDataTransformation.AccountId = accountId;

            ResponseModel<ProductDataTransformation> returnResponse = new ResponseModel<ProductDataTransformation>();
            try
            {
                returnResponse = await _productManagementBusinessService.CreateProduct(productDataTransformation);
                // returnResponse.Token = securityModel.Token;
                if (returnResponse.ReturnStatus == false)
                {
                    return BadRequest(returnResponse);
                }

                return Ok(returnResponse);

            }
            catch (Exception ex)
            {
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
                return BadRequest(returnResponse);
            }

        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDataTransformation productDataTransformation)
        {

            SecurityModel securityModel = (SecurityModel)(HttpContext.Items["SecurityModel"]);

            // int accountId = securityModel.AccountId;

            //productDataTransformation.AccountId = accountId;
            //
            ResponseModel<ProductDataTransformation> returnResponse = new ResponseModel<ProductDataTransformation>();
            try
            {
                returnResponse = await _productManagementBusinessService.UpdateProduct(productDataTransformation);
                returnResponse.Token = securityModel.Token;
                if (returnResponse.ReturnStatus == false)
                {
                    return BadRequest(returnResponse);
                }

                return Ok(returnResponse);

            }
            catch (Exception ex)
            {
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
                return BadRequest(returnResponse);
            }

        }


        [HttpPost]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts([FromBody] ListDataTransformation listDataTransformation)
        {

            //SecurityModel securityModel = (SecurityModel)(HttpContext.Items["SecurityModel"]);

            //int accountId = securityModel.AccountId;
            string searchText = listDataTransformation.SearchText;
            int pageSize = listDataTransformation.PageSize;
            int currentPageNumber = listDataTransformation.CurrentPageNumber;
            string sortDirection = listDataTransformation.SortDirection;
            string sortExpression = listDataTransformation.SortExpression;

            ResponseModel<List<ProductDataTransformation>> returnResponse = new ResponseModel<List<ProductDataTransformation>>();

            try
            {
                returnResponse = await _productManagementBusinessService.GetProduct(searchText, currentPageNumber, pageSize, sortExpression, sortDirection);
                //   returnResponse.Token = securityModel.Token;
                if (returnResponse.ReturnStatus == false)
                {
                    return BadRequest(returnResponse);
                }

                return Ok(returnResponse);

            }
            catch (Exception ex)
            {
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
                return BadRequest(returnResponse);
            }

        }


    }
}
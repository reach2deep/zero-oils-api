using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Security;
using Verdant.Zero.Erp.Api.Shared.Models;
using Verdant.Zero.Erp.Api.Transformation;

namespace Verdant.Zero.Erp.Api.Controllers
{
    [ServiceFilter(typeof(SecurityFilter))]
    //[Authorize]
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerManagementBusinessService _customerManagementBusinessService;

        public IConfiguration configuration { get; }

        public CustomerController(ICustomerManagementBusinessService customerManagementBusinessService)
        {
            _customerManagementBusinessService = customerManagementBusinessService;
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDataTransformation customerDataTransformation)
        {

            SecurityModel securityModel = (SecurityModel)(HttpContext.Items["SecurityModel"]);

            int accountId = securityModel.AccountId;

            customerDataTransformation.AccountId = accountId;

            ResponseModel<CustomerDataTransformation> returnResponse = new ResponseModel<CustomerDataTransformation>();
            try
            {
                returnResponse = await _customerManagementBusinessService.CreateCustomer(customerDataTransformation);
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
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomers([FromBody] ListDataTransformation listDataTransformation)
        {

            SecurityModel securityModel = (SecurityModel)(HttpContext.Items["SecurityModel"]);

            int accountId = securityModel.AccountId;
            string customerName = listDataTransformation.CustomerName;
            int pageSize = listDataTransformation.PageSize;
            int currentPageNumber = listDataTransformation.CurrentPageNumber;
            string sortDirection = listDataTransformation.SortDirection;
            string sortExpression = listDataTransformation.SortExpression;

            ResponseModel<List<CustomerDataTransformation>> returnResponse = new ResponseModel<List<CustomerDataTransformation>>();

            try
            {
                returnResponse = await _customerManagementBusinessService.GetCustomer(accountId, customerName, currentPageNumber, pageSize, sortExpression, sortDirection);
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


    }
}
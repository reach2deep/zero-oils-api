using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Verdant.Zero.Erp.Api.DataModel.Transformations;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Security;
using Verdant.Zero.Erp.Api.Shared.Models;
using Verdant.Zero.Erp.Api.Transformation;

namespace Verdant.Zero.Erp.Api.Controllers
{
    //[ServiceFilter(typeof(SecurityFilter))]
    //[Authorize]
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactManagementBusinessService _contactManagementBusinessService;

        public IConfiguration configuration { get; }

        public ContactController(IContactManagementBusinessService contactManagementBusinessService)
        {
            _contactManagementBusinessService = contactManagementBusinessService;
        }

        [HttpPost]
        [Route("CreateContact")]
        public async Task<IActionResult> CreateContact([FromBody] ContactDataTransformation contactDataTransformation)
        {

            //SecurityModel securityModel = (SecurityModel)(HttpContext.Items["SecurityModel"]);

            //int accountId = securityModel.AccountId;

           // contactDataTransformation.AccountId = accountId;

            ResponseModel<ContactDataTransformation> returnResponse = new ResponseModel<ContactDataTransformation>();
            try
            {
                returnResponse = await _contactManagementBusinessService.CreateContact(contactDataTransformation);
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
        [Route("UpdateContact")]
        public async Task<IActionResult> UpdateContact([FromBody] ContactDataTransformation contactDataTransformation)
        {

            SecurityModel securityModel = (SecurityModel)(HttpContext.Items["SecurityModel"]);

           // int accountId = securityModel.AccountId;

            //contactDataTransformation.AccountId = accountId;
            //
            ResponseModel<ContactDataTransformation> returnResponse = new ResponseModel<ContactDataTransformation>();
            try
            {
                returnResponse = await _contactManagementBusinessService.UpdateContact(contactDataTransformation);
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
        [Route("GetContacts")]
        public async Task<IActionResult> GetContacts([FromBody] ListDataTransformation listDataTransformation)
        {

            //SecurityModel securityModel = (SecurityModel)(HttpContext.Items["SecurityModel"]);

            //int accountId = securityModel.AccountId;
            string searchText = listDataTransformation.SearchText;
            int pageSize = listDataTransformation.PageSize;
            int currentPageNumber = listDataTransformation.CurrentPageNumber;
            string sortDirection = listDataTransformation.SortDirection;
            string sortExpression = listDataTransformation.SortExpression;

            ResponseModel<List<ContactDataTransformation>> returnResponse = new ResponseModel<List<ContactDataTransformation>>();

            try
            {
                returnResponse = await _contactManagementBusinessService.GetContact(1, searchText, currentPageNumber, pageSize, sortExpression, sortDirection);
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
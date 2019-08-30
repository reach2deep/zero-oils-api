using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Verdant.Zero.Erp.Api.DataModel.Transformations;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Shared.Utilities;

namespace Verdant.Zero.Erp.Api.Controllers
{
	[Route("api/[controller]")]
	[EnableCors("SiteCorsPolicy")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{

		private readonly IAccountManagementBusinessService _accountBusinessService;

		public IConfiguration configuration { get; }

		/// <summary>
		/// Movies Controller
		/// </summary>
		public AuthorizationController(IAccountManagementBusinessService accountBusinessService)
		{
			_accountBusinessService = accountBusinessService;
		}

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="accountDataTransformation"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] AccountDataTransformation accountDataTransformation)
		{
			ResponseModel<AccountDataTransformation> returnResponse = new ResponseModel<AccountDataTransformation>();
			try
			{
				returnResponse = await _accountBusinessService.Login(accountDataTransformation);
				if (returnResponse.ReturnStatus == true)
				{
					int userId = returnResponse.Entity.UserId;
					int accountId = returnResponse.Entity.AccountId;
					string firstName = returnResponse.Entity.FirstName;
					string lastName = returnResponse.Entity.LastName;
					string emailAddress = returnResponse.Entity.EmailAddress;
					string companyName = returnResponse.Entity.CompanyName;

					string tokenString = TokenManagement.CreateToken(userId, firstName, lastName, emailAddress, accountId, companyName);
					returnResponse.Entity.IsAuthenicated = true;
					returnResponse.Entity.Token = tokenString;
					return Ok(returnResponse);
				}
				else
				{
					return BadRequest(returnResponse);
				}

			}
			catch (Exception ex)
			{
				returnResponse.ReturnStatus = false;
				returnResponse.ReturnMessage.Add(ex.Message);
				return BadRequest(returnResponse);
			}

		}

		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] AccountDataTransformation accountDataTransformation)
		{
			ResponseModel<AccountDataTransformation> returnResponse = new ResponseModel<AccountDataTransformation>();
			try
			{
				returnResponse = await _accountBusinessService.Register(accountDataTransformation);
				if (returnResponse.ReturnStatus == true)
				{
					int userId = returnResponse.Entity.UserId;
					int accountId = returnResponse.Entity.AccountId;
					string firstName = returnResponse.Entity.FirstName;
					string lastName = returnResponse.Entity.LastName;
					string emailAddress = returnResponse.Entity.EmailAddress;
					string companyName = returnResponse.Entity.CompanyName;

					string tokenString = TokenManagement.CreateToken(userId, firstName, lastName, emailAddress, accountId, companyName);
					returnResponse.Entity.IsAuthenicated = true;
					returnResponse.Entity.Token = tokenString;
					return Ok(returnResponse);

				}
				else
				{
					return BadRequest(returnResponse);
				}

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
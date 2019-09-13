using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Verdant.Zero.Erp.Api.DataModel.Entities;

namespace Verdant.Zero.Erp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
           // string result = string.Empty;

            var product = new Product();
            product.Dimension = new Dimension();
            product.SalesInformation = new SalesInformation();
            product.PurchaseInformation = new PurchaseInformation();
            product.InventoryAccount = new InventoryAccount();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(product, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            json = json.Replace("\"", "");

           /// result = JsonConvert.SerializeObject(product, Formatting.Indented);
            return json;
        }

        //[HttpGet]
        //public ActionResult<string> ConvertToJson()
        //{
        //    string result = string.Empty;

        //    var product = new Product();
        //    product.Dimension = new Dimension();
        //    product.SalesInformation = new SalesInformation();
        //    product.PurchaseInformation = new PurchaseInformation();
        //    product.InventoryAccount = new InventoryAccount();

        //    result = JsonConvert.SerializeObject(product, Formatting.Indented);
        //    return result;
        //    //return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

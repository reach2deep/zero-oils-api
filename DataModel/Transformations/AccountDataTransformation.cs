using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.DataModel.Transformations
{
    public class AccountDataTransformation
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Token { get; set; }
        public bool IsAuthenicated { get; set; }
    }
}

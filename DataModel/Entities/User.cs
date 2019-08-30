using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.DataModel.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountId { get; set; }
        public int UserTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateLastLogin { get; set; }
        public Account Account { get; set; }
        public UserType UserType { get; set; }
    }

    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int PurchasedApplications { get; set; }
    }

    public class Application
    {
        public int ApplicationId { get; set; }
        public string Description { get; set; }
        public string ApplicationCode { get; set; }
        public int ApplicationSeed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }

    public class UserType
    {
        public int UserTypeId { get; set; }
        public string Description { get; set; }
    }
}

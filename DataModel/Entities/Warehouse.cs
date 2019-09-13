using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.DataModel.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

    }
}

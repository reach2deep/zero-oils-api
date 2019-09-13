using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.DataModel.Entities
{
    public class PurchaseOrder
    {
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string DeliveryTo { get; set; }
        public Warehouse Warehouse { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string ShipmentReference { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.DataModel.Transformations
{
    public class ProductDataTransformation
    {
        public int id { get; set; }
        public string item_type { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string uom { get; set; }
        public bool is_returnable { get; set; }
        public double dimension_length { get; set; }
        public double dimension_width { get; set; }
        public double dimension_height { get; set; }
        public double dimension_weight { get; set; }
        public string manufacturer { get; set; }
        public string brand { get; set; }
        public string upc { get; set; }
        public string mpn { get; set; }
        public string ean { get; set; }
        public string isbn { get; set; }
        public double sales_information_selling_price { get; set; }
        public string sales_information_account { get; set; }
        public string sales_information_description { get; set; }
        public string purchase_information_purchase_price { get; set; }
        public string purchase_information_account { get; set; }
        public string purchase_information_description { get; set; }
        public int inventory_account_id { get; set; }
        public string inventory_account_name { get; set; }
        public double inventory_account_opening_stock { get; set; }
        public double inventory_account_opening_stock_value_per_unit { get; set; }
        public string image_path { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.DataModel.Entities
{
    public class Product : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string ItemType { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Uom { get; set; }
        [Column(TypeName = "TINYINT(1)")]
        public bool IsReturnable { get; set; }
        public Dimension Dimension { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Upc { get; set; }
        public string Mpn { get; set; }
        public string Ean { get; set; }
        public string Isbn { get; set; }        
        public SalesInformation SalesInformation { get; set; }
        public PurchaseInformation PurchaseInformation { get; set; }
        public InventoryAccount InventoryAccount { get; set; }
        public string ImagePath { get; set; }


    }

    public class Dimension
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }

    public class SalesInformation
    {
        public double SellingPrice { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
    }

    public class PurchaseInformation
    {
        public double PurchasePrice { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
    }

    public class InventoryAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double OpeningStock { get; set; }
        public double OpeningStockValuePerUnit { get; set; }
    }

    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProductId")]
        public int ProductCode { get; set; }
        public string WarehouseCode { get; set; }
        public double AccountingStockOnHand { get; set; }
        public double AccountingStockAvailForSale { get; set; }
        public double AccountingCommittedStock { get; set; }
        public double PhysicalStockOnHand { get; set; }
        public double PhysicalStockAvailForSale { get; set; }
        public double PhysicalCommittedStock { get; set; }
    }

    
}

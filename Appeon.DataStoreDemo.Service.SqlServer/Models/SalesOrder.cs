using SnapObjects.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using DWNet.Data;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_salesorder", DwStyle.Grid)]
    [Table("SalesOrderHeader", Schema = "Sales")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Sales.SalesOrderHeader\" ) COLUMN(NAME=\"Sales.SalesOrderHeader.SalesOrderID\") COLUMN(NAME=\"Sales.SalesOrderHeader.RevisionNumber\") COLUMN(NAME=\"Sales.SalesOrderHeader.OrderDate\") COLUMN(NAME=\"Sales.SalesOrderHeader.DueDate\") COLUMN(NAME=\"Sales.SalesOrderHeader.ShipDate\") COLUMN(NAME=\"Sales.SalesOrderHeader.Status\") COLUMN(NAME=\"Sales.SalesOrderHeader.OnlineOrderFlag\") COMPUTE(NAME=\"(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***')) AS [SalesOrderNumber]\") COLUMN(NAME=\"Sales.SalesOrderHeader.PurchaseOrderNumber\") COLUMN(NAME=\"Sales.SalesOrderHeader.AccountNumber\") COLUMN(NAME=\"Sales.SalesOrderHeader.CustomerID\") COLUMN(NAME=\"Sales.SalesOrderHeader.SalesPersonID\") COLUMN(NAME=\"Sales.SalesOrderHeader.TerritoryID\") COLUMN(NAME=\"Sales.SalesOrderHeader.BillToAddressID\") COLUMN(NAME=\"Sales.SalesOrderHeader.ShipToAddressID\") COLUMN(NAME=\"Sales.SalesOrderHeader.ShipMethodID\") COLUMN(NAME=\"Sales.SalesOrderHeader.CreditCardID\") COLUMN(NAME=\"Sales.SalesOrderHeader.CreditCardApprovalCode\") COLUMN(NAME=\"Sales.SalesOrderHeader.CurrencyRateID\") COLUMN(NAME=\"Sales.SalesOrderHeader.SubTotal\") COLUMN(NAME=\"Sales.SalesOrderHeader.TaxAmt\") COLUMN(NAME=\"Sales.SalesOrderHeader.Freight\") COLUMN(NAME=\"Sales.SalesOrderHeader.TotalDue\") COLUMN(NAME=\"Sales.SalesOrderHeader.Comment\") COLUMN(NAME=\"Sales.SalesOrderHeader.ModifiedDate\"))")]
    #endregion
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class SalesOrder
    {
        [Key]
        [Identity]
        [DwColumn("SalesOrderID")]
        public int SalesOrderID { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("((0))")]
        [DwColumn("RevisionNumber")]
        public byte RevisionNumber { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("(getdate())")]
        [DwColumn("OrderDate", TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [ConcurrencyCheck]
        [DwColumn("DueDate", TypeName = "datetime")]
        public DateTime DueDate { get; set; }

        [ConcurrencyCheck]
        [DwColumn("ShipDate", TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("((1))")]
        [DwColumn("Status")]
        public byte Status { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("((1))")]
        [DwColumn("OnlineOrderFlag")]
        public bool OnlineOrderFlag { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))")]
        public string SalesOrderNumber { get; set; }

        [ConcurrencyCheck]
        [StringLength(25)]
        [DwColumn("PurchaseOrderNumber")]
        public string PurchaseOrderNumber { get; set; }

        [ConcurrencyCheck]
        [StringLength(15)]
        [DwColumn("AccountNumber")]
        public string AccountNumber { get; set; }

        [ConcurrencyCheck]
        [DwColumn("CustomerID")]
        public int CustomerID { get; set; }

        [ConcurrencyCheck]
        [DwColumn("SalesPersonID")]
        public int? SalesPersonID { get; set; }

        [ConcurrencyCheck]
        [DwColumn("TerritoryID")]
        public int? TerritoryID { get; set; }

        [ConcurrencyCheck]
        [DwColumn("BillToAddressID")]
        public int BillToAddressID { get; set; }

        [ConcurrencyCheck]
        [DwColumn("ShipToAddressID")]
        public int ShipToAddressID { get; set; }

        [ConcurrencyCheck]
        [DwColumn("ShipMethodID")]
        public int ShipMethodID { get; set; }

        [DisplayName("Credit Card ID")]// Manually add
        [ConcurrencyCheck]
        [DwColumn("CreditCardID")]
        public int? CreditCardID { get; set; }

        [ConcurrencyCheck]
        [StringLength(15)]
        [DwColumn("CreditCardApprovalCode")]
        public string CreditCardApprovalCode { get; set; }

        [ConcurrencyCheck]
        [DwColumn("CurrencyRateID")]
        public int? CurrencyRateID { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("((0.00))")]
        [DwColumn("SubTotal")]
        public decimal SubTotal { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("((0.00))")]
        [DwColumn("TaxAmt")]
        public decimal TaxAmt { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("((0.00))")]
        [DwColumn("Freight")]
        public decimal Freight { get; set; }

        [ConcurrencyCheck]
        [DwColumn("TotalDue")]
        [PropertySave(SaveStrategy.ReadAfterSave)]
        public decimal TotalDue { get; set; }

        [ConcurrencyCheck]
        [StringLength(128)]
        [DwColumn("Comment")]
        public string Comment { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("(getdate())")]
        [DwColumn("ModifiedDate", TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public IList<SalesOrderDetail> OrderDetails { get; set; }
    }
}

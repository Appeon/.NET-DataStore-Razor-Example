using DWNet.Data;
using SnapObjects.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_order_detail_free", DwStyle.Default)]
    [Table("SalesOrderDetail", Schema = "Sales")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Sales.SalesOrderDetail\" ) COLUMN(NAME=\"Sales.SalesOrderDetail.salesorderid\") COLUMN(NAME=\"Sales.SalesOrderDetail.salesorderdetailid\") COLUMN(NAME=\"Sales.SalesOrderDetail.carriertrackingnumber\") COLUMN(NAME=\"Sales.SalesOrderDetail.orderqty\") COLUMN(NAME=\"Sales.SalesOrderDetail.productid\") COLUMN(NAME=\"Sales.SalesOrderDetail.specialofferid\") COLUMN(NAME=\"Sales.SalesOrderDetail.unitprice\") COLUMN(NAME=\"Sales.SalesOrderDetail.unitpricediscount\") COLUMN(NAME=\"Sales.SalesOrderDetail.linetotal\") COLUMN(NAME=\"Sales.SalesOrderDetail.modifieddate\")WHERE(    EXP1 =\"Sales.SalesOrderDetail.SalesOrderID\"   OP =\"=\"    EXP2 =\":al_order_id\" ) ) ORDER(NAME=\"Sales.SalesOrderDetail.salesorderdetailid\" ASC=yes ) ARG(NAME = \"al_order_id\" TYPE = number) ")]
    #endregion
    [DwParameter("al_order_id", typeof(decimal?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }

        [Key]
        [Identity]
        [DisplayName("ID")]// Manually add
        public int SalesOrderDetailID { get; set; }

        [DisplayName("Carrier Tracking Number")]// Manually add
        public string CarrierTrackingNumber { get; set; }

        [DisplayName("Order Qty")]// Manually add
        public int OrderQty { get; set; }

        [Required]
        [DisplayName("Product")]// Manually add
        public int ProductID { get; set; }

        [Required]
        [DisplayName("Special Offer ID")]// Manually add
        public int SpecialOfferID { get; set; }

        [Required]
        [DisplayName("Unit Price")]// Manually add
        [DataType(DataType.Currency)]// Manually add
        public decimal UnitPrice { get; set; }

        [DisplayName("Unit Price Discount")]// Manually add
        [DataType(DataType.Currency)]// Manually add
        [Range(0, 1)]
        public decimal? UnitPriceDiscount { get; set; }

        [DisplayName("Line Total")]// Manually add
        [DataType(DataType.Currency)]// Manually add
        [PropertySave(SaveStrategy.ReadAfterSave)]
        public decimal? LineTotal { get; set; }

        [DisplayName("Modified Date")]// Manually add
        [DataType(DataType.Date)]// Manually add
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [PropertySave(SaveStrategy.ReadAfterSave)]
        public DateTime ModifiedDate { get; set; }
    }
}

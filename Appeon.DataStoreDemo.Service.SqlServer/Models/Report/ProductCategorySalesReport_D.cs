using DWNet.Data;
using SnapObjects.Data;
using System.ComponentModel.DataAnnotations;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_productcategorysalesreport_d", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Production.Product\" )  TABLE(NAME=\"Sales.SalesOrderDetail\" )  TABLE(NAME=\"Sales.SalesOrderHeader\" )  TABLE(NAME=\"Production.ProductCategory\" )  TABLE(NAME=\"Production.ProductSubcategory\" ) @(_COLUMNS_PLACEHOLDER_) JOIN (LEFT=\"Sales.SalesOrderDetail.SalesOrderID\"    OP =\"=\"RIGHT=\"Sales.SalesOrderHeader.SalesOrderID\"    OUTER1 =\"Sales.SalesOrderDetail.SalesOrderID\" )    JOIN (LEFT=\"Sales.SalesOrderDetail.ProductID\"    OP =\"=\"RIGHT=\"Production.Product.ProductID\"    OUTER1 =\"Sales.SalesOrderDetail.ProductID\" )    JOIN (LEFT=\"Production.Product.ProductSubcategoryID\"    OP =\"=\"RIGHT=\"Production.ProductSubcategory.ProductSubcategoryID\"    OUTER1 =\"Production.Product.ProductSubcategoryID\" )    JOIN (LEFT=\"Production.ProductSubcategory.ProductCategoryID\"    OP =\"=\"RIGHT=\"Production.ProductCategory.ProductCategoryID\"    OUTER1 =\"Production.ProductSubcategory.ProductCategoryID\" )WHERE(    EXP1 =\"Sales.SalesOrderHeader.Status\"   OP =\"in\"    EXP2 =\"1,2,5\"    LOGIC =\"and\" ) WHERE(    EXP1 =\"left(convert(varchar(8), SalesOrderHeader.OrderDate, 112), 6)\"   OP =\"=\"    EXP2 =\":salesMonth\" )  GROUP(NAME=\"Production.ProductCategory.ProductCategoryID\") GROUP(NAME=\"Production.ProductCategory.Name\")) ORDER(NAME=\"Production.ProductCategory.ProductCategoryID\" ASC=yes )  ORDER(NAME=\"Production.ProductCategory.Name\" ASC=yes ) ARG(NAME = \"salesMonth\" TYPE = string)")]
    #endregion
    [DwParameter("salesMonth", typeof(string))]
    public class ProductCategorySalesReport_D
    {
        [StringLength(50)]
        [DwColumn("Production.ProductCategory", "Name")]
        public string ProductCategoryName { get; set; }

        [SqlCompute("sum(SalesOrderDetail.orderqty)", "TotalSalesqty")]
        public int TotalSalesqty { get; set; }

        [SqlCompute("sum(SalesOrderDetail.linetotal)", "TotalSaleroom")]
        public decimal Totalsaleroom { get; set; }

    }

}

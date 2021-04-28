using DWNet.Data;
using SnapObjects.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_categorysalesreportbyyear_d", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Production.Product\" )  TABLE(NAME=\"Sales.SalesOrderDetail\" )  TABLE(NAME=\"Sales.SalesOrderHeader\" )  TABLE(NAME=\"Production.ProductCategory\" )  TABLE(NAME=\"Production.ProductSubcategory\" ) @(_COLUMNS_PLACEHOLDER_) JOIN (LEFT=\"Sales.SalesOrderDetail.SalesOrderID\"    OP =\"=\"RIGHT=\"Sales.SalesOrderHeader.SalesOrderID\"    OUTER1 =\"Sales.SalesOrderDetail.SalesOrderID\" )    JOIN (LEFT=\"Sales.SalesOrderDetail.ProductID\"    OP =\"=\"RIGHT=\"Production.Product.ProductID\"    OUTER1 =\"Sales.SalesOrderDetail.ProductID\" )    JOIN (LEFT=\"Production.Product.ProductSubcategoryID\"    OP =\"=\"RIGHT=\"Production.ProductSubcategory.ProductSubcategoryID\"    OUTER1 =\"Production.Product.ProductSubcategoryID\" )    JOIN (LEFT=\"Production.ProductSubcategory.ProductCategoryID\"    OP =\"=\"RIGHT=\"Production.ProductCategory.ProductCategoryID\"    OUTER1 =\"Production.ProductSubcategory.ProductCategoryID\" )WHERE(    EXP1 =\"Sales.SalesOrderHeader.Status\"   OP =\"in\"    EXP2 =\"1,2,5\"    LOGIC =\"and\" ) WHERE(    EXP1 =\"datepart(YEAR,SalesOrderHeader.OrderDate)\"   OP =\"=\"    EXP2 =\":curYear\" )  GROUP(NAME=\"Production.ProductCategory.ProductCategoryID\") GROUP(NAME=\"Production.ProductCategory.Name\")) ARG(NAME = \"curYear\" TYPE = string)")]
    #endregion
    [DwParameter("curYear", typeof(string))]
    public class CategorySalesReportByYear_D
    {
        [StringLength(50)]
        [DwColumn("Production.ProductCategory", "Name")]
        public string ProductCategoryName { get; set; }

        [SqlCompute("sum(SalesOrderDetail.orderqty)", "TotalSalesqty")]
        public int? TotalSalesqty { get; set; }

        [SqlCompute("sum(SalesOrderDetail.linetotal)", "TotalSaleroom")]
        public decimal? TotalSaleroom { get; set; }

    }
}

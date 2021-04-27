using DWNet.Data;
using SnapObjects.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_dddw_order_production", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Production.Product\" )  TABLE(NAME=\"Production.ProductCategory\" )  TABLE(NAME=\"Production.ProductModel\" )  TABLE(NAME=\"Production.ProductSubcategory\" ) @(_COLUMNS_PLACEHOLDER_) JOIN (LEFT=\"Production.ProductModel.ProductModelID\"    OP =\"=\"RIGHT=\"Production.Product.ProductModelID\" )    JOIN (LEFT=\"Production.ProductSubcategory.ProductCategoryID\"    OP =\"=\"RIGHT=\"Production.ProductCategory.ProductCategoryID\" )    JOIN (LEFT=\"Production.ProductSubcategory.ProductSubcategoryID\"    OP =\"=\"RIGHT=\"Production.Product.ProductSubcategoryID\" )WHERE(    EXP1 =\"\\\"Production\\\".\\\"Product\\\".\\\"FinishedGoodsFlag\\\"\"   OP =\"=\"    EXP2 =\"1\"    LOGIC =\"and\" ) WHERE(    EXP1 =\"\\\"Production\\\".\\\"Product\\\".\\\"ProductID\\\"\"   OP =\"in\" NEST = PBSELECT( VERSION(400) TABLE(NAME=\"Sales.SpecialOfferProduct\" ) COLUMN(NAME=\"Sales.SpecialOfferProduct.ProductID\"))) ) ORDER(NAME=\"Production.Product.ProductID\" ASC=yes )")]
    #endregion
    [DwSort("product_productnumber A")]
    public class DdOrderProduct
    {
        [StringLength(50)]
        [DwColumn("Product", "Name")]
        public string Product_Name { get; set; }

        [StringLength(25)]
        [DwColumn("Product", "ProductNumber")]
        public string Product_Productnumber { get; set; }

        [StringLength(15)]
        [DwColumn("Product", "Color")]
        public string Product_Color { get; set; }

        [DwColumn("Product", "ListPrice")]
        public decimal Product_Listprice { get; set; }

        [StringLength(5)]
        [DwColumn("Product", "Size")]
        public string Product_Size { get; set; }

        [DwColumn("Product", "ProductSubcategoryID")]
        public int? Product_Productsubcategoryid { get; set; }

        [DwColumn("Product", "ProductModelID")]
        public int? Product_Productmodelid { get; set; }

        [StringLength(50)]
        [DwColumn("ProductCategory", "Name")]
        public string Productcategory_Name { get; set; }

        [DwColumn("ProductSubcategory", "ProductCategoryID")]
        public int Productsubcategory_Productcategoryid { get; set; }

        [StringLength(50)]
        [DwColumn("ProductSubcategory", "Name")]
        public string Productsubcategory_Name { get; set; }

        [StringLength(50)]
        [DwColumn("ProductModel", "Name")]
        public string Productmodel_Name { get; set; }

        [DwColumn("Product", "ProductID")]
        public int Product_Productid { get; set; }
    }
}

using SnapObjects.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using DWNet.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_categorysalesreportbyyear", DwStyle.Grid)]
    [Table("ProductCategory", Schema = "Production")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Production.ProductCategory\" ) @(_COLUMNS_PLACEHOLDER_) ) ARG(NAME = \"curYear\" TYPE = string)  ARG(NAME = \"lastYear\" TYPE = string)")]
    #endregion
    [DwParameter("curYear", typeof(string))]
    [DwParameter("lastYear", typeof(string))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class CategorySalesReportByYear
    {
        [Key]
        [Identity]
        [DwColumn("Production.ProductCategory", "ProductCategoryID")]
        public int Productcategoryid { get; set; }

        [ConcurrencyCheck]
        [StringLength(50)]
        [DwColumn("Production.ProductCategory", "Name")]
        public string Name { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("(getdate())")]
        [DwColumn("Production.ProductCategory", "ModifiedDate", TypeName = "datetime")]
        public DateTime Modifieddate { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(CategorySalesReportByYear_D), ParamValues = "curYear")]
        public IList<CategorySalesReportByYear_D> SalesReportByCategory { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(CategorySalesReportByYear_D), ParamValues = "lastYear")]
        public IList<CategorySalesReportByYear_D> LastYearSalesReportByCategory { get; set; }

        public String Json_Categorys { get; set; }

        public String Json_categorysData { get; set; }

        public String Json_totalData { get; set; }

        public String Json_ProductSaleMonth { get; set; }

        public String Json_ProductCategory { get; set; }

        public String Json_ProductSaleSqty { get; set; }
    }
}

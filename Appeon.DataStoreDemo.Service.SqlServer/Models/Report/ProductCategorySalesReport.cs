using SnapObjects.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using DWNet.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_productcategorysalesreport", DwStyle.Grid)]
    [Table("ProductCategory", Schema = "Production")]
    [DwParameter("orderMonth1", typeof(string))]
    [DwParameter("orderMonth2", typeof(string))]
    [DwParameter("orderMonth3", typeof(string))]
    [DwParameter("orderMonth4", typeof(string))]
    [DwParameter("orderMonth5", typeof(string))]
    [DwParameter("orderMonth6", typeof(string))]
    [DwParameter("orderMonth7", typeof(string))]
    [DwParameter("orderMonth8", typeof(string))]
    [DwParameter("orderMonth9", typeof(string))]
    [DwParameter("orderMonth10", typeof(string))]
    [DwParameter("orderMonth11", typeof(string))]
    [DwParameter("orderMonth12", typeof(string))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class ProductCategorySalesReport
    {
        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth1")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth1 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth2")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth2 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth3")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth3 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth4")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth4 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth5")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth5 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth6")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth6 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth7")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth7 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth8")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth8 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth9")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth9 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth10")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth10 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth11")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth11 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwReport(typeof(ProductCategorySalesReport_D), ParamValues = "orderMonth12")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth12 { get; set; }

    }
}

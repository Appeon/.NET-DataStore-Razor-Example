using Appeon.DataStoreDemo.Service.Models;
using Appeon.DataStoreDemo.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.MvcModelMapperDemo.Pages
{
    public class IndexModel : PageModel
    {
        public int orderTotalNum;
        public int orderNewNum;
        public int orderPendingNum;
        public int ordershipedNum;
        public int orderCancelNum;

        private readonly IOrderReportService _reportService;

        public IndexModel(IOrderReportService reportService)
        {
            _reportService = reportService;
        }

        public CategorySalesReportByYear categoryReportByYear { get; set; }

        public ProductCategorySalesReport productCategorySalesReport { get; set; }

        public IList<ProductSalesReport> productSalesReport { get; set; }

        public Dictionary<string, int> totalData { get; set; }

        public string loginName { get; set; }

        public async Task OnGetAsync()
        {
            await queryPieReportAsync();
            await queryTotalReportAsync();
            await queryBarReportByYearAsnyc();
        }

        private async Task queryTotalReportAsync()
        {
            totalData = await _reportService.SearchReportForSalesOrderTotalAsync();
            //转换json
            var Json_totalData = Newtonsoft.Json.JsonConvert.SerializeObject(totalData);
            categoryReportByYear.Json_totalData = Json_totalData;
        }

        private async Task queryPieReportAsync(CancellationToken cancellationToken = default)
        {
            var curDate = "2013-01-01";
            var curYear = DateTime.Parse(curDate).Year.ToString();
            var lastYear = DateTime.Parse(curDate).AddYears(-1).Year.ToString();
            var masterModel = new CategorySalesReportByYear();
            var subModel = new CategorySalesReportByYear_D();

            categoryReportByYear = await _reportService
                .SearchReportForSales(masterModel, subModel, curYear, lastYear, cancellationToken);

            var salesReportByCategory = categoryReportByYear
                .SalesReportByCategory
                .OrderBy(a => a.ProductCategoryName);

            //转换json
            var categorys = JsonConvert.SerializeObject(salesReportByCategory.Select(x => x.ProductCategoryName));

            var categorysData = JsonConvert.SerializeObject(salesReportByCategory.Select(x => new
                                                            {
                                                                name = x.ProductCategoryName,
                                                                value = x.TotalSalesqty
                                                            }));

            categoryReportByYear.Json_Categorys = categorys;
            categoryReportByYear.Json_categorysData = categorysData;
        }

        private async Task queryBarReportByYearAsnyc(CancellationToken cancellationToken = default)
        {
            string salesYear = "2013";
            object[] yearMonth = new object[12];
            object[] resultMonth = new object[12];

            //yearMonth[0] = subCategoryId;
            for (int month = 0; month < 12; month++)
            {
                yearMonth[month] = salesYear + string.Format("{0:00}", month + 1);
                resultMonth[month] = string.Format("{0:00}", month + 1) + "/" + salesYear;
            }

            var masterModel = new ProductCategorySalesReport();
            var subModel = new ProductCategorySalesReport_D();

            productCategorySalesReport = await _reportService
                .SearchReportForProductAsync(
                masterModel,
                subModel,
                yearMonth,
                cancellationToken);

            ConvertDataForReport(productCategorySalesReport, resultMonth);
        }

        /// <summary>
        /// Convert the database data to report data
        /// </summary>
        /// <param name="productCategorySalesReport"></param>
        /// <param name="yearMonth"></param>
        private void ConvertDataForReport(ProductCategorySalesReport productCategorySalesReport, object[] yearMonth)
        {
            var ProCategoryName = productCategorySalesReport
                .OrderReportMonth1
                .Select(x => x.ProductCategoryName)
                .ToList();

            ProCategoryName.Sort();

            List<int> salesQtys = null;
            Dictionary<string, List<int>> result = new Dictionary<string, List<int>>();
            foreach (var name in ProCategoryName)
            {
                salesQtys = new List<int>();
                salesQtys.Add(productCategorySalesReport.OrderReportMonth1.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth2.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth3.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth4.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth5.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth6.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth7.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth8.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth9.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth10.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth11.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                salesQtys.Add(productCategorySalesReport.OrderReportMonth12.Where(x => x.ProductCategoryName.Equals(name)).FirstOrDefault().TotalSalesqty);
                result.Add(name, salesQtys);
            }

            var proCat = JsonConvert.SerializeObject(ProCategoryName);
            var proCatQty = JsonConvert.SerializeObject(result
                                                            .Select(x => new
                                                            {
                                                                name = x.Key,
                                                                type = "bar",
                                                                data = x.Value
                                                            }));
            categoryReportByYear.Json_ProductSaleMonth = JsonConvert.SerializeObject(yearMonth);
            categoryReportByYear.Json_ProductCategory = proCat;
            categoryReportByYear.Json_ProductSaleSqty = proCatQty;
        }
    }
}

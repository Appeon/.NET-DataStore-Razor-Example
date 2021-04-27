using Appeon.DataStoreDemo.Service.Datacontext;
using Appeon.DataStoreDemo.Service.Models;
using SnapObjects.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.DataStoreDemo.Services
{
    public class OrderReportService : IOrderReportService
    {
        private readonly IGenericServiceFactory _genericService;
        private readonly OrderContext _context;

        public OrderReportService(IGenericServiceFactory genericService, OrderContext context)
        {
            _genericService = genericService;
            _context = context;
        }

        public async Task<CategorySalesReportByYear> SearchReportForSales(
            CategorySalesReportByYear masterModel,
            CategorySalesReportByYear_D subModel,
            string currentYear,
            string lastYear,
            CancellationToken cancellationToken = default)
        {
            masterModel.SalesReportByCategory = await _genericService
                .Get<CategorySalesReportByYear_D>()
                .SearchReportAsync(subModel, new object[] { currentYear }, cancellationToken);

            masterModel.LastYearSalesReportByCategory = await _genericService
                .Get<CategorySalesReportByYear_D>()
                .SearchReportAsync(subModel, new object[] { lastYear }, cancellationToken);

            return masterModel;
        }

        public async Task<ProductCategorySalesReport> SearchReportForProductAsync(
            ProductCategorySalesReport masterModel,
            ProductCategorySalesReport_D subModel,
            object[] salesmonth,
            CancellationToken cancellationToken = default)
        {
            List<ProductCategorySalesReport_D> productCategorySalesReports
                 = new List<ProductCategorySalesReport_D>();

            for (int i = 0; i < salesmonth.Length; i++)
            {
                var type = masterModel.GetType();

                var modelProperties = type.GetProperties();

                var productCategorySalesReport = await _genericService
                            .Get<ProductCategorySalesReport_D>()
                            .SearchReportAsync(subModel, new object[] { salesmonth[i] }, cancellationToken);

                modelProperties[i].SetValue(masterModel, productCategorySalesReport);
            }

            return masterModel;
        }

        public async Task<Dictionary<string, int>> SearchReportForSalesOrderTotalAsync(
            CancellationToken cancellationToken = default)
        {
            String sql = "select count(1) as totalNum, "
                        + " sum(case when status = 1 then 1 else 0 end) as process,"
                        + " sum(case when status = 2 then 1 else 0 end) as approved,"
                        + " sum(case when status = 3 then 1 else 0 end) as backordered,"
                        + " sum(case when status = 4 then 1 else 0 end) as rejected,"
                        + " sum(case when status = 5 then 1 else 0 end) as shipped,"
                        + " sum(case when status = 6 then 1 else 0 end) as cancelled"
                        + " from sales.SalesOrderHeader";

            //execute sql
            var dynamicModel = await this._context
                .SqlExecutor
                .SelectOneAsync<DynamicModel>(sql, new object[] { }, cancellationToken);

            Dictionary<string, int> result = new Dictionary<string, int>();

            if (dynamicModel != null)
            {
                for (int i = 0; i < dynamicModel.PropertyCount; i++)
                {
                    string key = dynamicModel.Properties[i].Name;

                    result.Add(key, dynamicModel.GetValue<int>(key));
                }
            }

            return result;
        }
    }
}

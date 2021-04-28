using Appeon.DataStoreDemo.Service.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.DataStoreDemo.Services
{
    public interface IOrderReportService
    {
        Task<CategorySalesReportByYear> SearchReportForSales(
            CategorySalesReportByYear masterModel,
            CategorySalesReportByYear_D subModel,
            string currentYear, string lastYear,
            CancellationToken cancellationToken = default);

        Task<ProductCategorySalesReport> SearchReportForProductAsync(
            ProductCategorySalesReport masterModel,
            ProductCategorySalesReport_D subModel,
            object[] salesmonth,
            CancellationToken cancellationToken = default);

        Task<Dictionary<string, int>> SearchReportForSalesOrderTotalAsync(
            CancellationToken cancellationToken = default);
    }
}

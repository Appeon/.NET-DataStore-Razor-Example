using Appeon.DataStoreDemo.Service.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.DataStoreDemo.Services
{
    public interface ISalesOrderService
    {
        Task<IList<SalesOrder>> SearchAsync(
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<SalesOrder> LoadByKeyAsync(
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<Page<SalesOrder>> LoadByPageAsync(
            int pageIndex,
            int pageSize,
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<int> CreateAsync(
            SalesOrder salesOrder,
            CancellationToken cancellationToken = default);

        Task<int> UpdateAsync(
            SalesOrder salesOrder,
            CancellationToken cancellationToken = default);

        Task<int> DeleteByKeyAsync(
            int salesOrderID,
            CancellationToken cancellationToken = default);
    }
}

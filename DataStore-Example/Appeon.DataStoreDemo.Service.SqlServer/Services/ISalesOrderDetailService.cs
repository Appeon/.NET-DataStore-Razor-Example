using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Appeon.DataStoreDemo.Service.Models;

namespace Appeon.DataStoreDemo.Services
{
    public interface ISalesOrderDetailService
    {
        Task<IList<SalesOrderDetail>> SearchAsync(
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<SalesOrderDetail> LoadByKeyAsync(
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<int> CreateAsync(
            SalesOrderDetail salesOrderDetail,
            CancellationToken cancellationToken = default);

        Task<int> UpdateAsync(
            SalesOrderDetail salesOrderDetail,
            CancellationToken cancellationToken = default);
    }
}

using SnapObjects.Data;
using DWNet.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Appeon.DataStoreDemo.Services
{
    public interface IGenericService<TModel>
    {
        Task<IList<TModel>> SearchAsync(
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<List<TModel>> SearchReportAsync(
            TModel subModel,
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<int> DeleteByKeyAsync(
            object[] parameters,
            CancellationToken cancellationToken = default);
    }
}

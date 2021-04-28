using Appeon.DataStoreDemo.Service.Datacontext;
using SnapObjects.Data;
using DWNet.Data;
using System.Threading.Tasks;
using System.Threading;
using Appeon.DataStoreDemo.Service.Models;
using System.Collections.Generic;

namespace Appeon.DataStoreDemo.Services
{
    public class GenericService<TModel> : ServiceBase<TModel>, IGenericService<TModel>
         where TModel : class
    {
        public GenericService(OrderContext context)
            : base(context)
        {
        }

        public async Task<List<TModel>> SearchReportAsync(
            TModel subModel,
            object[] parameters,
            CancellationToken cancellationToken = default)
        {
            DataStore<TModel> dataStore = new DataStore<TModel>(_context);

            dataStore.Retrieve(parameters);
            await dataStore.RetrieveAsync(parameters, cancellationToken);

            var models = GetModels(dataStore);

            return models;
        }

        public async Task<int> DeleteByKeyAsync(
            object[] parameters,
            CancellationToken cancellationToken = default)
        {
            var datastore = new DataStore<TModel>(_context);

            await datastore.RetrieveByKeyAsync(parameters, cancellationToken);

            datastore.RemoveAt(0);

            var updateResult = await datastore.UpdateAsync(cancellationToken);

            return updateResult;
        }
    }
}

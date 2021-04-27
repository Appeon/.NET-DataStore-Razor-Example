using Appeon.DataStoreDemo.Service.Models;
using DWNet.Data;
using SnapObjects.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.DataStoreDemo.Services
{
    public abstract class ServiceBase<TModel>
        where TModel : class
    {
        protected readonly DataContext _context;

        protected ServiceBase(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<TModel>> SearchAsync(
            object[] parameters,
            CancellationToken cancellationToken = default)
        {
            var datastore = new DataStore<TModel>(_context);

            await datastore.RetrieveAsync(parameters);

            var models = GetModels(datastore);

            return models;
        }

        internal List<TModel> GetModels(DataStore<TModel> datastore)
        {
            List<TModel> models = new List<TModel>();

            for (int i = 0; i < datastore.Count; i++)
            {
                var model = datastore.GetModel(i, true);

                models.Add(model);
            }

            return models;
        }

        public async Task<TModel> LoadByKeyAsync(
            object[] parameters,
            CancellationToken cancellationToken = default)
        {
            var datastore = new DataStore<TModel>(_context);

            await datastore.RetrieveByKeyAsync(parameters, cancellationToken);

            var model = datastore.GetModel(0);

            return model;
        }

        public async Task<Page<TModel>> LoadByPageAsync(
            int pageIndex,
            int pageSize,
            object[] parameters,
            CancellationToken cancellationToken = default)
        {
            var currentIndex = (pageIndex - 1) * pageSize;
            Page<TModel> page = new Page<TModel>
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };

            DataStore<TModel> dataStore = new DataStore<TModel>(_context);

            await dataStore.RetrieveByPageAsync(
                currentIndex,
                pageSize,
                parameters,
                cancellationToken);

            IList<TModel> models = GetModels(dataStore);

            dataStore.Retrieve();
            var totalItems = dataStore.TotalCount;

            page.TotalItems = totalItems;
            page.Items = models;

            return page;
        }
    }
}

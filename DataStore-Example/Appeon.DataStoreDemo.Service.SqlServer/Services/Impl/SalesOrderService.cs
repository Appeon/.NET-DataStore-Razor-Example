using DWNet.Data;
using Appeon.DataStoreDemo.Service.Datacontext;
using Appeon.DataStoreDemo.Service.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Appeon.DataStoreDemo.Services
{
    public class SalesOrderService : ServiceBase<SalesOrder>, ISalesOrderService
    {
        public SalesOrderService(OrderContext context)
            : base(context)
        {
        }

        public async Task<int> CreateAsync(
            SalesOrder salesOrder,
            CancellationToken cancellationToken = default)
        {
            var salesOrderDatastore = new DataStore<SalesOrder>(_context);

            salesOrderDatastore.Add(salesOrder);

            await salesOrderDatastore.UpdateAsync();

            return salesOrderDatastore.Count;
        }

        public async Task<int> DeleteByKeyAsync(
            int salesOrderID,
            CancellationToken cancellationToken = default)
        {
            var salesOrder = new DataStore<SalesOrder>(_context);
            var salesOrderDetail = new DataStore<SalesOrderDetail>(_context);

            await salesOrder.RetrieveByKeyAsync(new object[] { salesOrderID }, cancellationToken);
            await salesOrderDetail.RetrieveByKeyAsync(new object[] { salesOrderID }, cancellationToken);

            salesOrderDetail.RemoveAll(x => x.ProductID > 0);
            salesOrder.RemoveAt(0);

            await _context.BeginTransactionAsync();

            int updateCount = 0;

            try
            {
                await salesOrderDetail.UpdateAsync(cancellationToken);
                updateCount = await salesOrder.UpdateAsync(cancellationToken);

                salesOrder.Update();
            }
            catch (System.Exception)
            {
                await _context.RollbackAsync();
            }

            return updateCount;
        }

        public async Task<int> UpdateAsync(
            SalesOrder salesOrder,
            CancellationToken cancellationToken = default)
        {
            var datastore = new DataStore<SalesOrder>(_context);

            await datastore.RetrieveByKeyAsync(new object[] { salesOrder.SalesOrderID }, cancellationToken);

            datastore.SetModel(0, salesOrder);

            await datastore.UpdateAsync(cancellationToken);

            return datastore.ModifiedCount;
        }

    }
}

using Appeon.DataStoreDemo.Service.Datacontext;
using Appeon.DataStoreDemo.Service.Models;
using DWNet.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.DataStoreDemo.Services
{
    public class SalesOrderDetailService : ServiceBase<SalesOrderDetail>,
        ISalesOrderDetailService
    {
        public SalesOrderDetailService(OrderContext context)
            : base(context)
        {
        }

        public async Task<int> CreateAsync(
            SalesOrderDetail salesOrderDetail,
            CancellationToken cancellationToken = default)
        {
            var salesOrderDetailDatastore = new DataStore<SalesOrderDetail>(_context);

            salesOrderDetail.ModifiedDate = DateTime.Now.Date;

            salesOrderDetailDatastore.Add(salesOrderDetail);

            await salesOrderDetailDatastore.UpdateAsync();

            return salesOrderDetailDatastore.Count;
        }

        public async Task<int> UpdateAsync(
            SalesOrderDetail salesOrderdetail,
            CancellationToken cancellationToken = default)
        {
            var salesOrderDetailDatastore = new DataStore<SalesOrderDetail>(_context);

            await salesOrderDetailDatastore.RetrieveByKeyAsync(
                new object[] { salesOrderdetail.SalesOrderID },
                cancellationToken);

            salesOrderDetailDatastore.SetModel(0, salesOrderdetail);

            await salesOrderDetailDatastore.UpdateAsync(cancellationToken);

            return salesOrderDetailDatastore.ModifiedCount;
        }
    }
}

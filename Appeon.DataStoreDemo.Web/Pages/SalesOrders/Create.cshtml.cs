using Appeon.MvcModelMapperDemo.Models;
using Appeon.DataStoreDemo.Service.Models;
using Appeon.DataStoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.MvcModelMapperDemo.Pages.SalesOrders
{
    public class CreateModel : BasePageModel
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly IGenericServiceFactory _genericServices;

        public CreateModel(
            ISalesOrderService salesOrderService,
            IGenericServiceFactory genericServiceFactory)
        {
            _salesOrderService = salesOrderService;
            _genericServices = genericServiceFactory;
        }

        [BindProperty]
        public SalesOrder SalesOrder { get; set; }

        [BindProperty]
        public SalesOrderDetail SalesOrderDetail { get; set; }

        public SelectList Customers { get; set; }

        public SelectList SalesPersons { get; set; }

        public SelectList ShipMethods { get; set; }

        public IDictionary<int, string> OrderProductMaps { get; set; }

        public SelectList OrderProducts { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                await this.LoadDataAsync();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
            return Page();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                await QueryCustomersAsync();

                await QuerySalesPersonsAsync();

                await QueryShipMethodsAsync();

                await QueryOrderProductsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<JsonResult> OnGetRetrieveDddwAsync(
            int customerId,
            CancellationToken cancellationToken = default)
        {
            var result = new Dictionary<string, object>()
            {
                { "code", 1},

                { "creditcards", await _genericServices
                    .Get<DdCreditcard>()
                    .SearchAsync( new object[] { customerId }, cancellationToken)
                },

                { "customerAddresses", await _genericServices
                    .Get<DdCustomerAddress>()
                    .SearchAsync(new object[] { customerId }, cancellationToken)
                }
            };

            return new JsonResult(result);
        }

        private async Task QueryOrderProductsAsync(CancellationToken cancellationToken = default)
        {
            // 0: retrieve all products
            var ddOrderProducts = await _genericServices
                .Get<DdOrderProduct>()
                .SearchAsync(new object[] { 0 }, cancellationToken);
            //  query products
            this.OrderProducts = new SelectList(ddOrderProducts, "Product_Productid", "Product_Name");
            //  convert to Dictionary
            this.OrderProductMaps = ddOrderProducts.ToDictionary(x => x.Product_Productid, x => x.Product_Name);
        }

        private async Task QueryCustomersAsync(CancellationToken cancellationToken = default)
        {
            var ddCustomers = await _genericServices
                .Get<DdCustomer>()
                .SearchAsync(new object[] { }, cancellationToken);

            this.Customers = new SelectList(ddCustomers, "Customer_Customerid", "Fullname");
        }

        private async Task QuerySalesPersonsAsync(CancellationToken cancellationToken = default)
        {
            var ddSalesPersons = await _genericServices
                .Get<DdSalesPerson>()
                .SearchAsync(new object[] { }, cancellationToken);

            this.SalesPersons = new SelectList(ddSalesPersons, "Salesperson_Businessentityid", "Fullname");
        }

        private async Task QueryShipMethodsAsync(CancellationToken cancellationToken = default)
        {
            var ddShipMethods = await _genericServices
                .Get<DdShipMethod>()
                .SearchAsync(new object[] { }, cancellationToken);

            this.ShipMethods = new SelectList(ddShipMethods, "Shipmethodid", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                ConvertData(SalesOrder);

                var insertedCount = await _salesOrderService.CreateAsync(SalesOrder);
            }
            catch (Exception e)
            {
                return GenJsonResult(-1, e.Message, 0);
            }

            return GenJsonResult(1, "", SalesOrder.SalesOrderID);
        }
    }
}
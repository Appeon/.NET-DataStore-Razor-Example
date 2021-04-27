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
    public class EditModel : BasePageModel
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly IGenericServiceFactory _genericServices;
        private readonly ISalesOrderDetailService _salesOrderDetailService;

        public EditModel(ISalesOrderService salesOrderService,
                         IGenericServiceFactory genericServiceFactory,
                         ISalesOrderDetailService salesOrderDetailService)
        {
            _salesOrderService = salesOrderService;
            _genericServices = genericServiceFactory;
            _salesOrderDetailService = salesOrderDetailService;
        }

        [BindProperty]
        public SalesOrder SalesOrder { get; set; }

        [BindProperty]
        public IList<SalesOrderDetail> SalesOrderDetail { get; set; }

        public SelectList Customers { get; set; }

        public IDictionary<int, string> CustomerMaps { get; set; }

        public SelectList SalesPersons { get; set; }

        public SelectList ShipMethods { get; set; }

        public SelectList Creditcards { get; set; }

        public SelectList CustomerAddresses { get; set; }

        public SelectList OrderProducts { get; set; }

        public IDictionary<int, string> OrderProductMaps { get; set; }

        public async Task<IActionResult> OnGetAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await RetrieveDddwAsync();

                SalesOrder = await _salesOrderService.LoadByKeyAsync(new object[] { id }, cancellationToken);

                if (SalesOrder != null)
                {
                    SalesOrderDetail = await _salesOrderDetailService.SearchAsync(
                        new object[] { SalesOrder.SalesOrderID },
                        cancellationToken);

                    await RetrieveDddwAsync(SalesOrder.CustomerID);
                }

                return Page();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public async Task<JsonResult> OnGetRetrieveProductAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var result = new Dictionary<string, object>()
            {
                { "code", 1},

                { "product", await _genericServices
                .Get<DdOrderProduct>()
                .SearchAsync( new object[] { id }, cancellationToken) }
            };

            return new JsonResult(result);
        }

        private async Task RetrieveDddwAsync()
        {
            await RetrieveCustomersAsync();

            await RetrieveSalesPersonsAsync();

            await RetrieveShipMethodsAsync();

            await RetrieveOrderProductsAsync();
        }

        public async Task RetrieveDddwAsync(int customerId)
        {
            await RetrieveCreditcardsAsync(customerId);

            await RetrieveCustomerAddressesAsync(customerId);
        }

        private async Task RetrieveCustomersAsync()
        {
            var ddCustomers = await _genericServices
                .Get<DdCustomer>()
                .SearchAsync(new object[] { });

            Customers = new SelectList(ddCustomers, "Customer_Customerid", "Fullname");

            CustomerMaps = ddCustomers
                .ToDictionary(x => x.Customer_Customerid, x => x.Fullname);
        }

        private async Task RetrieveSalesPersonsAsync()
        {
            var ddSalesPersons = await _genericServices
                .Get<DdSalesPerson>()
                .SearchAsync(new object[] { });

            SalesPersons = new SelectList(ddSalesPersons, "Salesperson_Businessentityid", "Fullname");
        }

        private async Task RetrieveShipMethodsAsync()
        {
            var ddShipMethods = await _genericServices
                .Get<DdShipMethod>()
                .SearchAsync(new object[] { });

            ShipMethods = new SelectList(ddShipMethods, "Shipmethodid", "Name");
        }

        private async Task RetrieveCreditcardsAsync(
            int customerId,
            CancellationToken cancellationToken = default)
        {
            var ddCreditcards = await _genericServices
                .Get<DdCreditcard>()
                .SearchAsync(new object[] { customerId }, cancellationToken);

            Creditcards = new SelectList(ddCreditcards, "Creditcard_Creditcardid", "Creditcard_Cardnumber");
        }

        private async Task RetrieveCustomerAddressesAsync(
            int customerId,
            CancellationToken cancellationToken = default)
        {
            var ddCustomerAddresses = await _genericServices
                .Get<DdCustomerAddress>()
                .SearchAsync(new object[] { customerId }, cancellationToken);

            CustomerAddresses = new SelectList(
                ddCustomerAddresses, "Businessentityaddress_Addressid", "Address_Addressline1");
        }

        private async Task RetrieveOrderProductsAsync(CancellationToken cancellationToken = default)
        {
            // 0: retrieve all products
            var ddOrderProducts = await _genericServices
                .Get<DdOrderProduct>()
                .SearchAsync(new object[] { 0 }, cancellationToken);

            OrderProducts = new SelectList(
                ddOrderProducts, "Product_Productid", "Product_Name");

            OrderProductMaps = ddOrderProducts.ToDictionary(x => x.Product_Productid, x => x.Product_Name);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                ConvertData(SalesOrder);

                SalesOrder.ModifiedDate = DateTime.Now;

                var modifiedCount = await _salesOrderService.UpdateAsync(SalesOrder);
            }
            catch (Exception e)
            {
                return GenJsonResult(-1, e.Message, SalesOrder.SalesOrderID);
            }

            return GenJsonResult(1, "", SalesOrder.SalesOrderID);
        }

        public async Task<IActionResult> OnPostCreateDetailAsync()
        {
            try
            {
                var InsertedCount = await _salesOrderDetailService
                    .CreateAsync(SalesOrderDetail[0]);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return RedirectToPage("./Edit", new { id = SalesOrderDetail[0].SalesOrderID });

        }

        public async Task<IActionResult> OnPostUpdateDetailAsync()
        {
            try
            {
                var modifiedCount = await _salesOrderDetailService
                    .UpdateAsync(SalesOrderDetail[0]);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return RedirectToPage("./Edit", new { id = SalesOrderDetail[0].SalesOrderID });

        }

        public async Task<IActionResult> OnGetDeleteDetailAsync(
            int salesOrderID,
            int salesOrderDetailID,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _genericServices
                    .Get<SalesOrderDetail>()
                    .DeleteByKeyAsync(new object[] { salesOrderDetailID }, cancellationToken);
            }
            catch (Exception e)
            {
                return GenJsonResult(-1, e.Message, salesOrderDetailID);
            }

            return GenJsonResult(1, "", salesOrderDetailID);
        }
    }
}
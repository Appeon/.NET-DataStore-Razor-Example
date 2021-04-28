using Appeon.MvcModelMapperDemo.Models;
using Appeon.DataStoreDemo.Service.Models;
using Appeon.DataStoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.MvcModelMapperDemo.Pages.SalesOrders
{
    public class IndexModel : BasePageModel
    {
        private readonly ISalesOrderService _salesOrderService;

        public IndexModel(ISalesOrderService salesOrderService)
        {
            _salesOrderService = salesOrderService;
        }

        public IList<SalesOrder> SalesOrders { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime? StartOrderDate { get; set; } = new DateTime(2011, 1, 1).Date;

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime? EndOrderDate { get; set; } = new DateTime(2012, 1, 31).Date;

        [BindProperty(SupportsGet = true)]
        public int? CustomerID { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetDelete(String ids)
        {
            try
            {
                String[] idArr = ids.Split(",");
                foreach (var id in idArr)
                {
                    var result = await _salesOrderService.DeleteByKeyAsync(int.Parse(id));
                }
            }
            catch (Exception e)
            {
                return GenJsonResult(-1, e.Message, 0);
            }

            return GenJsonResult(1, "", null);
        }

        public async Task<IActionResult> OnGetDeleteById(String id)
        {
            try
            {
                var result = await _salesOrderService.DeleteByKeyAsync(int.Parse(id));
            }
            catch (Exception e)
            {
                return GenJsonResult(-1, e.Message, 0);
            }

            return GenJsonResult(1, "", null);
        }

        public async Task<ActionResult> OnPostSearchAsync(
            DataTable dateTable,
            CancellationToken cancellationToken = default)
        {
            try
            {
                int pageSize = dateTable.pageSize ?? 10;
                int pageIndex = dateTable.pageIndex;

                //query data by page
                Page<SalesOrder> page = await _salesOrderService
                    .LoadByPageAsync(
                    pageIndex,
                    pageSize,
                    new object[] { CustomerID ?? 0, StartOrderDate, EndOrderDate },
                    cancellationToken);

                SalesOrders = page.Items;
                dateTable.recordsTotal = page.TotalItems;
                dateTable.recordsFiltered = page.TotalItems;
                dateTable.data = this.SalesOrders.ToList();

                return new JsonResult(JsonConvert.SerializeObject(dateTable));
            }
            catch (Exception e)
            {
                return GenJsonResult(-1, e.Message, 0);
            }
        }
    }
}
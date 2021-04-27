using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using Appeon.DataStoreDemo.Services;
using System.Threading.Tasks;
using Appeon.DataStoreDemo.Service.Models;
using System.Threading;

namespace Appeon.DataStoreDemo.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderReportController : ControllerBase
    {
        private readonly IOrderReportService _iorderreportservice;

        public OrderReportController(IOrderReportService iorderreportservice)
        {
            _iorderreportservice = iorderreportservice;
        }

        //POST api/OrderReport/GetSalesReport
        [HttpGet("{currentDate}")]
        [ProducesResponseType(typeof(CategorySalesReportByYear), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategorySalesReportByYear>> GetSalesReportAsync(string currentDate)
        {
            try
            {
                //for example:currentDate = "2013-01-01";
                var curYear = DateTime.Parse(currentDate).Year.ToString();
                var lastYear = DateTime.Parse(currentDate).AddYears(-1).Year.ToString();
                var masterModel = new CategorySalesReportByYear();
                var subModel = new CategorySalesReportByYear_D();

                var result = await _iorderreportservice
                    .SearchReportForSales(masterModel, subModel, curYear, lastYear, default);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //POST api/OrderReport/GetProductSalesReport
        [HttpGet("{salesYear}")]
        [ProducesResponseType(typeof(ProductCategorySalesReport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductCategorySalesReport>> GetProductSalesReportAsync(string salesYear)
        {
            try
            {
                //for example:salesYear = "2013";
                object[] yearMonth = new object[12];
                object[] resultMonth = new object[12];

                //yearMonth[0] = subCategoryId;
                for (int month = 0; month < 12; month++)
                {
                    yearMonth[month] = salesYear + string.Format("{0:00}", month + 1);
                    resultMonth[month] = string.Format("{0:00}", month + 1) + "/" + salesYear;
                }

                var masterModel = new ProductCategorySalesReport();
                var subModel = new ProductCategorySalesReport_D();
                var result = await _iorderreportservice.SearchReportForProductAsync(masterModel, subModel, yearMonth);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //GET api/OrderReport/GetSalesOrderTotalReport
        [HttpGet]
        [ProducesResponseType(typeof(Dictionary<string, int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Dictionary<string, int>>> GetSalesOrderTotalReportAsync()
        {
            try
            {
                var result = await _iorderreportservice.SearchReportForSalesOrderTotalAsync(default);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}

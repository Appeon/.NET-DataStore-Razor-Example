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
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderService _isalesorderservice;

        public SalesOrderController(ISalesOrderService isalesorderservice)
        {
            _isalesorderservice = isalesorderservice;
        }

        //GET api/SalesOrder/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SalesOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SalesOrder>> GetAsync(int id)
        {
            try
            {
                object[] objects = new object[] { id };
                var result = await _isalesorderservice.LoadByKeyAsync(objects);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //POST api/SalesOrder/{pageIndex}/{pageSize}
        [HttpGet("{pageIndex}")]
        [ProducesResponseType(typeof(Page<SalesOrder>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Page<SalesOrder>>> GetByPageAsync(
            int pageIndex, 
            int? pageSize, 
            int? customerId, 
            DateTime? startOrderDate, 
            DateTime? endOrderDate)
        {
            try
            {
                int pagesize = pageSize ?? 10;
                customerId = customerId ?? 0;
                startOrderDate = startOrderDate ?? new DateTime(2011, 1, 1).Date;
                endOrderDate = endOrderDate ?? new DateTime(2011, 1, 1).Date;
                object[] objects = new object[] { customerId, startOrderDate, endOrderDate };
                var result = await _isalesorderservice.LoadByPageAsync(pageIndex, pagesize, objects, default);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //POST api/SalesOrder
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] SalesOrder salesOrder)
        {
            try
            {
                var result = await _isalesorderservice.CreateAsync(salesOrder, default);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //POST api/SalesOrder
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateAsync([FromBody] SalesOrder salesOrder)
        {
            try
            {
                var result = await _isalesorderservice.UpdateAsync(salesOrder, default);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //DELETE api/SalesOrder/{salesOrderID}
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> DeleteAsync(int salesOrderID)
        {
            try
            {
                var result = await _isalesorderservice.DeleteByKeyAsync(salesOrderID, default);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

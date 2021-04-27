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
    public class SalesOrderDetailController : ControllerBase
    {
        private readonly ISalesOrderDetailService _isalesorderdetailservice;

        public SalesOrderDetailController(ISalesOrderDetailService isalesorderdetailservice)
        {
            _isalesorderdetailservice = isalesorderdetailservice;
        }

        //POST api/SalesOrderDetail
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SalesOrderDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SalesOrderDetail>> GetAsync(int id)
        {
            try
            {
                object[] objects = new object[] { id };
                var result = await _isalesorderdetailservice.LoadByKeyAsync(objects, default);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //POST api/SalesOrderDetail
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] SalesOrderDetail salesOrderDetail)
        {
            try
            {
                var result = await _isalesorderdetailservice.CreateAsync(salesOrderDetail, default);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //POST api/SalesOrderDetail
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateAsync([FromBody] SalesOrderDetail salesOrderDetail)
        {
            try
            {
                var result = await _isalesorderdetailservice.UpdateAsync(salesOrderDetail, default);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

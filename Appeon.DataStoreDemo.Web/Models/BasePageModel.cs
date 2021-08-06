using Appeon.DataStoreDemo.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Appeon.MvcModelMapperDemo.Models
{
    public class BasePageModel : PageModel
    {
        /// <summary>
        /// Return to the unified json format
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        protected JsonResult GenJsonResult(int code, String message, int? id)
        {
            var result = new Dictionary<string, object>()
                {
                    { "code", code},
                    { "message",message},
                    { "id",id}
                };

            return new JsonResult(result);
        }

        /// <summary>
        /// convert date format
        /// </summary>
        /// <param name="SalesOrder"></param>
        protected void ConvertData(SalesOrder SalesOrder)
        {
            String orderDate = this.Request.Form["SalesOrder.OrderDate"];
            String dueDate = this.Request.Form["SalesOrder.DueDate"];
            String shipDate = this.Request.Form["SalesOrder.ShipDate"];

            if (!String.IsNullOrEmpty(orderDate) && SalesOrder.OrderDate == null)
            {
                try
                {
                    DateTime dt;
                    DateTime.TryParseExact(orderDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
                    SalesOrder.OrderDate = dt;
                }
                catch (Exception)
                {
                }
            }
            if (!String.IsNullOrEmpty(dueDate) && SalesOrder.DueDate == null)
            {
                try
                {
                    SalesOrder.DueDate = DateTime.ParseExact(dueDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                }
                catch (Exception)
                {

                }
            }
            if (!String.IsNullOrEmpty(shipDate) && SalesOrder.ShipDate == null)
            {
                try
                {
                    SalesOrder.ShipDate = DateTime.ParseExact(shipDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                }
                catch (Exception)
                {

                }
            }
        }

        protected void DataValidation(SalesOrder SalesOrder)
        {
            if (SalesOrder.DueDate < SalesOrder.OrderDate || SalesOrder.ShipDate < SalesOrder.OrderDate)

                throw new Exception("The \"Due Date\" and \"Ship Date\" must not be less than the \"Order Date\"!");
        }
    }
}

using DWNet.Data;
using SnapObjects.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_dddw_customer_creditcard", DwStyle.Grid)]
    [Table("Customer", Schema = "Sales")]
    #region DwSelectAttribute  
    [DwSelect("SELECT Sales.customer.customerid, "
                      + "Sales.creditcard.creditcardid, "
                      + "Sales.creditcard.cardtype, "
                      + "Sales.creditcard.cardnumber, "
                      + "Sales.creditcard.expmonth, "
                      + "Sales.creditcard.expyear "
                      + "FROM Sales.creditcard, "
                      + "Sales.personcreditcard, "
                      + "Sales.customer "
                      + "WHERE ( Sales.personcreditcard.creditcardid = Sales.creditcard.creditcardid ) and "
                      + "( Sales.personcreditcard.businessentityid = Sales.customer.personid ) and "
                      + "( Sales.Customer.CustomerID = :al_customer_id )")]
    #endregion
    [DwParameter("al_customer_id", typeof(decimal?))]
    [DwKeyModificationStrategy(UpdateSqlStrategy.Update)]
    public class DdCreditcard
    {
        [Identity]
        [PropertySave(SaveStrategy.Ignore)]
        public int Customer_Customerid { get; set; }

        [Identity]
        [PropertySave(SaveStrategy.Ignore)]
        public int Creditcard_Creditcardid { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        public string Creditcard_Cardtype { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        public string Creditcard_Cardnumber { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        public Byte Creditcard_Expmonth { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        public int Creditcard_Expyear { get; set; }
    }
}

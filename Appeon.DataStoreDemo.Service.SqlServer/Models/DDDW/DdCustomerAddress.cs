using DWNet.Data;
using SnapObjects.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_dddw_customer_address", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  + "FROM Person.BusinessEntityAddress, \r\n "
                  + "Person.Address, \r\n "
                  + "Person.AddressType, \r\n "
                  + "Sales.Customer, \r\n "
                  + "Person.StateProvince \r\n "
                  + "WHERE ( Person.Address.addressid = Person.BusinessEntityAddress.addressid ) and \r\n "
                  + "( Person.AddressType.addresstypeid = Person.BusinessEntityAddress.addresstypeid ) and \r\n "
                  + "( Sales.Customer.territoryid = Person.StateProvince.territoryid ) and \r\n "
                  + "(Person.BusinessEntityAddress.BusinessEntityID = Sales.Customer.PersonID OR \r\n "
                  + "Person.BusinessEntityAddress.BusinessEntityID = Sales.Customer.StoreID) AND \r\n "
                  + "Person.Address.StateProvinceID = Person.StateProvince.StateProvinceID AND \r\n "
                  + "Sales.Customer.CustomerID = :al_customer_id")]
    #endregion
    [DwParameter("al_customer_id", typeof(decimal?))]
    public class DdCustomerAddress
    {
        [DwColumn("BusinessEntityAddress", "businessentityid")]
        public int Businessentityaddress_Businessentityid { get; set; }

        [DwColumn("BusinessEntityAddress", "addressid")]
        public int Businessentityaddress_Addressid { get; set; }

        [DwColumn("BusinessEntityAddress", "addresstypeid")]
        public int Businessentityaddress_Addresstypeid { get; set; }

        [StringLength(60)]
        [DwColumn("Address", "addressline1")]
        public string Address_Addressline1 { get; set; }

        [StringLength(60)]
        [DwColumn("Address", "addressline2")]
        public string Address_Addressline2 { get; set; }

        [StringLength(30)]
        [DwColumn("Address", "city")]
        public string Address_City { get; set; }

        [DwColumn("Address", "stateprovinceid")]
        public int Address_Stateprovinceid { get; set; }

        [StringLength(15)]
        [DwColumn("Address", "postalcode")]
        public string Address_Postalcode { get; set; }

        [StringLength(50)]
        [DwColumn("AddressType", "name")]
        public string Addresstype_Name { get; set; }

        [DwColumn("Customer", "customerid")]
        public int Customer_Customerid { get; set; }

        [DwColumn("StateProvince", "stateprovincecode")]
        public string Stateprovince_Stateprovincecode { get; set; }

        [DwColumn("StateProvince", "countryregioncode")]
        public string Stateprovince_Countryregioncode { get; set; }

        [DwColumn("StateProvince", "name")]
        public string Stateprovince_Name { get; set; }
    }
}

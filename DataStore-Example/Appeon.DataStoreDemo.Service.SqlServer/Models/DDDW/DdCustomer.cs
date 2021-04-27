using SnapObjects.Data;
using DWNet.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_ddcustomer", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  + "FROM Sales.Customer, \r\n "
                  + "Sales.SalesTerritory, \r\n "
                  + "Person.Person \r\n "
                  + "WHERE ( Sales.SalesTerritory.TerritoryID = Sales.Customer.TerritoryID ) and \r\n "
                  + "( ( Sales.Customer.PersonID is not null ) AND \r\n "
                  + "( Sales.Customer.PersonID = Person.Person.BusinessEntityID ) ) \r\n "
                  + "ORDER BY Sales.Customer.CustomerID ASC")]
    #endregion
    public class DdCustomer
    {
        [Identity]
        [DwColumn("Sales.Customer", "CustomerID")]
        public int Customer_Customerid { get; set; }

        [DwColumn("Sales.Customer", "PersonID")]
        public int? Customer_Personid { get; set; }

        [DwColumn("Sales.Customer", "TerritoryID")]
        public int? Customer_Territoryid { get; set; }

        [StringLength(10)]
        [DwColumn("Sales.Customer", "AccountNumber")]
        public string Customer_Accountnumber { get; set; }

        [StringLength(50)]
        [DwColumn("Sales.SalesTerritory", "Name")]
        public string Salesterritory_Name { get; set; }

        [StringLength(8)]
        [DwColumn("Person.Person", "Title")]
        public string Person_Title { get; set; }

        [StringLength(50)]
        [DwColumn("Person.Person", "FirstName")]
        public string Person_Firstname { get; set; }

        [StringLength(50)]
        [DwColumn("Person.Person", "MiddleName")]
        public string Person_Middlename { get; set; }

        [StringLength(50)]
        [DwColumn("Person.Person", "LastName")]
        public string Person_Lastname { get; set; }

        [StringLength(10)]
        [DwColumn("Person.Person", "Suffix")]
        public string Person_Suffix { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [DwCompute(" person_lastname  +  person_firstname ")]
        public string Fullname { get; set; }
    }
}

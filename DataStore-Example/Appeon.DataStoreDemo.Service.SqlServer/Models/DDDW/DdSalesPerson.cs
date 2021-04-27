using SnapObjects.Data;
using DWNet.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_dddw_salesperson", DwStyle.Grid)]
    [Table("SalesPerson", Schema = "Sales")]
    #region DwSelectAttribute  
    [DwSelect("SELECT Sales.SalesPerson.businessentityid, "
                  + "Person.Person.title, "
                  + "Person.Person.firstname, "
                  + "Person.Person.middlename, "
                  + "Person.Person.lastname, "
                  + "Person.Person.suffix "
                  + "FROM Sales.SalesPerson  , "
                  + "Person.Person "
                  + "WHERE ( Sales.SalesPerson.BusinessEntityID = Person.Person.BusinessEntityID )")]
    #endregion
    [DwKeyModificationStrategy(UpdateSqlStrategy.Update)]
    public class DdSalesPerson
    {
        [SqlColumn(tableAlias: "sp", column: "BusinessEntityID")]
        [DisplayName("ID")]// Manually add
        public int Salesperson_Businessentityid { get; set; }

        [SqlColumn("Title")]
        public string Person_Title { get; set; }

        [SqlColumn("FirstName")]
        public string Person_Firstname { get; set; }

        [SqlColumn("MiddleName")]
        public string Person_Middlename { get; set; }

        [SqlColumn("LastName")]
        public string Person_Lastname { get; set; }

        [SqlColumn("Suffix")]
        public string Person_Suffix { get; set; }

        [SqlCompute(@"FirstName + ' ' + LastName")]
        [DisplayName("Sales Name")]// Manually add
        public string Fullname { get; set; }
    }
}

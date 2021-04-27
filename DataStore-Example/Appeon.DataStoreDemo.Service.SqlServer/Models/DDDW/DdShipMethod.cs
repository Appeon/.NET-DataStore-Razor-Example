using DWNet.Data;
using SnapObjects.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_dddw_shipmethod", DwStyle.Grid)]
    [Table("ShipMethod", Schema = "Purchasing")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Purchasing.ShipMethod\" ) COLUMN(NAME=\"Purchasing.ShipMethod.ShipMethodID\") COLUMN(NAME=\"Purchasing.ShipMethod.Name\") COLUMN(NAME=\"Purchasing.ShipMethod.ShipBase\") COLUMN(NAME=\"Purchasing.ShipMethod.ShipRate\")) ")]
    #endregion
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class DdShipMethod
    {
        [Key]
        [Identity]
        [DisplayName("Ship Method ID")]// Manually add
        public int Shipmethodid { get; set; }

        public string Name { get; set; }

        public decimal Shipbase { get; set; }

        public decimal Shiprate { get; set; }
    }
}

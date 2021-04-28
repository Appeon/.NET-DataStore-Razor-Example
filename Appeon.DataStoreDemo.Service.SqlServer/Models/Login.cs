using DWNet.Data;
using SnapObjects.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.DataStoreDemo.Service.Models
{
    [DataWindow("d_login", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Person.Password\" )  TABLE(NAME=\"Person.Person\" ) @(_COLUMNS_PLACEHOLDER_) JOIN (LEFT=\"Person.Person.BusinessEntityID\"    OP =\"=\"RIGHT=\"Person.Password.BusinessEntityID\"    OUTER1 =\"Person.Person.BusinessEntityID\" )WHERE(    EXP1 =\"Person.Person.FirstName\"   OP =\"=\"    EXP2 =\":firstname\"    LOGIC =\"And\" ) WHERE(    EXP1 =\"Person.Person.LastName\"   OP =\"=\"    EXP2 =\":lastname\"    LOGIC =\"And\" ) WHERE(    EXP1 =\"Person.Password.PasswordSalt\"   OP =\"=\"    EXP2 =\":password\" ) ) ARG(NAME = \"firstname\" TYPE = string)  ARG(NAME = \"lastname\" TYPE = string)  ARG(NAME = \"password\" TYPE = string)")]
    #endregion
    [DwParameter("firstname", typeof(string))]
    [DwParameter("lastname", typeof(string))]
    [DwParameter("password", typeof(string))]
    public class Login
    {
        [StringLength(50)]
        [DwColumn("Person.Person", "FirstName")]
        public string Firstname { get; set; }

        [StringLength(50)]
        [DwColumn("Person.Person", "MiddleName")]
        public string Middlename { get; set; }

        [StringLength(50)]
        [DwColumn("Person.Person", "LastName")]
        public string Lastname { get; set; }

        [StringLength(10)]
        [DwColumn("Person.Password", "PasswordSalt")]
        public string Password { get; set; }

    }
}

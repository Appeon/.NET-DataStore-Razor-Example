using Appeon.DataStoreDemo.Service.Datacontext;
using Appeon.DataStoreDemo.Service.Models;
using DWNet.Data;
using SnapObjects.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appeon.DataStoreDemo.Services
{
    public class LoginService : ILoginService
    {
        private OrderContext _context;

        public LoginService(OrderContext context)
        {
            _context = context;
        }

        public bool Login(string userName, string password)
        {
            var names = SplitFullName(userName);

            DataStore<Login> loginDataStore = new DataStore<Login>(_context);

            var count = loginDataStore.Retrieve(names[0], names[1], password);

            return count == 1;
        }

        public bool UserIsExist(string userName)
        {
            //prepare parameter
            var names = SplitFullName(userName);

            //init sql query build
            SqlQueryBuilder sqlQueryBuilder = new SqlQueryBuilder();

            sqlQueryBuilder.Select("*")
                .From("Person.Person")
                .Where("FirstName", SqlBuilder.Parameter<string>("firstName"))
                .AndWhere("LastName", SqlBuilder.Parameter<string>("lastName"));

            var sql = sqlQueryBuilder.ToSqlString(_context);

            //execute sql
            var dynamicModel = _context.SqlExecutor.Select<DynamicModel>(sql, names[0], names[1]);

            return dynamicModel.Count == 1;
        }

        private string[] SplitFullName(string userName)
        {
            string[] names = userName.Split('.');

            if (names.Length < 2)
                throw new Exception("Please Input Full Name!");

            return names;
        }
    }
}

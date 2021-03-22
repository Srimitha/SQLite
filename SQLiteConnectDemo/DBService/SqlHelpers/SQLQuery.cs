using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLiteConnectDemo.DBService.SqlHelpers
{
    public class SQLQuery
    {
        internal static string GetCustomerByID = "SELECT * FROM Customers WHERE CustomerId=@CustomerId";
    }
}
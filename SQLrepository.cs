using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardApp.DataLayer
{
    public class SQLrepository
    { 
        public const string getPriceConstant = "select security_id,latest,opening,last_time from price where latest>1  and opening>0";

        public const string getSecurityConstant = "select  security_id ,symbol from security";
        public const string getAccountConstant = "select account_id,short_name , name_1,modified_time  from account where account_id >1 and LEN(short_name) = 3";
        public const string getPositionConstant = "select position_id,account_id,security_id,quantity,cost,unit_cost from positions";
        public const string getOrderConstant = "select order_id,account_id,security_id,quantity,created_time from orders";


        public IDbConnection GetConnection()
        {
            var dbConnection = new SqlConnection("Database=mkt7530;Server=TN1DEVAMP08;Trusted_Connection=True;");

            return dbConnection;
        }

    }
   

}

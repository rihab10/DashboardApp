                                                             using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace DashboardApp.DataLayer
{
    public class AccountService
    {
        private SQLrepository SQLrepository;

        public AccountService()
        {
            SQLrepository = new SQLrepository();
        }

        // get All accounts
        public List<Account> getAccounts()
        {
            var query = SQLrepository.getAccountConstant;

            using (var connection = SQLrepository.GetConnection())
            {
                connection.Open();

                return connection.Query<Account>(query).ToList();
            }

           
        }

















    }
}

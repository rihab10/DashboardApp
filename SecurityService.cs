using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardApp.DataLayer
{
    public class SecurityService
    {
        private SQLrepository SQLrepository;

        public SecurityService()
        {
            SQLrepository = new SQLrepository();
        }

        public List<Security> getSecurity()
        {
            var query = SQLrepository.getSecurityConstant;

            using (var connection = SQLrepository.GetConnection()) 
            {
                connection.Open();

                return connection.Query<Security>(query).ToList();
            }
        }




    }
}

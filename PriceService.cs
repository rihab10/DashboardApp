using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardApp.DataLayer
{
    public class PriceService
    {
        private SQLrepository SQLrepository;

        public PriceService()
        {
            SQLrepository = new SQLrepository();
        }



        public List<Price> getPrice()
        {
            var query = SQLrepository.getPriceConstant;

            using (var connection = SQLrepository.GetConnection()) 
            {
                connection.Open();

                return connection.Query<Price>(query).ToList();
}
        }

    }
}

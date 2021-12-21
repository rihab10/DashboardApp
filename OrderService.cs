using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardApp.DataLayer
{
    public class OrderService
    {
        private SQLrepository SQLrepository;

        public  OrderService()
        {
            SQLrepository = new SQLrepository();
        }


        public List<Order> getOrder()
        {
            var query = SQLrepository.getOrderConstant;
            

            using (var connection = SQLrepository.GetConnection())
            {
                connection.Open();

                return connection.Query<Order>(query).ToList();
                
               
                
            }
        }


        public int GetAllOrders (int account_id)
        {
            var orderlist= getOrder();
           var filterlist = new List<Order>();
            foreach (var order in orderlist)
            {
                if (order.account_id == account_id)
                {
                    filterlist.Add(order);
                }
            }
            return filterlist.Count();
        }




    }
}
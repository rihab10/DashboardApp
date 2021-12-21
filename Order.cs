using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardApp.DataLayer
{
    public class Order
    {
        public double order_id { get; set; }
        public double account_id { get; set; }
        public double security_id { get; set; }

        public string quantity { get; set; }
        public string created_time { get; set; }
  

    }
}

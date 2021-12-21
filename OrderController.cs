using DashboardApp.DataLayer;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DashboardApp.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        public IHttpActionResult Get()
        {
            OrderService _as = new OrderService();
            return Ok(_as.getOrder());
        }
        [HttpGet]
        [ActionName("GetAllOrders")]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IHttpActionResult GetAllOrders(int id)
        {
            OrderService _as = new OrderService();
            return Ok(_as.GetAllOrders(id));
        }
    }
}

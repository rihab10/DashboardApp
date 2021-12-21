using DashboardApp.DataLayer;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DashboardApp.Controllers
{
    public class PositionController : ApiController
    {


        [HttpGet]
        [ActionName("Get")]
        public IHttpActionResult Get()
        {
            PositionService _as = new PositionService();
            return Ok(_as.GetPosition());
        }

        [HttpGet]
        [ActionName("portfolioValue")]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IHttpActionResult portfolioValue(decimal id)
        {
            PositionService _as = new PositionService();
            return Ok(_as.getPortfolioValue(id));

        }


        [HttpGet]
        [ActionName("getWeigth")]
         [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IHttpActionResult getWeigth(decimal id)
        {
            PositionService _as = new PositionService();
            return Ok(_as.getWeigth(id));
        }



        [HttpGet]
        [ActionName("getTopHolding")]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IHttpActionResult getTopHolding(decimal id)
        {
            PositionService _as = new PositionService();
            return Ok(_as.getTopHolding(id));
        }



        [HttpGet]
        [ActionName("getStockReturn")]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IHttpActionResult getStockReturn(decimal id)
        {
            PositionService _as = new PositionService();
            return Ok(_as.getStockReturn(id));
        }


        [HttpGet]
        [ActionName("getTotalStockReturn")]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IHttpActionResult getTotalStockReturn(decimal id)
        {
            PositionService _as = new PositionService();
            return Ok(_as.getTotalStockReturn(id));
        }


    }
}

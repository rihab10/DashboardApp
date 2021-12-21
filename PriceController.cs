using DashboardApp.DataLayer;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DashboardApp.Controllers
{
    
    public class PriceController : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IHttpActionResult Get()
            {
                PriceService _as = new PriceService();
                return Ok(_as.getPrice());
            }
        }


    }


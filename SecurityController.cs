using DashboardApp.DataLayer;
using System.Web.Http;

namespace DashboardApp.Controllers
{
    public class SecurityController : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        public IHttpActionResult Get()
        {
            SecurityService _as = new SecurityService();
            return Ok(_as.getSecurity());
        }
    }
}

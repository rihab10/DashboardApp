using System.Web.Http;
using System.Web.Http.Cors;
using DashboardApp.DataLayer;

namespace DashboardApp.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            AccountService _as = new AccountService();
            return Ok(_as.getAccounts());
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BudgetTrackerAPI.Controllers
{
    public class UsersController : BaseController
    {
        /// <summary>
        /// Get User By Email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [Route("GetUserByEmail")]
        public async Task<IHttpActionResult> GetUserByEmail(string Email)
        {
            var data = await db.GetUserByEmail(Email);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}

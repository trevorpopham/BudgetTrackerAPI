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
    /// <summary>
    /// Households Controller
    /// </summary>
    [RoutePrefix("api/Households")]
    public class HouseholdsController : BaseController
    {
        /// <summary>
        /// Add Household
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpPost, Route("AddHousehold")]
        public IHttpActionResult AddHousehold(string Name)
        {
            return Ok(db.AddHousehold(Name));
        }
        /// <summary>
        /// Get All Households 
        /// </summary>
        /// <returns></returns>
        [Route("GetHouseholds")]
        public async Task<IHttpActionResult> GetHouseholds()
        {
            var data = await db.GetHouseholds();
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get Household by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetHouseholdDetails")]
        public async Task<IHttpActionResult> GetHouseholdDetails(int Id)
        {
            var data = await db.GetHouseholdDetails(Id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Edit Household
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Balance"></param>
        /// <param name="StartAmount"></param>
        /// <returns></returns>
        [HttpPut, Route("EditHousehold")]
        public IHttpActionResult EditHousehold(int Id, string Name, decimal Balance, decimal StartAmount)
        {
            return Ok(db.EditHousehold(Id, Name, Balance, StartAmount));
        }
        /*/// <summary>
        /// Delete Household
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteHousehold")]
        public IHttpActionResult DeleteHousehold(int Id)
        {
            return Ok(db.DeleteHousehold(Id));
        }*/

    }
}

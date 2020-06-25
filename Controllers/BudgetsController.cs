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
    /// Budget Controller
    /// </summary>
    public class BudgetsController : BaseController
    {
        /// <summary>
        /// Add Budget
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="HouseholdId"></param>
        /// <returns></returns>
        [HttpPost, Route("AddBudget")]
        public IHttpActionResult AddBudget(string Name, int HouseholdId)
        {
            return Ok(db.AddBudget(Name, HouseholdId));
        }
        /// <summary>
        /// Get All Budgets
        /// </summary>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<IHttpActionResult> GetBudgets()
        {
            var data = await db.GetBudgets();
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get Budgets by Group Id
        /// </summary>
        /// <param name="HouseholdId"></param>
        /// <returns></returns>
        [Route("GetBudgetsByHousehold")]
        public async Task<IHttpActionResult> GetBudgetByHousehold(int HouseholdId)
        {
            var data = await db.GetBudgetsByHousehold(HouseholdId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [Route("GetBudgetDetails")]
        public async Task<IHttpActionResult> GetBudgetDetails(int Id)
        {
            var data = await db.GetBudgetDetails(Id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Edit Budget
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="HouseholdId"></param>
        /// <param name="Name"></param>
        /// <param name="Spent"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        [HttpPut, Route("EditBudget")]
        public IHttpActionResult EditBudget(int Id, string Name, decimal Spent, decimal Target)
        {
            return Ok(db.EditBudget(Id, Name, Spent, Target));
        }
        /// <summary>
        /// Delete Budget
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBudget")]
        public IHttpActionResult DeleteBudget(int Id)
        {
            return Ok(db.DeleteBudget(Id));
        }
    }
}

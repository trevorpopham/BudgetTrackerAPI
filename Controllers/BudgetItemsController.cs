using BudgetTrackerAPI.Models;
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
    /// Budget Items Controller
    /// </summary>
    [RoutePrefix("api/BudgetItems")]
    public class BudgetItemsController : BaseController
    {
        /// <summary>
        /// Add Budget Item
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="BudgetId"></param>
        /// <returns></returns>
        [HttpPost, Route("AddBudgetItem")]
        public IHttpActionResult AddBudgetItem(string Name, int BudgetId)
        {
            return Ok(db.AddBudgetItem(Name, BudgetId));
        }
        /// <summary>
        /// Get All Budget Items
        /// </summary>
        /// <returns></returns>
        [Route("GetBudgetItems")]
        public async Task<IHttpActionResult> GetBudgetItems()
        {
            var data = await db.GetBudgetItems();
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get Budget Items By Budget Id
        /// </summary>
        /// <param name="BudgetId"></param>
        /// <returns></returns>
        [Route("GetBudgetItemsByBudget")]
        public async Task<IHttpActionResult> GetBudgetItemsByBudget(int BudgetId)
        {
            var data = await db.GetBudgetItemsByBudget(BudgetId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get Budget Item by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails")]
        public async Task<IHttpActionResult> GetBudgetItemDetails(int Id)
        {
            var data = await db.GetBudgetItemDetails(Id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Edit Budget Item
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Spent"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        [HttpPut, Route("EditBudgetItem")]
        public IHttpActionResult EditBudgetItem(int Id, string Name, decimal Spent, decimal Target)
        {
            return Ok(db.EditBudgetItem(Id, Name, Spent, Target));
        }
        /// <summary>
        /// Delete Budget Item
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBudgetItem")]
        public IHttpActionResult DeleteBudgetItem(int Id)
        {
            return Ok(db.DeleteBudgetItem(Id));
        }
    }
}

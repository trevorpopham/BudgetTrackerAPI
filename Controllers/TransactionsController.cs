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
    /// Transactions Controller
    /// </summary>
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : BaseController
    {
        /// <summary>
        /// Add Transactions
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="Memo"></param>
        /// <param name="Type"></param>
        /// <param name="CreatorId"></param>
        /// <param name="HouseholdId"></param>
        /// <param name="BudgetId"></param>
        /// <param name="BudgetItemId"></param>
        /// <param name="BankAccountId"></param>
        /// <returns></returns>
        [HttpPost, Route("AddTransaction")]
        public IHttpActionResult AddTransaction(decimal Amount, string Memo, TransactionType Type, string CreatorId, int HouseholdId, int BudgetId, int BudgetItemId, int BankAccountId)
        {
            return Ok(db.AddTransaction(Amount, Memo, Type, CreatorId, HouseholdId, BudgetId, BudgetItemId, BankAccountId));
        }
        /// <summary>
        /// Get All Transactions
        /// </summary>
        /// <returns></returns>
        [Route("GetTransactions")]
        public async Task<IHttpActionResult> GetTransactions()
        {
            var data = await db.GetTransactions();
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get a Users Transactions
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("GetTransactionsByUser")]
        public async Task<IHttpActionResult> GetTransactionsByUser(string UserId)
        {
            var data = await db.GetTransactionsByUser(UserId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get Transactions By Bank Id
        /// </summary>
        /// <param name="BankId"></param>
        /// <returns></returns>
        [Route("GetTransactionsByBank")]
        public async Task<IHttpActionResult> GetTransactionsByBank(int BankId)
        {
            var data = await db.GetTransactionsByBank(BankId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get Transactions By Group Id
        /// </summary>
        /// <param name="HouseholdId"></param>
        /// <returns></returns>
        [Route("GetTransactionsByGroup")]
        public async Task<IHttpActionResult> GetTransactionsByGroup(int HouseholdId)
        {
            var data = await db.GetTransactionsByGroup(HouseholdId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get Transaction by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        public async Task<IHttpActionResult> GetTransactionDetails(int Id)
        {
            var data = await db.GetHouseholdDetails(Id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Calculate Transaction
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut, Route("CalculateTransaction")]
        public IHttpActionResult CalculateTransaction(int Id)
        {
            return Ok(db.CalculateTransaction(Id));
        }
        /// <summary>
        /// Delete Transaction
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteTransaction")]
        public IHttpActionResult DeleteTransaction(int Id)
        {
            return Ok(db.DeleteTransaction(Id));
        }
    }
}

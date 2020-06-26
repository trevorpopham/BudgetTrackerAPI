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
    /// Bank Accounts Controller
    /// </summary>
    [RoutePrefix("api/BankAccounts")]
    public class BankAccountsController : BaseController
    {
        /// <summary>
        /// Add A Bank Account
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Balance"></param>
        /// <param name="Type"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost, Route("AddAccount")]
        public IHttpActionResult AddBudgetItem(string Name, decimal Balance, AccountType Type, string UserId)
        {
            return Ok(db.AddAccount(Name, Balance, Type, UserId));
        }
        /// <summary>
        /// Get All Bank Accounts
        /// </summary>
        /// <returns></returns>
        [Route("GetBankAccounts")]
        public async Task<IHttpActionResult> GetBankAccounts()
        {
            var data = await db.GetBankAccounts();
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get Bank Accounts By User Id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("GetBankAccountsByUser")]
        public async Task<IHttpActionResult> GetBankAccountsByUser(string UserId)
        {
            var data = await db.GetBankAccountsByUser(UserId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Get Bank Account by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetBankAccountDetails")]
        public async Task<IHttpActionResult> GetBankAccountDetails(int Id)
        {
            var data = await db.GetBankAccountDetails(Id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        /// <summary>
        /// Edit Bank Account
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserId"></param>
        /// <param name="Name"></param>
        /// <param name="Balance"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        [HttpPut, Route("EditBankAccount")]
        public IHttpActionResult EditBankAccount(int Id, string UserId, string Name, decimal Balance, AccountType Type)
        {
            return Ok(db.EditBankAccount(Id, UserId, Name, Balance, Type));
        }
        /// <summary>
        /// Delete Bank Account
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBankAccount")]
        public IHttpActionResult DeleteBankAccount(int Id)
        {
            return Ok(db.DeleteBankAccount(Id));
        }
    }
}

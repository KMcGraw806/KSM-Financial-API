using KSM_Financial_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace KSM_Financial_API.Controllers
{
    /// <summary>
    /// Bank Accounts Controller
    /// </summary>
    [RoutePrefix("api/BankAccounts")]
    public class BankAccountsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Endpoint to return all Bank Account Data
        /// </summary>
        /// <returns>List of Bank Account model</returns>
        [Route("GetAllBankAccountData")]
        public async Task<List<BankAccount>> GetAllBankAccountData()
        {
            return await db.GetAllBankAccountData();
        }

        /// <summary>
        /// Endpoint to return all Bank Account data in JSON
        /// </summary>
        /// <returns>List of Bank Account model in JSON</returns>
        [Route("GetAllBankAccountData/json")]
        public async Task<IHttpActionResult> GetAllBankAccountDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBankAccountData());
            return Ok(json);
        }

        /// <summary>
        /// Returns the information for a single Bank Account
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">The Id of the Bank Account you want to view</param>
        /// <returns>Single Bank Account model</returns>
        [Route("GetDataForSingleBankAccount")]
        public async Task<BankAccount> GetBankAccountDataById(int id)
        {
            return await db.GetBankAccountDataById(id);
        }

        /// <summary>
        /// Returns single Bank Account information in JSON
        /// </summary>
        /// <param name="id">The Id of the Bank Account you want to view</param>
        /// <returns>Single Bank Account model in JSON</returns>
        [Route("GetDataForSingleBankAccount/json")]
        public async Task<IHttpActionResult> GetBankAccountDataAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBankAccountDataById(id)));
        }

        /// <summary>
        /// Create a new Bank Account
        /// </summary>
        /// <param name="householdId">The Id of the household whose </param>
        /// <param name="ownerId">The Id of the person who will own this Bank Account</param>
        /// <param name="accountName">What you would like the Account Name to be</param>
        /// <param name="startingBalance">How much money the Bank Account will start with</param>
        /// <param name="currentBalance">How much money is currently in the Bank Account</param>
        /// <param name="warningBalance">When you should be alerted of low balance</param>
        /// <param name="isDeleted">Is this Bank Account Deleted?</param>
        /// <param name="accountType">Checking or Saving?</param>
        /// <returns></returns>
        [HttpPost, Route("CreateBankAccount")]
        public IHttpActionResult CreateBankAccount(int householdId, string ownerId, string accountName, decimal startingBalance, decimal currentBalance, decimal warningBalance, bool isDeleted, int accountType)
        {
            return Ok(db.CreateBankAccount(householdId, ownerId, accountName, startingBalance, currentBalance, warningBalance, isDeleted, accountType));
        }

        /// <summary>
        /// Edit a Bank Account by the Id provided
        /// </summary>
        /// <param name="Id">The Id of the Bank Account that you wish to Edit</param>
        /// <param name="householdId">The Id of the Household the Bank Account belongs to</param>
        /// <param name="ownerId">The Id of the person that the Bank Account belongs to</param>
        /// <param name="accountName">The name of the Bank Account</param>
        /// <param name="startingBalance">Initial Balance</param>
        /// <param name="currentBalance">Balance as of right now</param>
        /// <param name="warningBalance">Balance </param>
        /// <param name="isDeleted">Is this Bank Account Deleted?</param>
        /// <param name="accountType">Checking or Savings</param>
        /// <returns></returns>
        [HttpPatch, Route("EditBankAccount")]
        public IHttpActionResult EditBankAccount(int Id, int householdId, string ownerId, string accountName, decimal startingBalance, decimal currentBalance, decimal warningBalance, bool isDeleted, int accountType)
        {
            return Ok(db.EditBankAccount(Id, householdId, ownerId, accountName, startingBalance, currentBalance, warningBalance, isDeleted, accountType));
        }

        /// <summary>
        /// Deletes a Bank Account by the Id provided
        /// </summary>
        /// <param name="id">The Id for the Bank Account that you wish to Delete</param>
        /// <returns></returns>
        [Route("DeleteBankAccount")]
        public async Task<int> DeleteBankAccount(int id)
        {
            return await db.DeleteBankAccountById(id);
        }
    }
}

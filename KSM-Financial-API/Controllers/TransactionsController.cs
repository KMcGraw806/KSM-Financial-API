using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using KSM_Financial_API.Models;
using Newtonsoft.Json;

namespace KSM_Financial_API.Controllers
{
    /// <summary>
    /// Transactions Controller
    /// </summary>
    public class TransactionsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Endpoint to return all Transaction Data
        /// </summary>
        /// <returns>List of Transaction model</returns>
        [Route("GetAllTransactionData")]
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await db.GetAllTransactionData();
        }

        /// <summary>
        /// Endpoint to return all Transaction data in JSON
        /// </summary>
        /// <returns>List of Transaction model in JSON</returns>
        [Route("GetAllTransactionData/json")]
        public async Task<IHttpActionResult> GetAllTransactionDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllTransactionData());
            return Ok(json);
        }

        /// <summary>
        /// Returns the information for a single Transaction
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">The PK of the Transaction you want to view</param>
        /// <returns>Single Transaction model</returns>
        [Route("GetDataForSingleTransaction")]
        public async Task<Transaction> GetTransactionDataById(int id)
        {
            return await db.GetTransactionDataById(id);
        }

        /// <summary>
        /// Returns single Transaction information in JSON
        /// </summary>
        /// <param name="id">The PK of the Transaction you want to view</param>
        /// <returns>Single Transaction model in JSON</returns>
        [Route("GetDataForSingleTransaction/json")]
        public async Task<IHttpActionResult> GetTransactionDataAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetTransactionDataById(id)));
        }

        /// <summary>
        /// Create a new Transaction
        /// </summary>
        /// <param name="accountId">The Bank Account to pull from</param>
        /// <param name="budgetItemId">The Budget Item the Transaction is listed under</param>
        /// <param name="ownerId">The person creating the Transaction</param>
        /// <param name="transactionType"></param>
        /// <param name="amount">The amount </param>
        /// <param name="memo"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        [HttpPost, Route("CreateTransaction")]
        public IHttpActionResult CreateTransaction(int accountId, int budgetItemId, string ownerId, int transactionType, decimal amount, string memo, bool isDeleted)
        {
            return Ok(db.CreateTransaction(accountId, budgetItemId, ownerId, transactionType, amount, memo, isDeleted));
        }

        /// <summary>
        /// Edit a Transaction by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="accountId"></param>
        /// <param name="budgetItemId"></param>
        /// <param name="ownerId"></param>
        /// <param name="transactionType"></param>
        /// <param name="amount"></param>
        /// <param name="memo"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        [HttpPatch, Route("EditTransaction")]
        public IHttpActionResult EditTransaction(int Id, int accountId, int budgetItemId, string ownerId, int transactionType, decimal amount, string memo, bool isDeleted)
        {
            return Ok(db.EditTransaction(Id, accountId, budgetItemId, ownerId, transactionType, amount, memo, isDeleted));
        }

        /// <summary>
        /// Delete a Transaction by the Id provided
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteTransaction")]
        public async Task<int> DeleteTransaction(int id)
        {
            return await db.DeleteTransactionById(id);
        }
    }
}

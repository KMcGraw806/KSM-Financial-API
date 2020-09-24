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
    /// Budget Item Controller
    /// </summary>
    [RoutePrefix("api/BudgetItems")]
    public class BudgetItemsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Endpoint to return all Budget Item Data
        /// </summary>
        /// <returns>List of Budget Item model</returns>
        [Route("GetAllBudgetItemData")]
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await db.GetAllBudgetItemData();
        }

        /// <summary>
        /// Endpoint to return all Budget Item data in JSON
        /// </summary>
        /// <returns>List of Budget Item model in JSON</returns>
        [Route("GetAllBudgetItemData/json")]
        public async Task<IHttpActionResult> GetAllBudgetItemDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetItemData());
            return Ok(json);
        }

        /// <summary>
        /// Returns the information for a single Budget Item
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">The PK of the Budget Item you want to view</param>
        /// <returns>Single Budget Item model</returns>
        [Route("GetDataForSingleBudgetItem")]
        public async Task<BudgetItem> GetBudgetItemDataById(int id)
        {
            return await db.GetBudgetItemDataById(id);
        }

        /// <summary>
        /// Returns single Budget Item information in JSON
        /// </summary>
        /// <param name="id">The PK of the Budget Item you want to view</param>
        /// <returns>Single Budget Item model in JSON</returns>
        [Route("GetDataForSingleBudgetItem/json")]
        public async Task<IHttpActionResult> GetBudgetItemDataAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetItemDataById(id)));
        }

        /// <summary>
        /// Create a new Budget Item
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="itemName"></param>
        /// <param name="targetAmount"></param>
        /// <param name="currentAmount"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        [HttpPost, Route("CreateBudgetItem")]
        public IHttpActionResult CreateBudgetItem(int budgetId, string itemName, decimal targetAmount, decimal currentAmount, bool isDeleted)
        {
            return Ok(db.CreateBudgetItem(budgetId, itemName, targetAmount, currentAmount, isDeleted));
        }

        /// <summary>
        /// Edit a Budget Item by providing the Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="budgetId"></param>
        /// <param name="itemName"></param>
        /// <param name="targetAmount"></param>
        /// <param name="currentAmount"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        [HttpPatch, Route("EditBudgetItem")]
        public IHttpActionResult EditBudgetItem(int Id, int budgetId, string itemName, decimal targetAmount, decimal currentAmount, bool isDeleted)
        {
            return Ok(db.EditBudgetItem(Id, budgetId, itemName, targetAmount, currentAmount, isDeleted));
        }

        /// <summary>
        /// Delete a Budget Item by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteBudgetItem")]
        public async Task<int> DeleteBudgetItem(int id)
        {
            return await db.DeleteBudgetItemById(id);
        }
    }
}

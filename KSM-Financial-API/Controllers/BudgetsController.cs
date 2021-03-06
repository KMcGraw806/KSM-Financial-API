﻿using KSM_Financial_API.Models;
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
    /// Budgets Controller
    /// </summary>
    [RoutePrefix("api/Budgets")]
    public class BudgetsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Endpoint to return all Budget Data
        /// </summary>
        /// <returns>List of Budget model</returns>
        [Route("GetAllBudgetData")]
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await db.GetAllBudgetData();
        }

        /// <summary>
        /// Endpoint to return all Budget data in JSON
        /// </summary>
        /// <returns>List of Budget model in JSON</returns>
        [Route("GetAllBudgetData/json")]
        public async Task<IHttpActionResult> GetAllBudgetDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetData());
            return Ok(json);
        }

        /// <summary>
        /// Returns the information for a single Budget
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">The PK of the Budget you want to view</param>
        /// <returns>Single Budget model</returns>
        [Route("GetDataForSingleBudget")]
        public async Task<Budget> GetBudgetDataById(int id)
        {
            return await db.GetBudgetDataById(id);
        }

        /// <summary>
        /// Returns single Budget information in JSON
        /// </summary>
        /// <param name="id">The PK of the Budget you want to view</param>
        /// <returns>Single Budget model in JSON</returns>
        [Route("GetDataForSingleBudget/json")]
        public async Task<IHttpActionResult> GetBudgetDataAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetDataById(id)));
        }

        /// <summary>
        /// Create a new Budget
        /// </summary>
        /// <param name="householdId">The Id of the Household that the new Budget will be added to</param>
        /// <param name="ownerId">The Id of the person who this Budget will belong to</param>
        /// <param name="budgetName">The Name of the Budget</param>
        /// <param name="currentAmount">The amount that has currently been spent on the Budget</param>
        /// <returns></returns>
        [HttpPost, Route("CreateBudget")]
        public IHttpActionResult CreateBudget(int householdId, string ownerId, string budgetName, decimal currentAmount)
        {
            return Ok(db.CreateBudget(householdId, ownerId, budgetName, currentAmount));
        }

        /// <summary>
        /// Edit a Budget by providing the Id
        /// </summary>
        /// <param name="Id">The Id of the Budget you want to Edit</param>
        /// <param name="householdId">The Id of the Household that the Budget belongs to</param>
        /// <param name="ownerId">The Id of the owner of the Budget</param>
        /// <param name="budgetName">The name of the Budget</param>
        /// <param name="currentAmount">The amount that has currently been spent on the Budget</param>
        /// <returns></returns>
        [HttpPatch, Route("EditBudget")]
        public IHttpActionResult EditBudget(int Id, int householdId, string ownerId, string budgetName, decimal currentAmount)
        {
            return Ok(db.EditBudget(Id, householdId, ownerId, budgetName, currentAmount));
        }

        /// <summary>
        /// Delete Budget by it's Id
        /// </summary>
        /// <param name="id">The Id of the Budget you would like to delete</param>
        /// <returns></returns>
        [Route("DeleteBudget")]
        public async Task<int> DeleteBudget(int id)
        {
            return await db.DeleteBudgetById(id);
        }
    }
}

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
    /// Households Controller
    /// </summary>
    [RoutePrefix("api/Households")]
    public class HouseholdsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Endpoint to return all household data
        /// </summary>
        /// <returns>List of Household Model</returns>
        /// <remarks>This end point is not meant to be hit, testing purposes only</remarks>
        [Route("GetAllHouseData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await db.GetAllHouseholdData();
        }

        /// <summary>
        /// Endpoint to return all household data in JSON
        /// </summary>
        /// <returns>List of Household model</returns>
        [Route("GetAllHouseholdData/json")]
        public async Task<IHttpActionResult> GetDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllHouseholdData());
            return Ok(json);
        }

        /// <summary>
        /// Returns the information for a single Household
        /// </summary>
        /// <remarks>This area can be used to provide a fuller description of whatever to the user</remarks>
        /// <param name="hhId">The PK of the Household you want to view</param>
        /// <returns>Single Household model</returns>
        [Route("GetDataForSingleHousehold")]
        public async Task<Household> GetHouseholdDataById(int hhId)
        {
            return await db.GetHouseholdDataById(hhId);
        }

        /// <summary>
        /// Returns single Household information in JSON
        /// </summary>
        /// <param name="hhId">The PK of the Household you want to view</param>
        /// <returns>Single Household model as JSON</returns>
        [Route("GetDataForSingleHousehold/json")]
        public async Task<IHttpActionResult> GetHouseholdDataAsJson(int hhId)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetHouseholdDataById(hhId)));
        }

        /// <summary>
        /// Create a new Household
        /// </summary>
        /// <param name="householdName">Name you would like to give the Household</param>
        /// <param name="greeting">Greeting for new Household Members</param>
        /// <param name="isDeleted">Is this Household Deleted?</param>
        /// <returns></returns>
        [HttpPost, Route("CreateHousehold")]
        public IHttpActionResult CreateHousehold(string householdName, string greeting, bool isDeleted)
        {
            return Ok(db.CreateHousehold(householdName, greeting, isDeleted));
        }

        /// <summary>
        /// Edit a Household by providing the Id
        /// </summary>
        /// <param name="Id">The Id of the Household you want to edit</param>
        /// <param name="householdName">The name of the Household you want to edit</param>
        /// <param name="greeting">Greeting message of the Household you want to edit</param>
        /// <param name="isDeleted">Is this Household deleted?</param>
        /// <returns></returns>
        [HttpPatch, Route("EditHousehold")]
        public IHttpActionResult EditHousehold(int Id, string householdName, string greeting, bool isDeleted)
        {
            return Ok(db.EditHousehold(Id, householdName, greeting, isDeleted));
        }


        /// <summary>
        /// Deletes single Household by Id
        /// </summary>
        /// <param name="id">The Id of the Household you want to delete</param>
        /// <returns></returns>
        [Route("DeleteHousehold")]
        public async Task<int> DeleteHousehold(int id)
        {
            return await db.DeleteHouseholdById(id);
        }
    }
}

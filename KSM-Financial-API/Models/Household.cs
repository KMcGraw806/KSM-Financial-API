using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSM_Financial_API.Models
{
    /// <summary>
    /// Household
    /// </summary>
    public class Household
    {
        /// <summary>
        /// PK
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Household name determined by user
        /// </summary>
        public string HouseholdName { get; set; }

        /// <summary>
        /// Household greeting determined by user
        /// </summary>
        public string Greeting { get; set; }

        /// <summary>
        /// Created date of the Household
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Is this household soft deleted or not?
        /// </summary>
        public bool IsDeleted { get; set; }

    }

}
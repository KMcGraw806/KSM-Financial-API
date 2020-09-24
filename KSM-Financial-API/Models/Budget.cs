using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSM_Financial_API.Models
{
    /// <summary>
    /// Budget
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// Id of the Budget
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the Household of the Budget
        /// </summary>
        public int HouseholdId { get; set; }

        /// <summary>
        /// Id of the Owner of the Budget
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Date and Time Budget was Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Name of the Budget
        /// </summary>
        public string BudgetName { get; set; }

        /// <summary>
        /// Current Amount
        /// </summary>
        public decimal CurrentAmount { get; set; }
    }
}
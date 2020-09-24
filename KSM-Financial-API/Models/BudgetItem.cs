using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSM_Financial_API.Models
{
    /// <summary>
    /// Budget Item
    /// </summary>
    public class BudgetItem
    {
        /// <summary>
        /// Id of the Budget Item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the Budget that the Budget Item is in
        /// </summary>
        public int BudgetId { get; set; }

        /// <summary>
        /// Date and Time Budget Item was Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Name of the Budget Item
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Target Amount
        /// </summary>
        public decimal TargetAmount { get; set; }

        /// <summary>
        /// Current Amount
        /// </summary>
        public decimal CurrentAmount { get; set; }

        /// <summary>
        /// Boolean that shows whether or not Budget Item has been Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
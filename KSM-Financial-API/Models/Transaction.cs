using KSM_Financial_API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSM_Financial_API.Models
{
    /// <summary>
    /// Transaction
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The P(rimary) K(ey) of the Transaction
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The P(rimary) K(ey) of the Account
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// The P(rimary) K(ey) of the Budget Item
        /// </summary>
        public int? BudgetItemId { get; set; }

        /// <summary>
        /// The P(rimary) K(ey) of the Owner
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Type of Transaction (Deposit, Withdrawal, Transfer)
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// Date and Time Transaction was Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Explanation of the Transaction
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Soft delete boolean
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
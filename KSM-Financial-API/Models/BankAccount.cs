using KSM_Financial_API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSM_Financial_API.Models
{
    /// <summary>
    /// Bank Account
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Bank Account Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the Household that the Bank Account is in
        /// </summary>
        public int? HouseholdId { get; set; }

        /// <summary>
        /// Id of the Owner of the Bank Account
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Name of the Account
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Date and Time that the Account was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Starting Balance
        /// </summary>
        public decimal StartingBalance { get; internal set; }

        /// <summary>
        /// Current Balance
        /// </summary>
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// Warning Balance
        /// </summary>
        public decimal WarningBalance { get; set; }

        /// <summary>
        /// Boolean that indicates whether Bank Account is deleted or not
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Type of Account (Checking or Savings)
        /// </summary>
        public AccountType AccountType { get; set; }
    }
}
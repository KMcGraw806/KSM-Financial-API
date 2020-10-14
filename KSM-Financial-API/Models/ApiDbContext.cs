using KSM_Financial_API.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KSM_Financial_API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiDbContext()
            : base("ApiConnection")
        {}

        #region Household
        /// <summary>
        /// Returns all Household Data.
        /// </summary>
        /// <returns>List of Household Model</returns>
        //Here is where I add the code to call my various stored procedures
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdData").ToListAsync();
        }

        /// <summary>
        /// Returns all Household Data for one Id
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<Household> GetHouseholdDataById(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHouseholdDataById @Id",
                new SqlParameter("Id", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will create a new Household
        /// </summary>
        /// <param name="householdName"></param>
        /// <param name="greeting"></param>
        /// <returns></returns>
        public int CreateHousehold(string householdName, string greeting)
        {
            return Database.ExecuteSqlCommand("CreateHousehold @HouseholdName, @Greeting",

                new SqlParameter("HouseholdName", householdName),
                new SqlParameter("Greeting", greeting)
            );
        }

        /// <summary>
        /// This will edit a Household by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="householdName"></param>
        /// <param name="greeting"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public int EditHousehold(int Id, string householdName, string greeting, bool isDeleted)
        {
            return Database.ExecuteSqlCommand("EditHousehold @Id @householdName, @greeting, @isDeleted",

                new SqlParameter("Id", Id),
                new SqlParameter("householdName", householdName),
                new SqlParameter("greeting", greeting),
                new SqlParameter("isDeleted", isDeleted)
            );
        }

        /// <summary>
        /// This will delete a Household by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteHouseholdById(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteHousehold @Id",
                new SqlParameter("Id", id));
        }
        #endregion

        #region Bank Account
        /// <summary>
        /// Returns all Bank Account Data.
        /// </summary>
        /// <returns>List of Bank Account Model</returns>
        public async Task<List<BankAccount>> GetAllBankAccountData()
        {
            return await Database.SqlQuery<BankAccount>("GetAllBankData").ToListAsync();
        }

        /// <summary>
        /// Returns all Bank Account Data for one Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BankAccount> GetBankAccountDataById(int Id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankDataById @Id",
                new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will create a new Bank Account
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="ownerId"></param>
        /// <param name="accountName"></param>
        /// <param name="startingBalance"></param>
        /// <param name="currentBalance"></param>
        /// <param name="warningBalance"></param>
        /// <param name="isDeleted"></param>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public int CreateBankAccount(int householdId, string ownerId, string accountName, decimal startingBalance, decimal currentBalance, decimal warningBalance, bool isDeleted, int accountType)
        {
            return Database.ExecuteSqlCommand("CreateBankAccount @HouseholdId, @OwnerId, @AcccountName, @StartingBalance, @CurrentBalance, @WarningBalance, @isDeleted, @AccountType",
                new SqlParameter("HouseholdId", householdId),
                new SqlParameter("OwnerId", ownerId),
                new SqlParameter("AccountName", accountName),
                new SqlParameter("StartingBalance", startingBalance),
                new SqlParameter("CurrentBalance", currentBalance),
                new SqlParameter("WarningBalance", warningBalance),
                new SqlParameter("isDeleted", isDeleted),
                new SqlParameter("AccountType", accountType));
        }
        
        /// <summary>
        /// This will edit a Bank Account by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="householdId"></param>
        /// <param name="ownerId"></param>
        /// <param name="accountName"></param>
        /// <param name="startingBalance"></param>
        /// <param name="currentBalance"></param>
        /// <param name="warningBalance"></param>
        /// <param name="isDeleted"></param>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public int EditBankAccount(int Id, int householdId, string ownerId, string accountName, decimal startingBalance, decimal currentBalance, decimal warningBalance, bool isDeleted, int accountType)
        {
            return Database.ExecuteSqlCommand("CreateBankAccount @HouseholdId, @OwnerId, @AcccountName, @StartingBalance, @CurrentBalance, @WarningBalance, @isDeleted, @AccountType",
                new SqlParameter("Id", Id),
                new SqlParameter("HouseholdId", householdId),
                new SqlParameter("OwnerId", ownerId),
                new SqlParameter("AccountName", accountName),
                new SqlParameter("StartingBalance", startingBalance),
                new SqlParameter("CurrentBalance", currentBalance),
                new SqlParameter("WarningBalance", warningBalance),
                new SqlParameter("isDeleted", isDeleted),
                new SqlParameter("AccountType", accountType));
        }

        /// <summary>
        /// This will delete a Bank Account by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteBankAccountById(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteBankAccount @Id",
                new SqlParameter("Id", id));
        }
        #endregion

        #region Budget
        /// <summary>
        /// Returns all Budget Data
        /// </summary>
        /// <returns>List of Budget Model</returns>
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await Database.SqlQuery<Budget>("GetAllBudgetData").ToListAsync();
        }

        /// <summary>
        /// Returns all Budget Data for one Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Budget> GetBudgetDataById(int Id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataById @Id",
                new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will create a new Budget
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="ownerId"></param>
        /// <param name="budgetName"></param>
        /// <param name="currentAmount"></param>
        /// <returns></returns>
        public int CreateBudget(int householdId, string ownerId, string budgetName, decimal currentAmount)
        {
            return Database.ExecuteSqlCommand("CreateBudget @householdId, @ownerId, @budgetName, @currentAmount",

                new SqlParameter("householdId", householdId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("budgetName", budgetName),
                new SqlParameter("currentAmount", currentAmount)
            );
        }
        
        /// <summary>
        /// This will edit a Budget by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="householdId"></param>
        /// <param name="ownerId"></param>
        /// <param name="budgetName"></param>
        /// <param name="currentAmount"></param>
        /// <returns></returns>
        public int EditBudget(int Id, int householdId, string ownerId, string budgetName, decimal currentAmount)
        {
            return Database.ExecuteSqlCommand("EditBudget @Id @householdId, @ownerId, @budgetName, @currentAmount",

                new SqlParameter("Id", Id),
                new SqlParameter("householdId", householdId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("budgetName", budgetName),
                new SqlParameter("currentAmount", currentAmount)
            );
        }

        /// <summary>
        /// This will delete a Budget by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteBudgetById(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteBudget @Id",
                new SqlParameter("Id", id));
        }
        #endregion

        #region Budget Items
        /// <summary>
        /// Returns all Budget Item Data.
        /// </summary>
        /// <returns>List of Budget Item Model</returns>
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await Database.SqlQuery<BudgetItem>("GetAllBudgetItemData").ToListAsync();
        }

        /// <summary>
        /// Returns all Budget Item Data for one Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BudgetItem> GetBudgetItemDataById(int Id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDataById @Id",
                new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will create a new Budget Item
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="itemName"></param>
        /// <param name="targetAmount"></param>
        /// <param name="currentAmount"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public int CreateBudgetItem(int budgetId, string itemName, decimal targetAmount, decimal currentAmount, bool isDeleted)
        {
            return Database.ExecuteSqlCommand("CreateBudgetItem @budgetId, @itemName, @targetAmount, @currentAmount, @isDeleted",

                new SqlParameter("budgetId", budgetId),
                new SqlParameter("itemName", itemName),
                new SqlParameter("targetAmount", targetAmount),
                new SqlParameter("currentAmount", currentAmount),
                new SqlParameter("isDeleted", isDeleted)
            );
        }

        /// <summary>
        /// This will edit a Budget Item by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="budgetId"></param>
        /// <param name="itemName"></param>
        /// <param name="targetAmount"></param>
        /// <param name="currentAmount"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public int EditBudgetItem(int Id, int budgetId, string itemName, decimal targetAmount, decimal currentAmount, bool isDeleted)
        {
            return Database.ExecuteSqlCommand("EditBudgetItem @Id @budgetId, @itemName, @targetAmount, @currentAmount, @isDeleted",

                new SqlParameter("Id", Id),
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("itemName", itemName),
                new SqlParameter("targetAmount", targetAmount),
                new SqlParameter("currentAmount", currentAmount),
                new SqlParameter("isDeleted", isDeleted)
            );
        }

        /// <summary>
        /// This will delete a Budget Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteBudgetItemById(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteBudgetItem @Id",
                new SqlParameter("Id", id));
        }
        #endregion

        #region Transaction
        /// <summary>
        /// Returns all Transaction Data.
        /// </summary>
        /// <returns>List of Transaction Model</returns>
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactionData").ToListAsync();
        }

        /// <summary>
        /// Returns all Transaction Data for one Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionDataById(int Id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataById @Id",
                new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will create a new Transaction
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="budgetItemId"></param>
        /// <param name="ownerId"></param>
        /// <param name="transactionType"></param>
        /// <param name="amount"></param>
        /// <param name="memo"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public int CreateTransaction(int accountId, int budgetItemId, string ownerId, int transactionType, decimal amount, string memo, bool isDeleted)
        {
            return Database.ExecuteSqlCommand("CreateTransaction @accountId, @budgetItemId, @ownerId, @transactionType, @amount, @memo, @isDeleted",
                
                new SqlParameter("accountId", accountId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("transactionType", transactionType),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo),
                new SqlParameter("isDeleted", isDeleted)
            );
        }

        /// <summary>
        /// This will edit a Transaction by Id
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
        public int EditTransaction(int Id, int accountId, int budgetItemId, string ownerId, int transactionType, decimal amount, string memo, bool isDeleted)
        {
            return Database.ExecuteSqlCommand("EditTransaction @Id @accountId, @budgetItemId, @ownerId, @transactionType, @amount, @memo, @isDeleted",

                new SqlParameter("Id", Id),
                new SqlParameter("accountId", accountId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("transactionType", transactionType),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo),
                new SqlParameter("isDeleted", isDeleted)
            );
        }

        /// <summary>
        /// This will delete all Transaction Data By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteTransactionById(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteTransaction @Id",
                new SqlParameter("Id", id));
        }
        #endregion
    }
}
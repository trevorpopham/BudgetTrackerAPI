using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BudgetTrackerAPI.Models
{
    /// <summary>
    /// ApiContext Model
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ApiContext()
            :base("APIConnection")
        {

        }
        /// <summary>
        /// Create Constructor
        /// </summary>
        /// <returns></returns>
        public static ApiContext Create()
        {
            return new ApiContext();
        }
        /// <summary>
        /// Create a Household
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int AddHousehold(string Name)
        {
            return Database.ExecuteSqlCommand("AddHousehold @Name",
                new SqlParameter("Name", Name));
        }
        public int AddAccount(string Name, decimal Balance, AccountType Type, string UserId)
        {
            return Database.ExecuteSqlCommand("AddAccount @Name, @Balance, @Type, @UserId",
                new SqlParameter("Name", Name),
                new SqlParameter("Balance", Balance),
                new SqlParameter("Type", Type),
                new SqlParameter("UserId", UserId));
        }
        /// <summary>
        /// Create a Budget
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="HouseholdId"></param>
        /// <returns></returns>
        public int AddBudget(string Name, int HouseholdId)
        {
            return Database.ExecuteSqlCommand("AddBudget @Name, @HouseholdId",
                new SqlParameter("Name", Name),
                new SqlParameter("HouseholdId", HouseholdId));
        }
        /// <summary>
        /// Create a Budget Item
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="BudgetId"></param>
        /// <returns></returns>
        public int AddBudgetItem(string Name, int BudgetId)
        {
            return Database.ExecuteSqlCommand("AddBudgetItem @Name, @BudgetId",
                new SqlParameter("Name", Name),
                new SqlParameter("BudgetId", BudgetId));
        }
        /// <summary>
        /// Create a Transaction
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="Memo"></param>
        /// <param name="Type"></param>
        /// <param name="CreatorId"></param>
        /// <param name="HouseholdId"></param>
        /// <param name="BudgetId"></param>
        /// <param name="BudgetItemId"></param>
        /// <param name="BankAccountId"></param>
        /// <returns></returns>
        public int AddTransaction(decimal Amount, string Memo, TransactionType Type, string CreatorId, int HouseholdId, int BudgetId, int BudgetItemId, int BankAccountId)
        {
            return Database.ExecuteSqlCommand("AddTransaction @Amount, @Memo, @Type, @CreatorId, @HouseholdId, @BudgetId, @BudgetItemId, @BankAccountId",
                new SqlParameter("Amount", Amount),
                new SqlParameter("Memo", Memo),
                new SqlParameter("Type", Type),
                new SqlParameter("CreatorId", CreatorId),
                new SqlParameter("HouseholdId", HouseholdId),
                new SqlParameter("BudgetId", BudgetId),
                new SqlParameter("BudgetItemId", BudgetItemId),
                new SqlParameter("BankAccountId", BankAccountId));
        }
        /// <summary>
        /// Get All Households
        /// </summary>
        /// <returns></returns>
        public async Task<List<Household>> GetHouseholds()
        {
            return await Database.SqlQuery<Household>("GetHouseholds").ToListAsync();
        }
        /// <summary>
        /// Get Household by Id
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<Household> GetHouseholdDetails(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHouseholdDetails @hhId",
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Get All Bank Accounts
        /// </summary>
        /// <returns>Household Details</returns>
        public async Task<List<BankAccount>> GetBankAccounts()
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccounts").ToListAsync();
        }
        /// <summary>
        /// Get a Users Bank Accounts
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<List<BankAccount>> GetBankAccountsByUser(string UserId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountsByUser @userId",
                new SqlParameter("userId", UserId)).ToListAsync();
        }
        /// <summary>
        /// Get Bank Account by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BankAccount> GetBankAccountDetails(int Id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDetails @id",
                new SqlParameter("id", Id)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Get All Budgets
        /// </summary>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgets()
        {
            return await Database.SqlQuery<Budget>("GetBudgets").ToListAsync();
        }
        /// <summary>
        /// Get Budgets by Household Id
        /// </summary>
        /// <param name="HouseholdId"></param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgetsByHousehold(int HouseholdId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetsByHousehold @groupId",
                new SqlParameter("groupId", HouseholdId)).ToListAsync();
        }
        /// <summary>
        /// Get Budget by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Budget> GetBudgetDetails(int Id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetails @id",
                new SqlParameter("id", Id)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Get All Budget Items
        /// </summary>
        /// <returns></returns>
        public async Task<List<BudgetItem>> GetBudgetItems()
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems").ToListAsync();
        }
        /// <summary>
        /// Get Budget Items by Budget Id
        /// </summary>
        /// <param name="BudgetId"></param>
        /// <returns></returns>
        public async Task<List<BudgetItem>> GetBudgetItemsByBudget(int BudgetId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemsByBudget @budgetId",
                new SqlParameter("budgetId", BudgetId)).ToListAsync();
        }
        /// <summary>
        /// Get Budget by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BudgetItem> GetBudgetItemDetails(int Id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @id",
                new SqlParameter("id", Id)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Get All Transactions
        /// </summary>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactions()
        {
            return await Database.SqlQuery<Transaction>("GetTransactions").ToListAsync();
        }
        /// <summary>
        /// Get Transactions by UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactionsByUser(string UserId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionsByUser @userId",
                new SqlParameter("userId", UserId)).ToListAsync();
        }
        /// <summary>
        /// Get Transactions by BankId
        /// </summary>
        /// <param name="BankId"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactionsByBank(int BankId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionsByBank @bankId",
                new SqlParameter("bankId", BankId)).ToListAsync();
        }
        /// <summary>
        /// Get Transactions by HouseholdId
        /// </summary>
        /// <param name="HouseholdId"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactionsByGroup(int HouseholdId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionsByGroup @groupId",
                new SqlParameter("groupId", HouseholdId)).ToListAsync();
        }
        /// <summary>
        /// Get Transaction By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionDetails(int Id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @id",
                new SqlParameter("id", Id)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Get User Id by Email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public async Task<User> GetUserByEmail(string Email)
        {
            return await Database.SqlQuery<User>("GetUserByEmail @email",
                new SqlParameter("email", Email)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Edit Household
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Balance"></param>
        /// <param name="StartAmount"></param>
        /// <returns></returns>
        public int EditHousehold(int Id, string Name, decimal Balance, decimal StartAmount)
        {
            return Database.ExecuteSqlCommand("EditHousehold @id, @name, @balance, @startAmount",
                new SqlParameter("id", Id),
                new SqlParameter("name", Name),
                new SqlParameter("balance", Balance),
                new SqlParameter("startAmount", StartAmount));
        }
        /// <summary>
        /// Edit a Budget
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="HouseholdId"></param>
        /// <param name="Name"></param>
        /// <param name="Spent"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        public int EditBudget(int Id, string Name, decimal Spent, decimal Target)
        {
            return Database.ExecuteSqlCommand("EditBudget @id, @name, @spent, @target",
                new SqlParameter("id", Id),
                new SqlParameter("name", Name),
                new SqlParameter("spent", Spent),
                new SqlParameter("target", Target));
        }
        /// <summary>
        /// Edit a Budget Item
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="BudgetId"></param>
        /// <param name="Name"></param>
        /// <param name="Spent"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        public int EditBudgetItem(int Id, string Name, decimal Spent, decimal Target)
        {
            return Database.ExecuteSqlCommand("EditBudgetItem @id, @name, @spent, @target",
                new SqlParameter("id", Id),
                new SqlParameter("name", Name),
                new SqlParameter("spent", Spent),
                new SqlParameter("target", Target));
        }
        /// <summary>
        /// Edit Bank Account
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserId"></param>
        /// <param name="Name"></param>
        /// <param name="Balance"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public int EditBankAccount(int Id, string UserId, string Name, decimal Balance, AccountType Type)
        {
            return Database.ExecuteSqlCommand("EditBankAccount @id, @name, @balance, @type, @userId",
                new SqlParameter("id", Id),
                new SqlParameter("name", Name),
                new SqlParameter("balance", Balance),
                new SqlParameter("type", Type),
                new SqlParameter("userId", UserId));
        }
        /// <summary>
        /// Calculate Transaction
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int CalculateTransaction(int Id)
        {
            return Database.ExecuteSqlCommand("CalculateTransaction @id",
                new SqlParameter("id", Id));
        }
        /// <summary>
        /// Delete Budget
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteBudget(int Id)
        {
            return Database.ExecuteSqlCommand("DeleteBudget @id",
                new SqlParameter("id", Id));
        }
        /// <summary>
        /// Delete Budget Item
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteBudgetItem(int Id)
        {
            return Database.ExecuteSqlCommand("DeleteBudgetItem @id",
                new SqlParameter("id", Id));
        }
        /// <summary>
        /// Delete Bank Account
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteBankAccount(int Id)
        {
            return Database.ExecuteSqlCommand("DeleteBankAccount @id",
                new SqlParameter("id", Id));
        }
        /// <summary>
        /// Delete Transaction
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteTransaction(int Id)
        {
            return Database.ExecuteSqlCommand("DeleteTransaction @id",
                new SqlParameter("id", Id));
        }



        /*/// <summary>
        /// Delete Household
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteHousehold(int Id)
        {
            return Database.ExecuteSqlCommand("DeleteHousehold @id",
                new SqlParameter("id", Id));
        }*/



    }
}
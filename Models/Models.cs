using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetTrackerAPI.Models
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Household Id
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// Income Amount
        /// </summary>
        public decimal IncomeAmount { get; set; }
        /// <summary>
        /// Income Type
        /// </summary>
        public IncomeType IncomeType { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

    }
    /// <summary>
    /// IncomeType
    /// </summary>
    public enum IncomeType
    {
        Hourly,
        Daily,
        Weekly,
        BiWeekly,
        SemiMonthly,
        Monthly,
        Annually
    }
    /// <summary>
    /// Budget Model
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// Budget Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Budget Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// How much has been spent
        /// </summary>
        public decimal Spent { get; set; }
        /// <summary>
        /// The desired target
        /// </summary>
        public decimal Target { get; set; }
        /// <summary>
        /// Household Id
        /// </summary>
        public int HouseholdId { get; set; }
    }
    /// <summary>
    /// Budget Item Model
    /// </summary>
    public class BudgetItem
    {
        /// <summary>
        /// Budget Item Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Budget Item Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// How much has been spent on this Item
        /// </summary>
        public decimal Spent { get; set; }
        /// <summary>
        /// The desired target
        /// </summary>
        public decimal Target { get; set; }
        /// <summary>
        /// Budget Id
        /// </summary>
        public int BudgetId { get; set; }

        /// <summary>
        /// The percentage of how much has been spent
        /// </summary>
        [NotMapped]
        public double Percentage
        {
            get
            {
                var target = Decimal.ToDouble(Target);
                var spent = Decimal.ToDouble(Spent);

                if (Target == 0)
                {
                    return 0;
                }
                else
                {
                    return Math.Round(spent / target * 100);
                }
            }
        }
    }
    /// <summary>
    /// Household Model
    /// </summary>
    public class Household
    {
        /// <summary>
        /// Household Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///  Household Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// How much money is left for the Household to spend
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// How much money the group started with
        /// </summary>
        public decimal StartAmount { get; set; }
        /// <summary>
        /// How much money the group has spent
        /// </summary>
        [NotMapped]
        public decimal Spent
        {
            get
            {
                return StartAmount - Balance;
            }
        }
    }
    /// <summary>
    /// Transaction Model
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Transaction Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Transaction Amount
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Transaction Memo
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// When the transaction was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The type of the transaction
        /// </summary>
        [EnumDataType(typeof(TransactionType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }
        /// <summary>
        /// The transaction creators Id
        /// </summary>
        public string CreatorId { get; set; }
        /// <summary>
        /// Household Id
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// Budget Id
        /// </summary>
        public int? BudgetId { get; set; }
        /// <summary>
        /// Budget Item Id
        /// </summary>
        public int? BudgetItemId { get; set; }
        /// <summary>
        /// Bank Account Id
        /// </summary>
        public int BankAccountId { get; set; }
    }
    /// <summary>
    /// Transaction Type Enum
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Deposit
        /// </summary>
        Deposit,
        /// <summary>
        /// Withdrawal
        /// </summary>
        Withdrawal
    }
    /// <summary>
    /// Bank Account Model
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Bank Account Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Bank Account Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// How much money is left in the account
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// Bank Account Type
        /// </summary>
        [EnumDataType(typeof(AccountType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountType Type { get; set; }
        /// <summary>
        /// Who owns the bank account
        /// </summary>
        public string UserId { get; set; }
    }
    /// <summary>
    /// Bank Account Type Enum
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// Checking
        /// </summary>
        Checking,
        /// <summary>
        /// Savings
        /// </summary>
        Savings
    }
}
namespace InterAPI.Model
{
    public class AccountDetail
    {
        public DateTime MaturityDate { get; set; }
        public decimal AvailableBalanceWithCredit { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal BlockageAmount { get; set; }
        public decimal AmountOfBalance { get; set; }
        public decimal QueryInitialBalance { get; set; }
        public decimal QueryFinishBalance { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime AccountOpenningDate { get; set; }
        public int AccountNumber { get; set; }
        public string AccountBranchName { get; set; }
        public int AccountBranchCode { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public int AccountSuffix { get; set; }
        public string IBANNumber { get; set; }
        public string AccountCurrencyCode { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}

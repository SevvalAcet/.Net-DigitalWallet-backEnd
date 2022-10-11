namespace InterAPI.Model
{
    public class Transaction
    {
        public DateTime Valor { get; set; }
        public string ReceiptNumber { get; set; }
        public string DestinationAccount { get; set; }
        public string DestinationAccountIdendityNumber { get; set; }
        public string DestinationAccountTitle { get; set; }
        public string ReferecenceNumber { get; set; }
        public string TransactionName { get; set; }
        public string TransactionDetail1 { get; set; }
        public string TransactionDetail2 { get; set; }
        public string TransactionDetail3 { get; set; }
        public string TransactionDetail4 { get; set; }
        public string TransactionDetail5 { get; set; }
        public string BankDescription { get; set; }
        public string TransactionCode { get; set; }
        public string SubTransactionCode { get; set; }
        public string Description { get; set; }
        public string Channel { get; set; }
        public decimal BalanceBeforeTransaction { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public decimal Amount { get; set; }
        public int OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public int CustomerNo { get; set; }
        public string IslemDurumu { get; set; }
        public string DebitCreditType { get; set; }
    }
}

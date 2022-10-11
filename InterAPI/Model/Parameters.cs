namespace InterAPI.Model
{
    public class Parameters
    {
        public int CustomerNo { get; set; }
        public string AssociationCode { get; set; }
        public string IBANNumber { get; set; }
        public DateTime QueryDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AccountSuffix { get; set; }
        public int AccountBranchCode { get; set; }
        public string Explanation { get; set; }
        public int DestinationBankCode { get; set; }
        public decimal Amount { get; set; }
        public Account SourceAccount { get; set; }
        public string ReceiverName { get; set; }
        public bool ForceDuplicate { get; set; }
        public string TransferReferenceId { get; set; }
    }
}

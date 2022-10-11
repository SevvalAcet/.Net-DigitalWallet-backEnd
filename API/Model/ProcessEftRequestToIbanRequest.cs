namespace API.Model
{
    public class ServiceProcessEftRequestToIbanRequest
    {
        public string Explanation { get; set; }
        public string Iban { get; set; }
        public string ReceiverName { get; set; }
        public decimal Amount { get; set; }
        public string AccountNumber { get; set; }
    }
}

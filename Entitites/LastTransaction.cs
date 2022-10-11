namespace Entities
{
    public class LastTransaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Iban { get; set; }
        public DateTime? DateTime { get; set; }
    }
}

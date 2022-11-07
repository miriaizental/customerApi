namespace customersApi.Models
{
    public class Customer
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? idNumber { get; set; }
        public Address? Address { get; set; }
        public List<Contract> ? contractList {get; set;}
    }
}

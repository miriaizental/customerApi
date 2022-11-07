namespace customersApi.Models
{
    public class Contract
    {
        public string? contractId { get; set; }
        public string? contractName { get; set; }
        public List<Package> ? packagesList {get; set;} 
    }
}

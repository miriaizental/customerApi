namespace customersApi.Models
{
    public class Package
    {
        public PackageType packageType { get; set; }
        public string? packageName { get; set; }
        public int packageQuantity { get; set; }
        public int packageBalance { get; set; }
    }
}

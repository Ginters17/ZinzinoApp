namespace MyApp.Models.DomainModels
{
    public class Address
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public string AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}

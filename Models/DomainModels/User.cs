namespace MyApp.Models.DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public string Username { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}

namespace TechnicalService.Models
{
    public class ClientPerson
    {
        public int ClientId { get; set; }
        public int PersonId { get; set; }
        public int CityId { get; set; }
        public int GenderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdentificationCard { get; set; } = string.Empty;
        public string RUC { get; set; } = string.Empty;
        public string GenderName { get; set; } = string.Empty;
        public string CellPhone { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Hobby { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string State { get; set; } = "A";
    }
}

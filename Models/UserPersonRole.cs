namespace TechnicalService.Models
{
    public class UserPersonRole
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public int PersonId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string IdentificationCard { get; set; } = string.Empty;

        public string CellPhone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;

    }
}

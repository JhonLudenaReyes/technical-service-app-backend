using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnicalService.Models
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; } = string.Empty;

        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string State { get; set; } = "A";

        [ForeignKey("Fk_Role")]
        public int RoleId { get; set; }

        [JsonIgnore]
        public Role? Fk_Role { get; set; }

        [ForeignKey("FK_Person")]
        public int PersonId { get; set; }

        [JsonIgnore]
        public Person? FK_Person { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnicalService.Models
{
    [Table("Profiles")]
    public class Profile
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileId { get; set; }

        [ForeignKey("Fk_Permission")]
        public int PermissionId { get; set; }

        [JsonIgnore]
        public Permission? Fk_Permission { get; set; }

        [ForeignKey("Fk_Role")]
        public int RoleId { get; set; }

        [JsonIgnore]
        public Role? Fk_Role { get; set; }

        [Required]
        [StringLength(1)]
        public string State { get; set; } = "A";
    }
}

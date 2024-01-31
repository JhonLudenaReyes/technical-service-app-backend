using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalService.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleName { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string State { get; set; } = "A";

        //public List<Permission> Permissions { get; } = new();
        
    }
}

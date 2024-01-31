using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalService.Models
{
    [Table("Permissions")]
    public class Permission
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }

        [Required]
        [StringLength(30)]
        public string PermissionName { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string State { get; set; } = "A";

    }
}

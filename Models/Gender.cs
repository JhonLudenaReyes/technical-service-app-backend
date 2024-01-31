using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalService.Models
{
    [Table("Genders")]
    public class Gender
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenderId { get; set; }

        [Required]
        [StringLength(50)]
        public string GenderName { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string State { get; set;} = "A";
    }
}

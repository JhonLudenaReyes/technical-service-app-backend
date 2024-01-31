using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnicalService.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        public string RUC { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [StringLength(50)]
        public string Hobby { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string State { get; set; } = "A";

        [ForeignKey("FK_Person")]
        public int PersonId { get; set; }

        [JsonIgnore]
        public Person? FK_Person { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnicalService.Models
{
    [Table("People")]
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string IdentificationCard { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string CellPhone { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string State { get; set; } = "A";

        [ForeignKey("Fk_City")]
        public int CityId { get; set; }

        [JsonIgnore]
        public City? Fk_City { get; set; }

        [ForeignKey("Fk_Gender")]
        public int GenderId { get; set; }

        [JsonIgnore]
        public Gender? Fk_Gender { get; set; }


    }
}

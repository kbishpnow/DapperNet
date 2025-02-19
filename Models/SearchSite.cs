using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperNet.Models
{
    [Table("Sites")]
    public class SearchSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Domain { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public virtual ICollection<SearchPage> Pages { get; set; } = [];
    }
}
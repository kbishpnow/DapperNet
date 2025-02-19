using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperNet.Models
{
    [Table("ScrapedPages")]
    public class SearchPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public required string Url { get; set; }

        [MaxLength(255)]
        public required string Title { get; set; }

        [MaxLength(500)]
        public string? MetaDescription { get; set; }

        [MaxLength(1000)]
        public string? Keywords { get; set; }

        public required string Content { get; set; }

        public DateTime DateScraped { get; set; } = DateTime.UtcNow;

        public int HttpStatusCode { get; set; }

        [ForeignKey("Site")]
        public int SiteId { get; set; }
        public virtual required SearchSite Site { get; set; }
    }
}

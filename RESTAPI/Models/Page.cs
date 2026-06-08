using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.Models
{
    [Table("pages")]
    public class Page
    {
        [Key]
        public int Id { get; set; }

        public string? PageDescription { get; set; }

        public string? PageTitle { get; set; }

        public Guid userid { get; set; }

        public Location? location { get; set; }
        public int? imageid { get; set; }

        public Image? images { get; set; }
        [ForeignKey(nameof(userid))]
        public User? User { get; set; }
        public ICollection<PageGenre>? PageGenre { get; set; }

    }
}
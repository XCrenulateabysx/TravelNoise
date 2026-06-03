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

        public int genreid { get; set; }

        [ForeignKey(nameof(userid))]
        public User? User { get; set; }

        [ForeignKey(nameof(genreid))]
        public Genre? Genre { get; set; }
    }
}
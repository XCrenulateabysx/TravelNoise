using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string RegionName { get; set; }
        [Required]
        public string RegionDescription { get; set; }
        public string? buttonX { get; set; }
        public string? buttonY { get; set; }
        public int? pageid { get; set; }

        public int? genreid { get; set; }
        [ForeignKey(nameof(pageid))]
        public Page? Page { get; set; }

        [ForeignKey(nameof(genreid))]
        public Genre? Genre { get; set; }
    }
}
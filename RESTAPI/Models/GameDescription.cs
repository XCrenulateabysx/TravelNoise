using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.Models
{
    [Table("gamedescription")]
    public class GameDescription
    {
        [Key]
        public int id { get; set; }

        public int genreid { get; set; }

        [ForeignKey(nameof(genreid))]
        public Genre? Genre { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RESTAPI.Models
{
    [Table("genre")]
    public class Genre
    {
        [Key]
        public int id { get; set; }

        public string? genrename { get; set; }

        public ICollection<Page>? Pages { get; set; }
    }
}
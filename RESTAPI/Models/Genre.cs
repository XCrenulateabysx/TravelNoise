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
        public string? genreTitle { get; set;  }
        public string? genreDescription { get; set;  }
        public ICollection<PageGenre>? PageGenre{  get; set; }
        public ICollection<TheoryPages>? theoryPages { get; set; }

    }
}
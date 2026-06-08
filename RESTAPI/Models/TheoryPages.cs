using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RESTAPI.Models
{
    public class TheoryPages
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public int? genreId { get; set; }
        public Genre? genre { get; set; }
        public int? imageid { get; set; }
        public Image? images { get; set; }


    }
}

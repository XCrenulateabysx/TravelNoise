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
        public int? imageid { get; set; }
        public Image? images { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace RESTAPI.Models
{
    public class PageGenre
    {
        public int PageId { get; set; }
        public int GenreId { get; set; }
        public Page? Page { get; set; }
        public Genre? Genre { get; set; }
    }
}

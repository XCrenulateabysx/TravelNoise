using System.ComponentModel.DataAnnotations;

namespace RESTAPI.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageURL { get; set; }

        public ICollection<Page>? pages { get; set; }
        public ICollection<Location>? locations { get; set; }
        public ICollection<TheoryPages>? theorypages { get; set; }
    }
}

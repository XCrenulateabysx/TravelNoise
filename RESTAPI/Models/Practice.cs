using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.Models
{
    [Table("practice")]
    public class Practice
    {
        [Key]
        public int id { get; set; }

        public int practicetype { get; set; }

        public int pageid { get; set; }

        [ForeignKey(nameof(pageid))]
        public Page? Page { get; set; }
    }
}
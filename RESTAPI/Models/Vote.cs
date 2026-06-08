using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.Models
{
    [Table("vote")]
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public int pageid { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [ForeignKey(nameof(pageid))]
        public Page? Page { get; set; }
    }
}
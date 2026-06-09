using System.ComponentModel.DataAnnotations;

namespace RESTAPI.Models
{
    public class MusicExercise
    {
        [Key]
        public int id { get; set; }
        public string type { get; set;  }
        public string? question { get; set; }
        public string? videoUrl { get; set; }
        public ICollection<MusicExerciseOptions> options { get; set; }
    }
}

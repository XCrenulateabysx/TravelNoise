using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.Models
{
    public class MusicExerciseOptions
    {
        [Key]
        public int id { get; set; }
        public string? Text { get; set; }
        public bool IsCorrect { get; set; }
        public int MusicExerciseId { get; set; }
        public MusicExercise? MusicExercise { get; set; }
        public ICollection<Image>? images { get; set; }

    }
}

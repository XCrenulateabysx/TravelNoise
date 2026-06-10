using System.ComponentModel.DataAnnotations;

namespace RESTAPI.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageURL { get; set; }
        //public int musicOptionsId { get; set; }
        //public MusicExerciseOptions Options { get; set; }
        public int? pagesId { get; set; }
        public Page? pages { get; set; }
        public int? locationsId { get; set; }
        public Location? locations { get; set; }
        public int? theorypagesId { get; set; }
        public TheoryPages? theorypages { get; set; }
        public int? musicExerciseOptionsId { get; set; }
        public MusicExerciseOptions? musicExerciseOptions { get; set; }
    }
}

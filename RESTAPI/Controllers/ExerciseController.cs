using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly RESTAPIContext _context;

        public ExerciseController(RESTAPIContext context)
        {
            _context = context;
        }

        [HttpGet("GetMusicExercise")]
        public async Task<ActionResult<MusicExercise>> GetExercise()
        {
            var exercise = await _context.MusicExercises.FirstOrDefaultAsync();
            return Ok(exercise);
        }


        [HttpGet("GetMusicExerciseOptions")]
        public async Task<ActionResult<MusicExercise>> GetExerciseOptions()
        {
            var exercise = await _context.MusicExerciseOptions.Include(mep => mep.images).FirstOrDefaultAsync();
            return Ok(exercise);
        }

        [HttpGet("GetMusicExercise/{id}")]
        public async Task<ActionResult<IEnumerable<MusicExercise>>> GetMusicExercise(int id)
        {
            var exercise = await _context.MusicExercises.Where(me => me.id == id).Include(mep => mep.options).ThenInclude(mep => mep.images).FirstOrDefaultAsync();
            return Ok(exercise);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly RESTAPIContext _context;

        public PageController(RESTAPIContext context)
        {
            _context = context;
        }

        [HttpGet("GetPage/{id}")]
        public async Task<ActionResult<Page>> GetPage(int id)
        {
            var PageInfo = await _context.Pages.Include(p => p.images).FirstOrDefaultAsync(p => p.Id== id);
            return Ok(PageInfo);
        }

        [HttpGet("GetGenre/{id}")]
        public async Task<ActionResult<IEnumerable<PageGenre>>> GetGenre(int id)
        {
            var PageGenres = await _context.PageGenres.Where(pg => pg.PageId == id).Include(pg => pg.Genre).ToListAsync();
            return Ok(PageGenres);
        }

    }
}

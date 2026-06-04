using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPI.Models;
using System.Data.Entity;

namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly RESTAPIContext _context;

        public HomeController(RESTAPIContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAll()
        {
            var TheoryPages = await _context.Locations.ToListAsync();
            return Ok(TheoryPages);
        }
    }
}

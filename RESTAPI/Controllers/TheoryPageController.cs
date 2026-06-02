using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    [Route("api/Theory")]
    [ApiController]
    public class TheoryPageController : ControllerBase
    {
        private readonly RESTAPIContext _context;

        public TheoryPageController(RESTAPIContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheoryPages>>> Get()
        {
            var TheoryPages = await _context.theorypages.ToListAsync();
            Console.WriteLine("Poooop");
            return Ok(TheoryPages);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

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

        [HttpGet("GetRegions")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllRegionNames()
        {
            var LocationNames = await _context.Locations.Select(l => new 
            {
                l.id,
                l.buttonX,
                l.buttonY,
                l.RegionName,
                l.RegionDescription,
                l.Page
                
            }).ToListAsync();

            return Ok(LocationNames);
        }


    }
}

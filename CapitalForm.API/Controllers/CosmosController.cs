using CapitalForm.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalForm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosmosController : ControllerBase
    {
        private readonly ProgramContext _context;
        private static bool _ensureCreated { get; set; } = false;

        public CosmosController(ProgramContext context)
        {
            _context = context;

            if (!_ensureCreated)
            {
                _context.Database.EnsureCreated();
                _ensureCreated = true;
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Works");
        }
    }
}

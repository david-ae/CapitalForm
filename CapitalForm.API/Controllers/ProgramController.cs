using CapitalForm.Core.DTO;
using CapitalForm.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalForm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet]
        public string Get() 
        {
            return "API Hit";
        }

        [HttpPut("application/{applicationId}")]
        public IActionResult EditApplication([FromRoute] string applicationId, [FromBody] EditApplicationRequestDto programApplication)
        {
            return Ok(applicationId + " " + programApplication.ProgramDescription);
        }
        
        [HttpPost]
        public async Task<ActionResult<ProgramApplicationResponse>> CreateApplication([FromBody] CreateApplicationRequestDto programApplication)
        {
            return Ok(await _programService.CreateApplication(programApplication));
        }
    }
}

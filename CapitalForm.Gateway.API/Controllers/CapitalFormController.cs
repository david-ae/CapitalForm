using CapitalForm.Gateway.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalForm.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapitalFormController : ControllerBase
    {
        private readonly ICapitalFormService _capitalFormService;

        public CapitalFormController(ICapitalFormService capitalFormService)
        {
            _capitalFormService = capitalFormService;
        }

        [HttpGet("editProgramApplication/{applicationId}")]
        public async Task<IActionResult> EditProgramApplication(string applicationId)
        {
            return await _capitalFormService.EditApplication(applicationId);
        }
    }
}

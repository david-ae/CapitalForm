using CapitalForm.Core.DTO;
using CapitalForm.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace CapitalForm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly IQuestionTypeService _questionTypeService;

        public QuestionTypeController(IQuestionTypeService questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateQuestionType([FromBody] CreateQuestionTypeDto questionType)
        {
           return Ok( await _questionTypeService.Add(questionType));
        }

        [HttpGet("Questions/{Id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<QuestionTypeResponse>> GetQuestion([FromRoute] Guid Id)
        {
            return Ok(await _questionTypeService.GetQuestion(Id));
        }
    }
}

using CapitalForm.Gateway.Core.DTO;
using CapitalForm.Gateway.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalForm.Gateway.API.Controllers
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

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionTypeResponse>> GetQuestionType(Guid id)
        {
            return await _questionTypeService.GetQuestion(id);
        }
    }
}

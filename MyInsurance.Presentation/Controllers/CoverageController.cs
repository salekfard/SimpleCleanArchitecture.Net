using Microsoft.AspNetCore.Mvc;
using MyInsurance.Application.Interfaces;
using MyInsurance.Application.Models;
using MyInsurance.Application.Models.DTOs;
using MyInsurance.Domain.Entities;
using MyInsurance.Domain.Resources;
using MyInsurance.Presentation.Models;

namespace MyInsurance.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoverageController : ControllerBase
    {
        private readonly ICoverageService _coverageService;

        public CoverageController(ICoverageService coverageService)
        {
            _coverageService = coverageService;
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponseModel<bool>>> Post([FromBody] CreateRequestDTO model)
        {
            await _coverageService.CreateRequestAsync(model);
            return Ok(new GeneralResponseModel<bool>(true,true,Messages.RequestRegistred));
        }

        [HttpGet("userId")]
        public async Task<ActionResult<GeneralResponseModel<ResponseRequestDTO>>> Get(long userId)
        {
            if (await _coverageService.GetAllRequestsAsync(userId) is var result && result != null)
            {
                return Ok(new GeneralResponseModel<ResponseRequestDTO>(result,true));
            }

            return NotFound();
        }
    }
}

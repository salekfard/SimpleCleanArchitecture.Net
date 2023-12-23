using Microsoft.AspNetCore.Mvc;
using MyInsurance.Application.Interfaces;
using MyInsurance.Application.Models;
using MyInsurance.Application.Models.DTOs;
using MyInsurance.Domain.Entities;

namespace MyInsurance.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<GeneralResponseModel<Users>>> PostCreateUser([FromBody] CreateUserDTO model)
        {
            return Ok(new GeneralResponseModel<Users>(await _userService.CreateUserAsync(model),true));
        }

        //NationalCode is an important data (PostMethod)
        [HttpPost("GetUser")]
        public async Task<ActionResult<GeneralResponseModel<Users>>> PostGetUser([FromBody] GetUserDTO model)
        {
            //;D
            /*if (await _userService.GetUsersAsync(model) is var user && user != null)
            {
                return Ok(new GeneralResponseModel<Users>(user, true));
            }
            return NotFound();*/
            return Ok(new GeneralResponseModel<Users>(await _userService.GetUsersAsync(model), true));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netflix.Core.Dtos;
using netflix.Service.Abstract;

namespace netflix.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var result = await _userService.Login(userLoginDto);
            return !result.Succeeded ? BadRequest(result.ErrorDefination) : Ok(result.Data);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var result = await _userService.Register(userRegisterDto);
            return !result.Succeeded ? BadRequest(result.ErrorDefination) : Ok(result.Data);
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        //{
        //    var result = await _credentialService.Authenticate(userLoginDto.UserName, userLoginDto.Password);
        //    return !result.Succeeded ? BadRequest(result.ErrorDefination) : Ok(result.Data);
        //}


        [HttpPost("Interest")]
        public async Task<IActionResult> Interest(UserInterestDto userInterestDto)
        {
            var result = await _userService.Interest(userInterestDto);
            return !result.Succeeded ? BadRequest(result.ErrorDefination) : Ok(result.Data);
        }


        [HttpPost("Watch")]
        public async Task<IActionResult> Watch(WatchAddDto watchDto)
        {
            var result = await _userService.Watch(watchDto);
            return !result.Succeeded ? BadRequest(result.ErrorDefination) : Ok(result.Data);
        }

        [HttpGet("Program")]
        public async Task<IActionResult> Programs()
        {
            var result = await _userService.Program();
            return !result.Succeeded ? BadRequest(result.ErrorDefination) : Ok(result.Data);
        }
    }
}

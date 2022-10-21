using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Dto;
using Sat.Recruitment.Api.Interfaces;
using Sat.Recruitment.Api.Services;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<UserResponseDto> CreateUser([FromBody] UserRequestDto user)
        {
            try
            {
                var objResponse = await _userService.CreateUser(user);

                return objResponse;
            }
            catch (Exception ex)
            {
                return new UserResponseDto()
                {
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }
        }        
    }
}

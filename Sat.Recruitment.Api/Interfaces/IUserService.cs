using Sat.Recruitment.Api.Dto;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Interfaces;

public interface IUserService
{
    Task<UserResponseDto> CreateUser(UserRequestDto user);
}

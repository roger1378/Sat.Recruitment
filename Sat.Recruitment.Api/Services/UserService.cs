using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Dto;
using Sat.Recruitment.Api.Interfaces;
using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.Util;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services;

public class UserService: IUserService
{
    public async Task<UserResponseDto> CreateUser(UserRequestDto user)
    {
        try 
        {
            var errors = Error.ValidateErrors(user);

            if (errors != string.Empty)
                return new UserResponseDto()
                {
                    IsSuccess = false,
                    Errors = errors
                };

            var newUser = new User()
            {
                Name = user.Name,
                Email = Email.NormalizeEmail(user.Email),
                Address = user.Address,
                Phone = user.Phone,
                UserType = user.UserType,
                Money = user.Money
            };

            switch (newUser.UserType)
            {
                case "Normal":
                    newUser.Money = newUser.Money + (user.Money * Convert.ToDecimal(0.12));
                    if (newUser.Money < 100)
                        newUser.Money = newUser.Money + (user.Money * Convert.ToDecimal(0.8));
                    break;

                case "SuperUser":
                    if (newUser.Money > 100)
                        newUser.Money = newUser.Money + (newUser.Money * Convert.ToDecimal(0.20));
                    break;

                case "Premium":
                    if (newUser.Money > 100)
                        newUser.Money = newUser.Money + (newUser.Money * 2);
                    break;
            }

            UserData userData = new();
            var listUsers = userData.GetUsersFromFile();

            userData.User = newUser;
            var response = await userData.Insert(listUsers);
            if (response == -1)
            {
                return new UserResponseDto()
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                };
            }

            return new UserResponseDto()
            {
                IsSuccess = true,
                Errors = "User Created"
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

using Sat.Recruitment.Api.Dto;
using Sat.Recruitment.Api.Model;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Util;

public static class UserValidation
{
    public static bool VerifyUserExistence(User newUser, List<User> oldUsers) 
    {
        bool response = false;

        foreach (User oldUser in oldUsers)
        {
            if ((oldUser.Name == newUser.Name) && (oldUser.Email == newUser.Email) && (oldUser.Address == newUser.Address) && 
                (oldUser.Phone == newUser.Phone) &&(oldUser.UserType == newUser.UserType))
                response = true;
        }

        return response;
    }
}

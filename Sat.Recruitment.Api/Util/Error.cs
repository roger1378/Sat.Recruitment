using Sat.Recruitment.Api.Dto;

namespace Sat.Recruitment.Api.Util;

public static class Error
{
    //Validate errors
    public static string ValidateErrors(UserRequestDto user)
    {
        string errors = string.Empty;

        if (user.Name == null || user.Name == string.Empty)
            //Validate if Name is null
            errors = "The name is required";
        if (user.Email == null || user.Email == string.Empty)
            //Validate if Email is null
            errors = errors + " The email is required";
        if (user.Address == null || user.Address == string.Empty)
            //Validate if Address is null
            errors = errors + " The address is required";
        if (user.Phone == null || user.Phone == string.Empty)
            //Validate if Phone is null
            errors = errors + " The phone is required";
        if (user.UserType == null || user.UserType == string.Empty)
            //Validate if Phone is null
            errors = errors + " The user type is required";

        return errors;
    }
}

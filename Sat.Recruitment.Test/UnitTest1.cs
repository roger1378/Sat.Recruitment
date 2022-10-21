using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Dto;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var userController = new UsersController();

            var result = await userController.CreateUser(new UserRequestDto {
                Name = "Mike", 
                Email = "mike@gmail.com", 
                Address = "Av. Juan G", 
                Phone = "+349 1122354215", 
                UserType = "Normal", 
                Money = decimal.Parse("124")
            });


            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public async void Test2()
        {
            var userController = new UsersController();

            var result = await userController.CreateUser(new UserRequestDto {
                Name = "Agustina", 
                Email = "Agustina@gmail.com", 
                Address = "Av. Juan G", 
                Phone = "+349 1122354215", 
                UserType = "Normal", 
                Money = decimal.Parse("124")
            });

            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }
    }
}

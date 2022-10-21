using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.Util;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Data;

public class UserData
{
    public User User { get; set; }

    public List<User> GetUsersFromFile()
    {
        List<User> users = new();

        var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

        using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (var streamReader = new StreamReader(fileStream))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLineAsync().Result;
                    users.Add(new User()
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString())
                    });
                }
            }
        }

        return users;
    }

    public async Task<long> Insert(List<User> listUsers)
    {
        var existsUser = UserValidation.VerifyUserExistence(this.User, listUsers);
        if (existsUser)
            return -1;

        var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

        using (StreamWriter sw = new StreamWriter(path, true))
        {
            await sw.WriteLineAsync($"{User.Name},{User.Email},{User.Phone},{User.Address},{User.UserType},{User.Money}");
        }
        
        return 0;
    }
}

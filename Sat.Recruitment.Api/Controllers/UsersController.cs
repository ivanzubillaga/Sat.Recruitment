using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly List<User> _users = new List<User>();

        public UsersController()
        {
        }

        [HttpPost]
        [Route("/create-user")]

        public async Task<Result> CreateUser(UserRequest RequestData)
        {

            if (string.IsNullOrEmpty(RequestData.money))
            { RequestData.money = "0"; }

            var ext = new Ext();
            Models.UserTypes RequestDataType = ext.crearUserType(RequestData.userType);

            var newUser = new User
            {
                Name = RequestData.name,
                Email = RequestData.email,
                Address = RequestData.address,
                Phone = RequestData.phone,
                UserType = RequestDataType,
                Money = ext.userTypesPercentage(RequestDataType, decimal.Parse(RequestData.money))

            };

            //Normalize email
            newUser.Email = ext.normalizeEmail(newUser.Email);

            // Read user from File
            var reader = ReadUsersFromFile();

            //Reader     
            try
            {
                if (reader != null)
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLineAsync().Result;
                        var user = new User
                        {
                            Name = line.Split(',')[0].ToString(),
                            Email = line.Split(',')[1].ToString(),
                            Phone = line.Split(',')[2].ToString(),
                            Address = line.Split(',')[3].ToString(),
                            UserType = ext.crearUserType(line.Split(',')[4].ToString()),
                            Money = decimal.Parse(line.Split(',')[5].ToString()),
                        };
                        _users.Add(user);
                    }
                    reader.Close();
                }
                else
                {
                    throw new Exception("Database Error");
                }

                bool isDuplicated = false;
                foreach (User user in _users)
                {
                    if (ext.StringCompare(user.Phone, newUser.Phone)
                     || ext.StringCompare(user.Email, newUser.Email)
                     || ext.StringCompare(user.Name, newUser.Name)
                     && ext.StringCompare(user.Address, newUser.Address))
                    {
                        isDuplicated = true;
                        throw new Exception("The user is duplicated");
                    }
                }

                if (!isDuplicated)
                {
                    StreamWriter create = CreateUsersFromFile(newUser);
                    if (create is null)
                    {
                        throw new Exception("error creating user");
                    }
                    else
                    {
                        Debug.WriteLine("User Created");

                        return new Result()
                        {
                            IsSuccess = true,
                            Errors = "User Created"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error when creating User: " + ex.Message);
                return new Result()
                {
                    IsSuccess = false,
                    Errors = ex.Message.ToString()
                };
            }
            throw new Exception("error creating user");
        }
    }
}

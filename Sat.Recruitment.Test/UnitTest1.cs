using System;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public void TestCreateUser()
        {
            var userController = new UsersController();

            var result = userController.CreateUser(
                new Api.Models.UserRequest()
                {
                    name = "Mike",
                    email = "mike@gmail.com",
                    address = "Av. Juan G",
                    phone = "+349 1122354215",
                    userType = "Normal",
                    money = "124"
                }

                ).Result;


            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void TestUserDuplicated()
        {
            var userController = new UsersController();

            var result = userController.CreateUser(new Api.Models.UserRequest()
            {
                name = "Agustina",
                email = "Agustina@gmail.com",
                address = "Av. Juan G",
                phone = "+349 1122354215",
                userType = "Normal",
                money = "124"
            }

                ).Result;
            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }
    }
}

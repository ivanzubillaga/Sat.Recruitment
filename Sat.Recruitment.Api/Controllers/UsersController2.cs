using System;
using System.IO;
using Sat.Recruitment.Api.Models;
namespace Sat.Recruitment.Api.Controllers
{
    public partial class UsersController
    {
        string path = Directory.GetCurrentDirectory() + "\\Files\\Users.txt";
        private StreamReader ReadUsersFromFile()
        {

            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(fileStream);

                return reader;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private StreamWriter CreateUsersFromFile(User newUser)
        {
            try
            {
                StreamWriter writer = new StreamWriter(path, append: true);

                writer.WriteLine(newUser.Name + "," + newUser.Email + "," + newUser.Phone + "," + newUser.Address + "," + newUser.UserType + "," + newUser.Money);
                writer.Close();

                return writer;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}


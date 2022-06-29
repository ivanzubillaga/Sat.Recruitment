using System;

namespace Sat.Recruitment.Api.Controllers
{
    public class Ext
    {

        public string normalizeEmail(string email)
        {

            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            email = string.Join("@", new string[] { aux[0], aux[1]

            });
            return email;

        }

        public Models.UserTypes crearUserType(string userType)
        {
            Models.UserTypes type;
            switch (userType)
            {
                case "Normal":
                    type = new Models.NormalUser();
                    break;

                case "SuperUser":
                    type = new Models.SuperUser();
                    break;

                case "Premium":
                    type = new Models.PremiumUser();

                    break;
                default:
                    type = new Models.NormalUser();
                    break;

            }

            return type;
        }

        public decimal userTypesPercentage(Models.UserTypes userType, decimal money)
        {

            decimal percentage = 0;
            percentage = userType.calcular(money);

            decimal gif = money * percentage;
            money = money + gif;
            return money;
        }

        public bool StringCompare(string firstString, string secondString)
        {
            if (firstString.Trim().ToLower() == secondString.Trim().ToLower()) { return true; }

            else return false;

        }
    }
}

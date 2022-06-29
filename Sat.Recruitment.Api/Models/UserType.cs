using System;
namespace Sat.Recruitment.Api.Models
{
    public abstract class UserTypes
    {
        public abstract decimal calcular(decimal money);

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class NormalUser : UserTypes
    {
        public override decimal calcular(decimal money)
        {
            //If new user is normal and has more than USD100
            decimal percentage = 0;
            if (money > 100)
            {
                percentage = Convert.ToDecimal(0.12);

            }
            if (money < 100 && money > 10)
            {
                percentage = Convert.ToDecimal(0.8);
            }

            return percentage;
        }

        public override string ToString()
        {
            return "Normal";
        }
    }

    public class PremiumUser : UserTypes
    {
        public override decimal calcular(decimal money)
        {
            decimal percentage = 0;
            //If new user is Premium and has more than USD100
            if (money > 100)
            {
                percentage = 2;
            }

            return percentage;
        }
        public override string ToString()
        {
            return "Premium";
        }
    }

    public class SuperUser : UserTypes
    {
        public override decimal calcular(decimal money)
        {
            //If new user is normal and has more than USD100
            decimal percentage = 0;
            if (money > 100)
            {
                percentage = Convert.ToDecimal(0.20);
            }

            return percentage;
        }
        public override string ToString()
        {
            return "SuperUser";
        }
    }

}

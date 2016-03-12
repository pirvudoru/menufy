using System;
using MenufyServer.Data;

namespace MenufyServer.Services
{
    public class CalloryCalculator
    {
        public int GetYear(int year)
        {
            return DateTime.Now.Year + year;
        }
        public decimal CalculateNormalFor(ApplicationUser user)
        {
            decimal normalCallory;
            switch (user.Constitution)
            {
                case "slim":
                {
                    normalCallory = (decimal) ((Convert.ToInt32(user.Height) - 100 + GetYear(user.BirthDateYear) / 10) * 0.9 * 0.9);
                }
                    break;
                case "normal":
                {
                    normalCallory = (decimal) ((Convert.ToInt32(user.Height) - 100 + GetYear(user.BirthDateYear) / 10)*0.9);
                }
                    break;
                case "robust":
                {
                    normalCallory = (decimal) ((Convert.ToInt32(user.Height) - 100 + GetYear(user.BirthDateYear) / 10) * 0.9 * 1.1);
                }
                    break;
                default:
                {
                    normalCallory = 0;
                }
                    break;
            }
            return normalCallory;
        }

        public decimal CalculateRmb(ApplicationUser user)
        {
            decimal rmbValue;
            if (user.Gender == "male")
            {
                rmbValue =
                    (decimal)
                        (66 + (13.75 * Convert.ToInt32(user.Weight)) +
                          (5 * Convert.ToInt32(user.Height)) * (6.76 * GetYear(user.BirthDateYear)));
            }
            else
            {
                rmbValue =
                    (decimal)
                        (655 + (9.56 * Convert.ToInt32(user.Weight)) +
                          (1.55 * Convert.ToInt32(user.Height)) * (4.68 * GetYear(user.BirthDateYear)));

            }
            return rmbValue;
        }

        public decimal GetMultiplier(ApplicationUser user)
        {
            decimal multiplier;
            switch (user.Lifestyle)
            {
                case "sedentar":
                {
                    multiplier = 1.2m;
                }
                    break;
                case "low":
                {
                    multiplier = 1.35m;
                }
                    break;
                case "moderate":
                {
                    multiplier = 1.55m;
                }
                    break;
                case "high":
                {
                    multiplier = 1.75m;
                }
                    break;
                default:
                {
                    multiplier = 1;
                }
                    break;
            }
            return multiplier;
        }

        public decimal CalculateCurrentFor(ApplicationUser user)
        {
            return CalculateRmb(user) * GetMultiplier(user);
        }
    }
}
using System;

namespace BLRI.Common.Helper
{
    public static class DatetimeExtension
    {
        /// <summary>
        /// Birth season: System will generate automatically from date of birth
        /// (Formula: Summer = 16th February to 15th June, Rainy = 16th June to 15th October, Winter = 16th October to 15th February)
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        public static string GetBirthSession(this DateTime birthDate)
        {
            var session = string.Empty;

            if (birthDate != DateTime.MinValue)
            {
                bool isLeapYear = DateTime.IsLeapYear(birthDate.Year);

                int summerStart = 47;
                int summerEnd = isLeapYear ? 167 : 166;
                int rainyStart = summerEnd + 1;
                int rainyEnd = isLeapYear ? 289 : 288;
                int winterStart = rainyEnd + 1;
                int winterEnd = 46;



                int dayOfYear = birthDate.DayOfYear;

                if (dayOfYear >= summerStart && dayOfYear <= summerEnd)
                {
                    session = "Summer";
                }
                else if (dayOfYear >= rainyStart && dayOfYear <= rainyEnd)
                {
                    session = "Rainy";
                }
                else if (dayOfYear >= winterStart || dayOfYear <= winterEnd)
                {
                    session = "Winter";
                }
                else
                {
                    session = "Undefined";
                }
            }

            return session;
        }
    }
}

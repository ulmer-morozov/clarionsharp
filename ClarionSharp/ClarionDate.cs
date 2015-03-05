using System;

namespace ClarionSharp
{
    public static class ClarionDate
    {
        public static DateTime GetDateTime(int clarionDate)
        {
            var date = new DateTime(1800, 12, 28, 0, 0, 0);
            date = date.AddDays(clarionDate);
            return date;
        }
    }
}
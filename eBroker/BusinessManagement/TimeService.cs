using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement
{
    public class TimeService
    {
        private static List<DayOfWeek> days = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        public static bool IsTimeValidForEquityTrade()
        {
            bool flag = false;
            if(DateTime.Now.Hour >= 9 && DateTime.Now.Hour <= 15)
            {
                flag = true;
            }
            return flag;
        }

        public static bool IsDayValidForEquityTrade()
        {
            bool flag = false;
            if (days.Contains(DateTime.Now.DayOfWeek))
            {
                flag = true;
            }
            return flag;
        }
    }
}

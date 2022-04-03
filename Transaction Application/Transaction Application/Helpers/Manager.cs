using System;

namespace Transaction_Application.Helpers
{
    public class Manager : IManager
    {
        // Function to change the date format to MySql format
        public string ChangeDateFormatToSqlFormat(DateTime dateTime)
        {
            return dateTime.Year + "-" + dateTime.Month + "-" + dateTime.Day + " " + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
        }
    }
}

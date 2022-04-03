using System;

namespace Transaction_Application.Helpers
{
    public interface IManager
    {
        // Virtual function to change the date format to MySql format
        public string ChangeDateFormatToSqlFormat(DateTime dateTime);
    }
}

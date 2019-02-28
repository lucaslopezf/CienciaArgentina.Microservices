using System;

namespace CienciaArgentina.Microservices.Commons.Helpers.Date
{
    public static class DateTimeHelper
    {
        public static DateTime Now => DateTime.Now;

        public static int CurrentYear => DateTime.Now.Year;
    }
}

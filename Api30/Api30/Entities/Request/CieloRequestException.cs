using System;

namespace Api30.Entities.Request
{
    public class CieloRequestException : Exception
    {
        public CieloRequestException(string message, CieloError error) : base(message)
        {
            CieloError = error;
        }
        public CieloRequestException(string message, CieloError error, Exception ex = null) : base(message, ex)
        {
            CieloError = error;
        }

        public CieloError CieloError { get; set; }
    }
}
namespace Api30.Entities.Request
{
    public class CieloError
    {
        public CieloError(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
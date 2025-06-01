namespace WebAppDBMVC01.Exceptions
{
    public class InvalidArgumentException : AppException
    {
        private static readonly string DEFAULT_CODE = "InvalidArgument";
        public InvalidArgumentException(string message, string code)
            : base(code + DEFAULT_CODE, message)
        {
        }
        
    }
    
}

namespace WebAppDBMVC01.Exceptions
{
    public class ServerException : AppException
    {
        
        public ServerException(string message, string code)
            : base(code , message)
        {
        }
    
    }
}

namespace WebAppDBMVC01.Exceptions
{
    public abstract class AppException : Exception
    {
        public string Code { get; set; }

        protected AppException(string message, string code) : base(message)
        {
            Code = code;
        }
        
    }
}

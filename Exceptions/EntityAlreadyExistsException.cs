namespace WebAppDBMVC01.Exceptions
{
    public class EntityAlreadyExistsException : AppException
    {
        private static readonly string DEFAULT_CODE = "AlreadyExists";

        public EntityAlreadyExistsException(string message, string code) 
            :base(code + DEFAULT_CODE, message)
        {

        }
    }
}

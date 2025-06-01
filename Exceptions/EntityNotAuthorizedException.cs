namespace WebAppDBMVC01.Exceptions
{
    public class EntityNotAuthorizedException: AppException 
    {
        private static readonly string DEFAULT_CODE = "NotAuthorized";
        public EntityNotAuthorizedException(string message, string code)
            : base(code + DEFAULT_CODE, message)
        {
        }
    }
}

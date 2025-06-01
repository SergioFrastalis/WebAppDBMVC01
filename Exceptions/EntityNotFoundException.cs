namespace WebAppDBMVC01.Exceptions
{
    public class EntityNotFoundException : AppException
    {
        private static readonly string DEFAULT_CODE = "NotFound";
        public EntityNotFoundException(string message, string code)
            : base(code + DEFAULT_CODE, message)
        {
        }
    }
}

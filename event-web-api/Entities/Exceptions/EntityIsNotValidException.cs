namespace Entities.Exceptions
{
    public class EntityIsNotValidException : Exception
    {
        public EntityIsNotValidException(string? message) : base(message)
        {
        }
    }
}

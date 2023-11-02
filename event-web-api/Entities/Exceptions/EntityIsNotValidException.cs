namespace Entities.Exceptions
{
    public class EntityIsNotValidException : BadRequestException
    {
        public EntityIsNotValidException(string? message) : base(message)
        {
        }
    }
}

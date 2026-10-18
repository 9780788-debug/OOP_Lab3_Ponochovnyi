namespace Lab33.BLL.Exceptions;

// Базовий виняток бізнес-логіки (ловиться на рівні представлення).
public class EntityServiceException : Exception
{
    public EntityServiceException(string message) : base(message) { }
    public EntityServiceException(string message, Exception inner) : base(message, inner) { }
}
